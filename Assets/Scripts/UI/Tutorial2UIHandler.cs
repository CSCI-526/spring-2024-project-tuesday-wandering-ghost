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
    public CinemachineVirtualCamera virtualCamera;
    
    private GameObject rat;
    
    // Start is called before the first frame update
    void Start()
    {
        rat = GameObject.Find("Rat");
        
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
    }
}
