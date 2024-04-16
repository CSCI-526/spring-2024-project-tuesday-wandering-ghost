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
    private bool playerMove = true;
    private Animator animator; // Reference to the Animator component
    string[] possesibleTags = { "Possessible", "FixedPossessible" };
    private float originalSpeed = 3f;
    private float speedIncreaseFactorSpider = 4f;
    private float speedIncreaseFactorRat = 5f;
    public MaskControllerTest maskControllerTest;

    private Color highLight = new Color(0.7f, 1, 0.7f);
    private Color deHighLight = new Color(0, 0, 0);

    public void SetMovementEnabled(bool enabled)
    {
        playerMove = enabled;
    }
    void Start()
    {
        ghostRb = transform.GetComponent<Rigidbody2D>();
        ghostCollider = transform.GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        originalSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Possess();
        DetectTaggedObjects2D(possesibleTags, detectionRadius);
        if (isPossessing)
    {
        UpdateFacingDirection(); 
    }

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

        if (transform.parent != null && transform.parent.CompareTag("FixedPossessible"))
        {
            ghostRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }


        if (transform.parent != null && transform.parent.CompareTag("Possessible"))
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

    void DetectTaggedObjects2D(string[] tags, float detectionRadius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var hitCollider in hitColliders)
        {
            foreach (var tag in tags)
            {
                if (hitCollider.CompareTag(tag))
                {
                    toPossess = hitCollider.gameObject;
                    return;
                }
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
                if (toPossess.GetComponent<Spider>() != null)
                { 
                    moveSpeed += speedIncreaseFactorSpider; 
                }
                if(toPossess.GetComponent<Rat>() != null)
                {
                    moveSpeed += speedIncreaseFactorRat;
                }
                toPossess = null;
                transform.position = transform.parent.position;
                
            }


            else if (isPossessing) //press E when possessing will quite
            {
                if(true){
                Rigidbody2D parentRb = transform.parent.GetComponent<Rigidbody2D>();
                parentRb.constraints = RigidbodyConstraints2D.FreezeAll;
                transform.parent = null;
                isPossessing = false;                
                ghostCollider.enabled = true; //enable collider
                moveSpeed = originalSpeed; //back to original speed
                transform.localScale = new Vector3(1, 1, 1);//back to original size
                ghostRb.constraints  &= ~RigidbodyConstraints2D.FreezePositionX;
                ghostRb.constraints &= ~RigidbodyConstraints2D.FreezePositionY; //cancel xy axis movement restriction
                maskControllerTest.SetIsShrinking(true);

                }
                else
                {
                    Debug.Log("No space to depossess");
                }

            }
        }
    }

    /*
         bool CheckSpaceForDepossess()
{
    if (transform.parent != null)
    {
        Rat ratComponent = transform.parent.GetComponent<Rat>(); //get rat component
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
     */


    public void SetPlayerMovement(bool enable)
        {
            playerMove = enable;
            if (!enable)
            {
                ghostRb.velocity = Vector2.zero;
            }
        }


 void UpdateFacingDirection()
{
    Animator animator = null;
    if (isPossessing && transform.parent != null)
    {
        animator = transform.parent.GetComponent<Animator>();
    }
    else
    {
        
        animator = GetComponent<Animator>();
    }

    if (animator != null)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Moving Left");
            animator.SetTrigger("MoveLeft");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Moving Right");
            animator.SetTrigger("MoveRight");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Moving Up");
            animator.SetTrigger("MoveUp");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Moving Down");
            animator.SetTrigger("MoveDown");
        }
    }
}
}




