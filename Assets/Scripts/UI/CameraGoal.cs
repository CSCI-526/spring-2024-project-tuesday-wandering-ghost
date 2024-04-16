
using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraGoal : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; 
    public float targetOrthoSize = 10f; 
    public float initialOrthoSize = 4.5f; 
    public float adjustDuration = 2f; 
    public PlayerController playerController;
    public MaskControllerTest maskController;
    private void Start()
    {
        virtualCamera.m_Lens.OrthographicSize = initialOrthoSize;
        AdjustOrthoSizeForNewLevel();
    }

    public void AdjustOrthoSizeForNewLevel()
    {
        StartCoroutine(AdjustOrthoSizeCoroutine(targetOrthoSize, true));
    }

    IEnumerator AdjustOrthoSizeCoroutine(float targetSize, bool thenShrinkBack)
    {
        playerController.SetMovementEnabled(false);

        float currentTime = 0f;
        float startSize = virtualCamera.m_Lens.OrthographicSize;
        float t;
        while (currentTime < adjustDuration)
        {
            currentTime += Time.deltaTime;
            t = currentTime / adjustDuration;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, targetSize, t);
            maskController.AdjustMaskSize(virtualCamera.m_Lens.OrthographicSize);
            yield return null;
        }

        if (thenShrinkBack)
        {
            yield return new WaitForSeconds(1f);
            currentTime = 0;
            startSize = virtualCamera.m_Lens.OrthographicSize;
            while (currentTime < adjustDuration)
            {
                currentTime += Time.deltaTime;
                t = currentTime / adjustDuration;
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, initialOrthoSize, t);
                maskController.AdjustMaskSize(virtualCamera.m_Lens.OrthographicSize);
                yield return null;
            }
            playerController.SetMovementEnabled(true);
        }
    }

}
