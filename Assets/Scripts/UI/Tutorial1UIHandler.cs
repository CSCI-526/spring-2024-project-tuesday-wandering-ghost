using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Tutorial1UIHandler : MonoBehaviour
{
    public GameObject viewAlertTextUI;
    public GameObject spaceUI;
    public GameObject wasdUI;
    public SpriteMask mask;
    public CinemachineVirtualCamera virtualCamera;
    
    private GameObject ghost;
    private MaskControllerTest maskController;
    private PlayerController playerController;
    private Coroutine shrinkCoroutine;
    private int shrinkCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost");
        maskController = GameObject.Find("Mask").GetComponent<MaskControllerTest>();
        playerController = GameObject.Find("Ghost").GetComponent<PlayerController>();
        
        wasdUI.SetActive(false);
        viewAlertTextUI.SetActive(false);
        spaceUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if the camera's size is exactly 4.5(stopped) active the UI
        if (virtualCamera.m_Lens.OrthographicSize == 4.5f)
        {
            wasdUI.SetActive(true);
        }
        
        // shrink quickly
        Vector2 ghostPosition = ghost.transform.position;
        if (ghostPosition.x > 16.0f && shrinkCount == 0)
        {
            maskController.SetShrinkSpeed(new Vector3(0.3f,0.3f,0.3f));
            shrinkCount++;
        }
        
        // show view alert when less than half of the original
        if (mask.transform.localScale.x < 10)
        {
            viewAlertTextUI.SetActive(true);
            spaceUI.transform.position = ghost.transform.position;
            spaceUI.SetActive(true);
            maskController.SetIsShrinking(false);       // stop shrinking
            playerController.SetMovementEnabled(false); // stop moving
        }

        if (Input.GetKeyDown(maskController.toggleKey))
        {
            playerController.SetMovementEnabled(true);
        }

        if (maskController.maxPressCount-maskController.spacePressCount <= 4)
        {
            maskController.SetShrinkSpeed(new Vector3(0.01f,0.01f,0.01f));
            maskController.SetIsShrinking(true);
            viewAlertTextUI.SetActive(false);
            spaceUI.SetActive(false);

        }
    }
}
