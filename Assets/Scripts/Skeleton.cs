using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bone;
    string type = "Skeleton";
    float projectileCount = 1;
    float projectileSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBone();
    }

    void ShootBone()
    {
        if (transform.childCount > 0 && projectileCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject projectile = Instantiate(bone, transform.position, Quaternion.identity);

                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                Vector2 shootDirection = Vector2.left;
                

                rb.velocity = shootDirection * projectileSpeed;
                projectileCount--;
            }
        }
    }

    public string GetType()
    {
        return type;
    }
}
