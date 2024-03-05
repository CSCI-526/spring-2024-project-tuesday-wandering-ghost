using UnityEngine;

public class Spider : MonoBehaviour
{
    public GameObject web;
    private float projectileSpeed = 10f;
    private Vector2 lastDirection = Vector2.right; // Default facing direction
    private string type = "Spider";

    void Start()
    {

    }

    void Update()
    {
        ShootWeb();
        UpdateFacingDirection();
    }

  
    void ShootWeb()
    {
        if (transform.childCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject projectile = Instantiate(web, transform.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = lastDirection * projectileSpeed;
            }
        }
    }
     


    void UpdateFacingDirection()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Moving Left");
            lastDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            lastDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastDirection = Vector2.down;
        }
    }



}
