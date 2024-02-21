using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f; // ÒÆ¶¯ËÙ¶È

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

}
