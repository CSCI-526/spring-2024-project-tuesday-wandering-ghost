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
    public TextMeshProUGUI gameOverText;


    Vector3 shrink = new Vector3(0.01f,0.01f,0.01f);
    Vector3 expandToOriginal = new Vector3(1f, 1f, 1f);
    public int spacePressCount = 0;
    public int maxPressCount = 3;
    private bool isShrinking = true;

    // Start is called before the first frame update
    void Start()
    {
       //gameOverText.gameObject.SetActive(false);
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
        if (mask.transform.localScale.x > shrink.x && mask.transform.localScale.y > shrink.y)
        {
            mask.transform.localScale -= shrink;
        }
        else
        {
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
            }
            isShrinking = false;
        }
    }

    IEnumerator ResetMask()
    {
        isShrinking = false;
        Vector3 originalScale = mask.transform.localScale;
        Vector3 targetScale = new Vector3(20f, 20f, 20f);
        float duration = 1.0f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            mask.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终尺寸正确设置
        mask.transform.localScale = targetScale;
        yield return new WaitForSeconds(4);
        isShrinking = true;
    }
    public void IncreaseMaxPressCount()
    {
        maxPressCount++;
    }
    public void StopShrinking()
    {
        isShrinking = false;
    }

}
