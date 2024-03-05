using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D webCollider;
    void Start()
    {
        webCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Ghost") {
            Debug.Log("spider enter");
            webCollider.enabled = false;
        }
    }

    /*
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.childCount > 0 && collision.gameObject.name == "Spider")
        {
            webCollider.enabled = true;
        }
    }
     */



}
