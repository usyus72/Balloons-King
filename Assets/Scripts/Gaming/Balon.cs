using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Balon : MonoBehaviourPunCallbacks
{
    int rand;
    public Sprite[] balonlar;
    SpriteRenderer[] balonComps;
    public Rigidbody2D balonMotion;
    public float speedLimit=10f;
    public PhotonView pw;

    [System.Obsolete]
    void Start()
    {
        rand = Random.RandomRange(0, balonlar.Length);
        balonComps = GetComponentsInChildren<SpriteRenderer>();
        balonMotion = GetComponentInChildren<Rigidbody2D>();
        balonComps[0].sprite = balonlar[rand];
        balonComps[0].sortingLayerName = "Gamelayer";
        balonComps[0].sortingOrder = 1;
        pw = GetComponent<PhotonView>();
        

    }

    private void Update()
    {
        if (pw.IsMine==true)
        {
            balonHareket(SimpleInput.GetAxis("Horizontal") * 5f, SimpleInput.GetAxis("Vertical") * 5f);
        }
        
    }
    void balonHareket(float x,float y)
    {
        float velX = balonMotion.velocity.x;
        float velY = balonMotion.velocity.y;
        float speed = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(velX), 2) + Mathf.Pow(Mathf.Abs(velY), 2));
        if (speed < speedLimit)
        {
            balonMotion.AddForce(new Vector2(x , y));
        }
        else
        {
            balonMotion.velocity = new Vector2(1.5f*x,1.5f*y);
        }
    }
    
}
