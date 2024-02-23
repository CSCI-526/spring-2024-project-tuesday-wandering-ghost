using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    float detectionRadius = 1f;
    public float moveSpeed = 2f;
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
        // 检测周围的所有物体
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag(targetTag)) // 检查是否为目标标签
            {
                Bone boneScript = hit.gameObject.GetComponent<Bone>();
                if (boneScript != null)
                {
                    // 计算方向向量
                    Vector2 direction = (hit.transform.position - transform.position).normalized;
                    // 移动
                    transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
                    break; // 假设我们只向第一个找到的目标移动
                }

            }
        }
    }
}
