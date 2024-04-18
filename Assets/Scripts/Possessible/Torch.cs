// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Torch : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public GameObject fire;
//     private float projectileSpeed = 10f;
//     private Vector2 lastDirection = Vector2.left; // Default facing direction
//     SpriteRenderer torchSR;
//     public Sprite lightSprite;

//     public GameObject lightStatus;
//     MapStatus lightStatusScript;

//     bool isLight = false;

//     void Start()
//     {
//        torchSR = GetComponent<SpriteRenderer>();
//        lightStatusScript = lightStatus.GetComponent<MapStatus>(); 

//        if (torchSR.sprite.name == "Torch_Light") {
//             isLight = true;
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         ShootFire();
//     }


//      void ShootFire() {
//         if (transform.childCount > 0 && isLight)
//         {
//             if (Input.GetKeyDown(KeyCode.Q))
//             {
//                 GameObject projectile = Instantiate(fire, transform.position, Quaternion.identity);

//                 Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

//                 Vector2 shootDirection = Vector2.right;
//                 if (Input.GetKey(KeyCode.W))
//                 {
//                     shootDirection = Vector2.up;
//                 }
//                 else if (Input.GetKey(KeyCode.S))
//                 {
//                     shootDirection = Vector2.down;
//                 }
//                 else if (Input.GetKey(KeyCode.A))
//                 {
//                     shootDirection = Vector2.left;
//                 }
//                 else if (Input.GetKey(KeyCode.D))
//                 {
//                     shootDirection = Vector2.right;
//                 }
//                 rb.velocity = shootDirection * projectileSpeed;
//             }
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Fire")) {
//             if (torchSR.sprite.name == "Torch_Dim") {
//                 torchSR.sprite = lightSprite;
//                 isLight = true;
//                 lightStatusScript.increaseNum();
//                 Destroy(collision.gameObject);
//             }
//         }
//     }






// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject fire;
    private float projectileSpeed = 10f;
    public Vector2 shootDirection = Vector2.left; 
    SpriteRenderer torchSR;
    public Sprite lightSprite;

    public GameObject lightStatus;
    MapStatus lightStatusScript;

    bool isLight = false;
    private bool hasFired = false;

    private int fireCount = 0;
    public int maxFireCount = 3;

    public float fireCooldown = 1f;

    private UnityEngine.Color highLight = new UnityEngine.Color(0.7f, 1, 0.7f);
    private UnityEngine.Color deHighLight = new UnityEngine.Color(1, 1, 1);

    public AudioSource audioSource;

    void Start()
    {
        torchSR = GetComponent<SpriteRenderer>();
        lightStatusScript = lightStatus.GetComponent<MapStatus>();

        if (torchSR.sprite.name == "Torch_Light")
        {
            isLight = true;
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ShootFire();
    }

    void ShootFire()
    {
        if (transform.childCount > 0&&isLight && !hasFired && fireCount < maxFireCount) 
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                GameObject projectile = Instantiate(fire, transform.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.velocity = shootDirection.normalized * projectileSpeed; 
                hasFired = true; 
                fireCount++;
                StartCoroutine(ResetFire());

                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }
    IEnumerator ResetFire()
    {
        yield return new WaitForSeconds(fireCooldown); 
        hasFired = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            if (torchSR.sprite.name == "Torch_Dim")
            {
                torchSR.sprite = lightSprite;
                isLight = true;
                lightStatusScript.increaseNum();
                Destroy(collision.gameObject);
            }
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

