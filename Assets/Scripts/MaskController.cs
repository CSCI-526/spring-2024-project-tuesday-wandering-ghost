using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public Transform player;
    public SpriteMask mask;
    public KeyCode toggleKey = KeyCode.Space;
    public float duration = 3f;
    public Vector3 targetScale = new Vector3(5, 5, 5);
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
            StartCoroutine(ActivateMask());
        }
    }
    IEnumerator ActivateMask()
    {
        Vector3 originalScale = mask.transform.localScale;
        float currentTime = 0;
        while(currentTime < duration)
        {
            mask.transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        mask.transform.localScale = originalScale;
    }
}
