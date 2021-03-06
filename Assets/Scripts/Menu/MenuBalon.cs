using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBalon : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = new Vector3(-22.5f , 1 * Mathf.Sin( time * Mathf.Rad2Deg /100 ) , 0 );
    }
}
