using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    float detectionRadius = 2.5f;
    float stopRadius = 0.95f;
    float moveSpeed = 2.5f;
    public string targetTag = "Possessible";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectBone();
    }

    void DetectBone()
    {
        // detect all surrounding obj
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag(targetTag)) // check if the target tag
            {
                Bone boneScript = hit.gameObject.GetComponent<Bone>();
                if (boneScript != null)
                {
                    // calc direction vector
                    Vector2 direction = (hit.transform.position - transform.position).normalized;

                    // if too close, stop the dog
                    float dis = Vector2.Distance(hit.transform.position, transform.position);

                    // Debug.Log(dis);

                    if(dis > stopRadius)
                    {
                        // movement
                        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
                    }

                    
                    break; // only move to the first target that been found
                }

            }
        }
    }
}