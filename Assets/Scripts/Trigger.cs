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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("child true");
        triggerOnChild.SetActive(true);
    }
}
