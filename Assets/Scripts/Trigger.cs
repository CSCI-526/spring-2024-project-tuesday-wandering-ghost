using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject triggerOnChild;
    void Start()
    {
        triggerOnChild = transform.GetChild(0).gameObject;
        triggerOnChild.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Possessible") || collision.CompareTag("Player")) {
            
            triggerOnChild.SetActive(true);
        }
    }
}
