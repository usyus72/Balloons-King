using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneWarning : MonoBehaviour
{
    public Color tempCol;
    bool arttir;
    public SpriteRenderer sqrSprite;
    // Start is called before the first frame update
    void Start()
    {
        arttir = true;
        tempCol = sqrSprite.color;
        tempCol.a = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!arttir)
        {
            tempCol.a -= 0.0005f;
            if (tempCol.a <= 0.4f) arttir = true;
        }
        if (arttir)
        {
            tempCol.a += 0.0005f;
            if (tempCol.a >= 0.7f) arttir = false;
        }
        
        sqrSprite.color = tempCol;
    }
    

}
