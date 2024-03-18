using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exits;
    private Vector3 offset = new Vector3(1,0,0);
    SpriteRenderer exitSR;

    //SpriteRenderer portalSR;
    void Start()
    {
        //portalSR = GetComponent<SpriteRenderer>();
        exitSR = exits.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (exitSR.flipX)
        {
            collision.transform.position = exits.transform.position + offset;

        } else
        {
            
            collision.transform.position = exits.transform.position - offset;
        }
    }
}
