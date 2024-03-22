using UnityEngine;

public class Spider : MonoBehaviour
{
    public GameObject web;
    private float projectileSpeed = 10f;
    private Vector2 lastDirection = Vector2.right; // Default facing direction
    private string type = "Spider";
    private float projectileCount = 5;
    

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
        if (transform.childCount > 0 && projectileCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // GameObject projectile = Instantiate(web, transform.position, Quaternion.identity);
                // Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                // rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                // rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                // rb.velocity = lastDirection * projectileSpeed;
                Vector2 spawnPoint = (Vector2)transform.position + lastDirection * 1.0f; // 可以调整这里的乘数来改变蜘蛛网的起始距离

                GameObject projectile = Instantiate(web, spawnPoint, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = lastDirection * projectileSpeed;
                projectileCount--;
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
