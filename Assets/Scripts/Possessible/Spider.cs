using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Spider : MonoBehaviour
{
    public GameObject web;
    private float projectileSpeed = 20f;
    private Vector2 lastDirection = Vector2.right; // Default facing direction
    private string type = "Spider";
    private float projectileCount = 20;

    private UnityEngine.Color highLight = new UnityEngine.Color(0.7f, 1, 0.7f);
    private UnityEngine.Color deHighLight = new UnityEngine.Color(1, 1, 1);

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

                if (audioSource != null)
                {
                    audioSource.Play();
                }
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
