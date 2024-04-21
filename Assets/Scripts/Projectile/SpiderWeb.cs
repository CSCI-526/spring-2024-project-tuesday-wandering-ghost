using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    // Start is called before the first frame update
    float lifetime = 3f;
    BoxCollider2D webCollider;
    void Start()
    {
        GameObject[] possessibles = GameObject.FindGameObjectsWithTag("Possessible");
        if (possessibles != null) {
            webCollider = this.gameObject.GetComponent<BoxCollider2D>();
            foreach (GameObject possessible in possessibles) {
                CapsuleCollider2D psCollider = possessible.GetComponent<CapsuleCollider2D>();
                if (psCollider != null && webCollider != null) {
                    Physics2D.IgnoreCollision(psCollider,webCollider,true);
                }
            }
        }


        
        StartCoroutine(DeactivateAfterTime(lifetime));
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject); 
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
