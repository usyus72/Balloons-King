using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject enterNick;
    float beklemeSuresi=3f;

    void Update()
    {
        if (beklemeSuresi>0)
        {
            beklemeSuresi -= Time.deltaTime;
            if (beklemeSuresi<=0)
            {
                enterNick.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
