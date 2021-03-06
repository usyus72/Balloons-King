using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ipbaglantisi : MonoBehaviour
{
    public HingeJoint2D bagNoktası;
    public Rigidbody2D sepet;
    
    // Start is called before the first frame update
    void Start()
    {
        bagNoktası.connectedBody = sepet;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
