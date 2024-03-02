using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaskControllerTest : MonoBehaviour
{
    public Transform player;
    public SpriteMask mask;
    public KeyCode toggleKey = KeyCode.Space;
    public float duration = 3f;
    public Vector3 targetScale = new Vector3(20, 20, 20);
    public TextMeshProUGUI counterText;

    Vector3 shrink = new Vector3(0.01f,0.01f,0.01f);
    Vector3 expandToOriginal = new Vector3(1f, 1f, 1f);
    public int spacePressCount = 0;
    public int maxPressCount = 3;
    private bool isShrinking = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        if (Input.GetKeyDown(toggleKey) && spacePressCount < maxPressCount)
        {
            StartCoroutine(ResetMask());
            spacePressCount++;
        }
        counterText.text = "Times: " + (maxPressCount - spacePressCount).ToString();
    }

    void FixedUpdate()
    {
        if (isShrinking)
        {
            ShrinkMask();
        }
    }

    void ShrinkMask()
    {
        mask.transform.localScale -= shrink;
    }

    IEnumerator ResetMask()
    {
        isShrinking = false;
        mask.transform.localScale = targetScale;
        yield return new WaitForSeconds(5);
        isShrinking = true;
    }
    public void IncreaseMaxPressCount()
    {
        maxPressCount++;
    }
}
