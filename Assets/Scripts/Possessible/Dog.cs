using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float detectionRadius = 2f;
    public float moveSpeed = 2f;
    public string targetTag = "Possessible";
    private bool isBoneInRange = false;
    private Animator animator;
    bool isMovingTowardsBone = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectBone();
        animator.SetBool("IsMoving", isBoneInRange && isMovingTowardsBone);
    }

    void DetectBone()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        isBoneInRange = false;


        foreach (var hit in hits)
        {
            if (hit.CompareTag(targetTag))
            {
                Bone boneScript = hit.gameObject.GetComponent<Bone>();
                if (boneScript != null)
                {
                    float distanceToBone = Vector2.Distance(transform.position, hit.transform.position);

                    if (distanceToBone > 1.1f)
                    {
                        Vector2 direction = (hit.transform.position - transform.position).normalized;
                        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
                        isMovingTowardsBone = true;
                    }
                    isBoneInRange = true; 
                    break; 
                }
            }
            if (!isBoneInRange || !isMovingTowardsBone)
            {
                isMovingTowardsBone = false;
            }
        }
    }
}
