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
    private LevelUIHandler levelUIHandler;
    private bool sawShrink = false;
    public GameObject winPanel;
    private int timeCountWhenStop = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost");
        maskController = GameObject.Find("Mask").GetComponent<MaskControllerTest>();
        playerController = GameObject.Find("Ghost").GetComponent<PlayerController>();
        levelUIHandler = GameObject.Find("Canvas").GetComponent<LevelUIHandler>();
        
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
        print(!sawShrink);
        print(maskController.GetIsShrinking());
        if (!sawShrink && ghostPosition.x > 16.0f)
        {
            maskController.SetShrinkSpeed(new Vector3(0.3f,0.3f,0.3f));
        }
        
        // show view alert when less than half of the original
        if (mask.transform.localScale.x < 10)
        {
            viewAlertTextUI.SetActive(true);
            spaceUI.transform.position = ghost.transform.position;
            spaceUI.SetActive(true);
        }

        // already saw alert and hit space
        if (sawShrink && maskController.maxPressCount-maskController.spacePressCount < timeCountWhenStop)
        {
            maskController.SetShrinkSpeed(new Vector3(0.01f,0.01f,0.01f));
            viewAlertTextUI.SetActive(false);
            spaceUI.SetActive(false);
        }

        if (spaceUI.activeSelf)
        {
            maskController.SetIsShrinking(false);       // stop shrinking
            playerController.SetMovementEnabled(false); // stop moving
            sawShrink = true;
            
            // to avoid first keydown is not response in UI control only in mask's PressCount
            timeCountWhenStop = maskController.maxPressCount - maskController.spacePressCount;
        }
        else if (!spaceUI.activeSelf && virtualCamera.m_Lens.OrthographicSize == 4.5f)
        {
            maskController.SetIsShrinking(true);
            playerController.SetMovementEnabled(true);
        }
        
        // stop move when panels open
        if (winPanel.activeSelf || levelUIHandler.isPanelOpen)
        {
            maskController.SetIsShrinking(false);
            playerController.SetPlayerMovement(false);
        }
    }
}
