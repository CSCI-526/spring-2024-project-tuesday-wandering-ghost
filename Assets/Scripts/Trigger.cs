using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject triggerOnChild;
    void Start()
    {
        triggerOnChild = transform.Find("Trigger_on").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Possessible") || collision.gameObject.CompareTag("Player")) {
            print("child true");
            triggerOnChild.SetActive(true);
        }
    }
}
