using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Tumok : MonoBehaviourPunCallbacks
{
    public PhotonView pw;
    public GameObject dragSound;
    bool dragSoundControl = false;
    float timeToShoot=0.5f;
    public float power;
    public GameObject arrow;
    public GameObject newArrow;
    public Transform shotPoint;
    bool shootControl=false;
    Vector3 direction;
    public float maxPull=5f;


    Joystick joystick;

    private void Start()
    {
        pw = GetComponent<PhotonView>();
        joystick = FindObjectOfType<Joystick>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (pw.IsMine)
        {
            timeToShoot -= Time.deltaTime;
            if (new Vector2(joystick.Horizontal, joystick.Vertical).magnitude > 0)
            {
                OnDragging();
                shootControl = true;

            }
            else if (shootControl)
            {
                if (timeToShoot <= 0f) DragRelease();
                shootControl = false;
            }
            direction = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        }
        
        
        
    }
    void OnDragging()
    {
        
        
        if (timeToShoot <= 0f) 
        { 
            transform.right = direction * (-1);
            if (!dragSoundControl) Instantiate(dragSound, transform.parent);
            dragSoundControl = true;
        }
        
    }
    
    void DragRelease()
    {
        dragSoundControl = false;
        Vector3 clampedForce = Vector3.ClampMagnitude(direction, maxPull) * (-power);
        if (direction.magnitude > 0.2f )
        {
            Player[] players = PhotonNetwork.PlayerList;
            for (int i = 0; i < players.Length; i++)
            {
                    newArrow = PhotonNetwork.Instantiate("ok", shotPoint.position, transform.rotation, 0);
                    newArrow.GetComponent<Rigidbody2D>().AddForce(clampedForce / 10, ForceMode2D.Impulse);
                    timeToShoot = 0.5f;
            }
            
        }
        
        
    }

    
}
