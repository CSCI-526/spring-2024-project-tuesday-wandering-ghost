using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    public MaskControllerTest maskControllerTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        if (maskControllerTest != null)
        {
            maskControllerTest.IncreaseMaxPressCount();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
