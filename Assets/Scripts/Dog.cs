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
        // �����Χ����������
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag(targetTag)) // ����Ƿ�ΪĿ���ǩ
            {
                Bone boneScript = hit.gameObject.GetComponent<Bone>();
                if (boneScript != null)
                {
                    // ���㷽������
                    Vector2 direction = (hit.transform.position - transform.position).normalized;
                    // �ƶ�
                    transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
                    break; // ��������ֻ���һ���ҵ���Ŀ���ƶ�
                }

            }
        }
    }
}
