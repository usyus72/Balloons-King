using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSound : MonoBehaviour
{

    float time = 2f;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
