using Unity.Mathematics;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject bone;
    private Animator animator; // Reference to the Animator component
    private float cooldown = 1.0f;
    private float lastShot = 0;
    //private float projectileCount = 5;
    private float projectileSpeed = 10f;
    private Vector2 lastDirection = Vector2.right; // Default facing direction
    private string type = "Skeleton";

    private UnityEngine.Color highLight = new UnityEngine.Color(0.7f, 1, 0.7f);
    private UnityEngine.Color deHighLight = new UnityEngine.Color(1, 1, 1);

    public AudioSource audioSource;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // public void SetDefaultState()
    // {
    //     animator.SetTrigger("MoveDown");
    // }
    void Update()
    {
        ShootBone();
        UpdateFacingDirection();
    }

    void ShootBone()
    {
        if (transform.childCount > 0 && Time.time - lastShot > cooldown)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject projectile = Instantiate(bone, transform.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.velocity = lastDirection * projectileSpeed;
                lastShot = Time.time;

                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
        // {
        //     if (Input.GetKeyDown(KeyCode.Q))
        //     {
        //         GameObject projectile = Instantiate(bone, transform.position, Quaternion.identity);
        //         Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        //         rb.velocity = lastDirection * projectileSpeed;
        //         projectileCount--;

        //         if (audioSource != null)
        //         {
        //             audioSource.Play();
        //         }
        //     }
        // }
    }

    void UpdateFacingDirection()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Moving Left");
            lastDirection = Vector2.left;
            //animator.SetTrigger("MoveLeft");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastDirection = Vector2.right;
            //animator.SetTrigger("MoveRight");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            lastDirection = Vector2.up;
            //animator.SetTrigger("MoveUp");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastDirection = Vector2.down;
            //animator.SetTrigger("MoveDown");
        }
    }

public string GetSkeletonType()
{
    return type;
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
