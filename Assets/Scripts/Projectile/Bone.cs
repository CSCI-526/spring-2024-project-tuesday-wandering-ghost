using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    // Start is called before the first frame update
    float lifetime = 1f; // Projectile���ʱ��
    string type = "Bone";
    private Rigidbody2D rb;
    Collider2D cl;

    private UnityEngine.Color highLight = new UnityEngine.Color(0.7f, 1, 0.7f);
    private UnityEngine.Color deHighLight = new UnityEngine.Color(1, 1, 1);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
        StartCoroutine(DeactivateAfterTime(lifetime));
        StartCoroutine(DisableGravityAfterTime(2.0f));
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero; 
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        cl.enabled = true;
    }
    IEnumerator DisableGravityAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (rb != null)
        {
            rb.gravityScale = 0; 
            rb.velocity = new Vector2(rb.velocity.x, 0); 
        }
    }
    public string getType()
    {
        return type;//return type
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = highLight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = deHighLight;
        }
    }
}
