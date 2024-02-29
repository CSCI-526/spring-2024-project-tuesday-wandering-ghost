using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    private bool playerMove = true;

    public TextMeshProUGUI useAbilityTextUI;
    public Vector3 UIoffset = new Vector3(300, 300, 0);

    void Start()
    {
        ghostRb = transform.GetComponent<Rigidbody2D>();
        ghostCollider = transform.GetComponent<Collider2D>();
        useAbilityTextUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Possess();
        DetectTaggedObjects2D("Possessible", detectionRadius);
        useAbilityTextUI.transform.position = transform.position + UIoffset;
    }

    void FixedUpdate()
    {
        if(playerMove){
            MoveCharacter();
        }
       // MoveCharacter();

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

        // get parent's Rigidbody2D component
        Rigidbody2D parentRb = null;

        if (transform.parent != null)
        {
            parentRb = transform.parent.GetComponent<Rigidbody2D>();
            parentRb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            parentRb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;//cancel xy axis movement restriction
        }

        if (parentRb != null)
        {
            // use Rigidbody2D to move parent obj
            Vector2 newParentPosition = parentRb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            parentRb.MovePosition(newParentPosition);
            ghostRb.MovePosition(newParentPosition);

        }
        else
        {
            // move in the original way when parent no Rigidbody2D
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
            if (!isPossessing && toPossess != null) // if no possession and has possessable obj
            {
                ghostCollider.enabled = false;   //disableCollider
                transform.localScale = new Vector3(0.1f,0.1f,0.1f);
                transform.SetParent(toPossess.transform); // set parent
                isPossessing = true; // is possessing
                toPossess = null;
                transform.position = transform.parent.position;

                string message = "";
                while (true)
                {
                    Rat ratComponent = transform.parent.GetComponent<Rat>();
                    if (ratComponent != null)
                    {
                        Debug.Log("1");
                        message = "Press [Q] to shrink the size";
                        ShowUI(message);
                        Invoke("HideUI", 3f);
                        break;
                    }
                    Bone boneComponent = transform.parent.GetComponent<Bone>();
                    if (boneComponent != null)
                    {
                        message = "Bone can attract the dog";
                        ShowUI(message);
                        Invoke("HideUI", 3f);
                        break;
                    }
                    Skeleton skeletonComponent = transform.parent.GetComponent<Skeleton>();
                    if (skeletonComponent != null)
                    {
                        message = "Press [Q] to shoot the bone";
                        ShowUI(message);
                        Invoke("HideUI", 3f);
                        break;
                    }
                    break;
                }
               
            }
            else if (isPossessing) //press E when possessing will quite
            {
                if(CheckSpaceForDepossess()){
                Rigidbody2D parentRb = transform.parent.GetComponent<Rigidbody2D>();
                parentRb.constraints = RigidbodyConstraints2D.FreezeAll;
                transform.parent = null;
                isPossessing = false;
                ghostCollider.enabled = true; //enable collider
                transform.localScale = new Vector3(1, 1, 1);//back to original size

                }
                else
                {
                    Debug.Log("No space to depossess");
                }

            }
        } 
        }

    void ShowUI(string message)
    {
        useAbilityTextUI.text = message;
        useAbilityTextUI.enabled = true;
    }

    void HideUI()
    {
        useAbilityTextUI.enabled = false;
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
    public void SetPlayerMovement(bool enable)
        {
            playerMove = enable;
            if (!enable)
            {
                ghostRb.velocity = Vector2.zero;
            }
        }



}