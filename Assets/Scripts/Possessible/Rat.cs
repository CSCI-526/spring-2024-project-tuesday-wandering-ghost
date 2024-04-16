using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Rat : MonoBehaviour
{
    // Start is called before the first frame update
    public string type = "Rat";
    public MaskControllerTest maskControllerTest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            //ShrinkRat();
            MaskChange();
        }
        else
        {
            //NormalRat();
        }
    }
    public string GetType()
    {
        return type;
    }

    void MaskChange()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            maskControllerTest.StopShrinking();
            maskControllerTest.SetFixedMaskSize();
        }
    }
    //void ShrinkRat()
    //{
    //    // Rat scale to size that can pass the narrow path
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        transform.localScale = new Vector3(1, 1, 1);
    //    }
    //}

    //void NormalRat()
    //{
    //    transform.localScale = new Vector3(1f, 1f, 1);
    //}
}
