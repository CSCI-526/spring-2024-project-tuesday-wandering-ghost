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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
        StartCoroutine(DeactivateAfterTime(lifetime));
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero; // ֹͣ�ƶ�
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        cl.enabled = true;
    }

    public string getType()
    {
        return type;//return type
    }
}
