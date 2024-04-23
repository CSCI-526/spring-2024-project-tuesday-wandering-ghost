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


    Vector3 shrink = new Vector3(0.04f,0.04f,0.04f);
    Vector3 expandToOriginal = new Vector3(1f, 1f, 1f);
    public int spacePressCount = 0;
    public int maxPressCount = 5;
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
            mask.transform.localScale -= shrink / 2;
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
    public void AdjustMaskSize(float newOrthoSize)
    {
        float scaleMultiplier = Mathf.Lerp(1f, 5f, (newOrthoSize - 4.5f) / (10f - 4.5f));
        mask.transform.localScale = targetScale * scaleMultiplier;
    }

    public void SetIsShrinking(bool newShrinking)
    {
        isShrinking = newShrinking;
    }

    public bool GetIsShrinking()
    {
        return isShrinking;
    }

    public void SetFixedMaskSize()
    {
        mask.transform.localScale = new Vector3(5, 5, 5);  // Set the fixed size here
    }

    public void SetShrinkSpeed(Vector3 newShrink)
    {
        shrink = newShrink;
    }

}
