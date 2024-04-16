using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Tutorial2UIHandler : MonoBehaviour
{
    public GameObject viewAlertTextUI;
    public GameObject spaceUI;
    public GameObject wasdUI;
    public GameObject eUI;
    public GameObject qUI;
    public SpriteMask mask;
    public CinemachineVirtualCamera virtualCamera;
    
    private GameObject ghost;
    private GameObject rat;
    private MaskControllerTest maskController;
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost");
        rat = GameObject.Find("Rat");
        maskController = GameObject.Find("Mask").GetComponent<MaskControllerTest>();
        playerController = GameObject.Find("Ghost").GetComponent<PlayerController>();
        
        wasdUI.SetActive(false);
        eUI.SetActive(false);
        qUI.SetActive(false);
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
            eUI.SetActive(true);
        }
        
        // after possession
        if (rat.transform.childCount>0)
        {
            qUI.SetActive(true);
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

        if (maskController.maxPressCount-maskController.spacePressCount<=4 || Input.GetKeyDown(maskController.toggleKey))
        {
            maskController.SetIsShrinking(true);
            viewAlertTextUI.SetActive(false);
            spaceUI.SetActive(false);
            playerController.SetMovementEnabled(true);
        }
    }
}
