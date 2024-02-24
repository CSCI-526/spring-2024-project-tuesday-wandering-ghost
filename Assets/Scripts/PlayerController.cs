using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    float detectionRadius = 1f;
    GameObject toPossess;
    bool isPossessing = false;
    bool reachedGoal = false;
    Rigidbody2D ghostRb;
    Collider2D ghostCollider;

    void Start()
    {
        ghostRb = transform.GetComponent<Rigidbody2D>();
        ghostCollider = transform.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Possess();
        DetectTaggedObjects2D("Possessible", detectionRadius);
    }

    void FixedUpdate()
    {
        MoveCharacter();

    }

    void LateUpdate()
    {

    }

    void MoveCharacter()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // 动态获取父对象的Rigidbody2D组件
        Rigidbody2D parentRb = null;

        if (transform.parent != null)
        {
            parentRb = transform.parent.GetComponent<Rigidbody2D>();
            parentRb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            parentRb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;//取消xy轴移动限制
        }

        if (parentRb != null)
        {
            // 使用Rigidbody2D来移动父对象
            Vector2 newParentPosition = parentRb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            parentRb.MovePosition(newParentPosition);
            ghostRb.MovePosition(newParentPosition);

        }
        else
        {
            // 如果没有父对象的Rigidbody2D，就按原来的方式移动当前对象
            ghostRb.MovePosition(ghostRb.position + moveDirection * moveSpeed * Time.fixedDeltaTime); 
        }
    }

    void DetectTaggedObjects2D(string tag, float detectionRadius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(tag))
            {
                toPossess = hitCollider.gameObject;
                return; 
            }
        }
        toPossess = null;
    }

    void Possess()
    {
        if (Input.GetKeyDown(KeyCode.E)) { 
            if (!isPossessing && toPossess != null) //如果没有附身 且有可附身物体
            {
                ghostCollider.enabled = false;   //disableCollider
                transform.localScale = new Vector3(0.1f,0.1f,0.1f);
                transform.SetParent(toPossess.transform); // set parent
                isPossessing = true; // is possessing
                toPossess = null;
                transform.position = transform.parent.position;
                
            }
            else if (isPossessing) //附身中E，退出
            {
                if(CheckSpaceForDepossess()){
                Rigidbody2D parentRb = transform.parent.GetComponent<Rigidbody2D>();
                parentRb.constraints = RigidbodyConstraints2D.FreezeAll;
                transform.parent = null;
                isPossessing = false;
                ghostCollider.enabled = true; //enable collider
                transform.localScale = new Vector3(1, 1, 1);//恢复原来大小

                }
                else
                {
                    Debug.Log("No space to depossess");
                }

            }
        } 
        }

    bool CheckSpaceForDepossess()
{
    if (transform.parent != null)
    {
        Rat ratComponent = transform.parent.GetComponent<Rat>(); //get rate component
        if (ratComponent != null && ratComponent.GetType() == "Rat")
        {
            Collider2D ratCollider = transform.parent.GetComponent<Collider2D>(); //get rat's collider
            if (ratCollider != null)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, ratCollider.bounds.extents.x + 0.1f); //check 0.1f distance around the rat
                foreach (var hit in hits)
                {
                    if (hit != ratCollider && hit != ghostCollider && !hit.isTrigger) //ignore rat's collider and ghost's collider
                    {
                        return false; 
                    }
                }
            }
        }
    }

    return true; 
}



}