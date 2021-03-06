using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        [SerializeField]
        public GameObject cam;

        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        public PhotonView pw;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;



        // Use this for initialization
        private void Start()
        {
            cam = GameObject.FindWithTag("MainCamera");
            if (!pw.IsMine)
            {
                Destroy(this.gameObject); 
            }
            if (pw.IsMine)
            {
                cam.SetActive(false);
            }
            
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            
            // only update lookahead pos if accelerating or changed direction
       
                float xMoveDelta = (target.position - m_LastTargetPosition).x;

                bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                if (updateLookAheadTarget)
                {
                    m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                }
                else
                {
                    m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                }

                Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
                Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                float newPosx = newPos.x;
                float newPosy = newPos.y;
                
                if (target.position.x < 40 && target.position.x > -40 && target.position.y < 50 && target.position.y > -56)
                {
                    transform.position = new Vector3(newPosx, newPosy, m_OffsetZ);
                }
                else if((target.position.x >= 40 || target.position.x <= -40) && (target.position.y >= 50 || target.position.y <= -56))
                {
                    if (target.position.x >= 40.55f) newPosx = 40.55f;
                    else if (target.position.x <= -40.55f) newPosx = -40.55f;
                    if (target.position.y >= 50.22f) newPosy = 50.22f;
                    else if (target.position.y <= -56.04f) newPosy = -56.04f;
                    transform.position = new Vector3(newPosx, newPosy, m_OffsetZ);
                    }
                else if (target.position.x >= 40 || target.position.x <= -40)
                {
                
                    if (target.position.x >= 40.55f) newPosx = 40.55f;
                    else if (target.position.x <= -40.55f) newPosx = -40.55f;
                    transform.position = new Vector3(newPosx, newPosy, m_OffsetZ);
                }
                else if (target.position.y >= 50 || target.position.y <= -56)
                {
                    if (target.position.y >= 50.22f) newPosy = 50.22f;
                    else if (target.position.y <= -56.04f) newPosy = -56.04f;
                    transform.position = new Vector3(newPosx, newPosy, m_OffsetZ);
                }
                m_LastTargetPosition = target.position;
            
        }
    }
}
