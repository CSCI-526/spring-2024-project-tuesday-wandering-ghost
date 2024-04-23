using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    float lifetime = 3f; 
    string type = "Fire";
    private Rigidbody2D rb;
    Collider2D cl;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
        StartCoroutine(DeactivateAfterTime(lifetime));
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    public string getType()
    {
        return type;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Possessible")) {
            Destroy(this.gameObject);
        }
    }
}
