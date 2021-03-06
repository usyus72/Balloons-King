using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Ustsinir : MonoBehaviour
{
    public GameObject balloonPopSound;
    Transform alan;

    // Start is called before the first frame update
    void Start()
    {
       alan=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        alan.position += new Vector3(0, -Time.deltaTime/10,0) ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Birbalon")
        {
            Instantiate(balloonPopSound, transform.parent);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
       
    }
}
