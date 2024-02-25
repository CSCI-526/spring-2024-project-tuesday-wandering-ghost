using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControllerTest : MonoBehaviour
{
    public Transform player;
    public SpriteMask mask;
    public KeyCode toggleKey = KeyCode.Space;
    //public float duration = 3f;
    public Vector3 targetScale = new Vector3(20, 20, 20);
    
    Vector3 shrink = new Vector3(0.01f,0.01f,0.01f);
    Vector3 expandToOriginal = new Vector3(1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        if (Input.GetKeyDown(toggleKey))
        {
            StartCoroutine(ResetMask());
            ResetMask();
        }
    }

    void FixedUpdate()
    {
        ShrinkMask();
    }

    void ShrinkMask()
    {
        mask.transform.localScale -= shrink;
    }

    IEnumerator ResetMask()
    {
        for (int i = 0; i < 20; i++)
        {
            mask.transform.localScale += expandToOriginal;
            yield return new WaitForSeconds(0.02f);
        }

    }
}
