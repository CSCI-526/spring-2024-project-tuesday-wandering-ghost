using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Rat : MonoBehaviour
{
    // Start is called before the first frame update
    public string type = "Rat";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0) {
            ShrinkRat();
        } else {
            NormalRat();
        }
    }
    public string GetType()
    {
        return type;
    }
    
    void ShrinkRat() {
        // Rat scale to size that can pass the narrow path
        if (Input.GetKeyDown(KeyCode.Q)) {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void NormalRat()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
}
