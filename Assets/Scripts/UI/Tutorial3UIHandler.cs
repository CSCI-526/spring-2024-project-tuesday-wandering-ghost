using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Tutorial3UIHandler : MonoBehaviour
{
    public GameObject eUI;
    public GameObject hintText;
    public SpriteMask mask;
    public CinemachineVirtualCamera virtualCamera;

    private GameObject ghost;
    private GameObject bone;
    private GameObject dog;
    private MaskControllerTest maskController;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost");
        bone = GameObject.Find("Bone");
        dog = GameObject.Find("Dog");

        maskController = GameObject.Find("Mask").GetComponent<MaskControllerTest>();
        playerController = GameObject.Find("Ghost").GetComponent<PlayerController>();

        eUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        // if the camera's size is exactly 4.5(stopped) active the UI
        if (virtualCamera.m_Lens.OrthographicSize == 4.5f)
        {
            eUI.SetActive(true);
        }

        if (Vector3.Distance(ghost.transform.position, dog.transform.position) < 2) {
            hintText.SetActive(true);
        } else
        {
            hintText.SetActive(false);
        }

    }
}
