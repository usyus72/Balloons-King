using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DeadZone : MonoBehaviour
{

    public GameObject balloonPopSound;

    private void Start()
    {
         
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Birbalon")
        {
            Instantiate(balloonPopSound, transform.parent);
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
