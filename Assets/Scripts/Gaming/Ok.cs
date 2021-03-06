using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Photon.Pun;
using Photon.Realtime;

public class Ok : MonoBehaviourPunCallbacks
{
    public PhotonView pw;
    public GameObject balloonPopSound;
    float timeToDelArrow;
    bool saplanma = false;
    Rigidbody2D rb;
    PolygonCollider2D pcol;
    
    // Start is called before the first frame update
    void Start()
    {
        
        pw = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        pcol = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        acisalHareket();
        if (saplanma == true)
        {
            timeToDelArrow -= Time.deltaTime;
            if (timeToDelArrow <= 0f)
            {
                Destroy(this.gameObject);
            }
        }


    }
    void acisalHareket()
    {
        if (!saplanma)
        {
            Vector2 yon = rb.velocity;
            float acı = Mathf.Atan2(yon.y, yon.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(acı+180f, Vector3.forward);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Birbalon")
        {
            saplanma = true;
            Instantiate(balloonPopSound, transform.parent);
            collision.transform.parent.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "Sagsinir" || collision.gameObject.name == "Solsinir" || collision.gameObject.name == "Ustsinir")
        {
            saplanma = true;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "Altsinir")
        {
            if (!saplanma)
            {
                saplanma = true;
                Destroy(pcol);
                Destroy(rb);
                timeToDelArrow = 3f;
            }
        }

    }
}
