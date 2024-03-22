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
    public Vector2 shootDirection = Vector2.left; // 默认向右发射，可以在编辑器中修改
    SpriteRenderer torchSR;
    public Sprite lightSprite;

    public GameObject lightStatus;
    MapStatus lightStatusScript;

    bool isLight = false;
    private bool hasFired = false;


    void Start()
    {
        torchSR = GetComponent<SpriteRenderer>();
        lightStatusScript = lightStatus.GetComponent<MapStatus>();

        if (torchSR.sprite.name == "Torch_Light")
        {
            isLight = true;
        }
    }

    void Update()
    {
        ShootFire();
    }

    void ShootFire()
    {
        if (transform.childCount > 0&&isLight && !hasFired) // 检查火炬是否点亮且未发射过
        {
            if (Input.GetKeyDown(KeyCode.Q)) // 当按下Q键时
            {
                GameObject projectile = Instantiate(fire, transform.position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.velocity = shootDirection.normalized * projectileSpeed; // 使用预设的发射方向

                hasFired = true; // 标记为已发射，不允许再次发射
            }
        }
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
}
