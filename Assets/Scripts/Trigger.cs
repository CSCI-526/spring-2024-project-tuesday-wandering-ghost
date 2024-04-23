using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject triggerOnChild;
    AudioSource audioSource;
    void Start()
    {
        triggerOnChild = transform.GetChild(0).gameObject;
        triggerOnChild.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
         private void OnTriggerEnter2D(Collider2D collision)
    {
        // print("In Trigger");
        if (collision.CompareTag("Possessible") || collision.CompareTag("Player")) {
            // print("in active");
            triggerOnChild.SetActive(true);
            audioSource.Play();
        }
    }
     */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print("In collision");
        if (collision.gameObject.CompareTag("Possessible") || collision.gameObject.CompareTag("Player")) {
            // print("child true");
            triggerOnChild.SetActive(true);
            audioSource.Play();
        }
    }
}
