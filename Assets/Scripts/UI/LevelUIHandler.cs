using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject hintPanel;
    public GameObject instructionPanel;

    public PlayerController playerController;
    
    private FirebaseDataCollect firebaseData;

    public MaskControllerTest maskController;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<PlayerController>();
            //log.Debug("playerController is ");
        }

        firebaseData = GameObject.Find("Firebase").GetComponent<FirebaseDataCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeInHierarchy) {
                DisablePanel();
            } else
            {
                EnablePanel();
            }

        }
    }

    public void EnablePanel()
    {
        panel.SetActive(true);
        if(maskController.GetIsShrinking())
        {
            maskController.StopShrinking();
        }
        playerController.SetPlayerMovement(false);
    }

    public void DisablePanel()
    {
        panel.SetActive(false);
        maskController.SetIsShrinking(true);
        playerController.SetPlayerMovement(true);
    }

    public void EnableHintPanel()
    {
        hintPanel.SetActive(true);

        if (maskController.GetIsShrinking())
        {
            maskController.StopShrinking();
        }
        Debug.Log(maskController.GetIsShrinking());
        playerController.SetPlayerMovement(false);
    }
    public void DisEnableHintPanel()
    {
        hintPanel.SetActive(false);
        maskController.SetIsShrinking(true);
        
        playerController.SetPlayerMovement(true);
    }

    public void EnableInstructionPanel()
    {
        panel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void DisableInstructionPanel()
    {
        panel.SetActive(true);
        instructionPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void LoadTutorialOne()
    {
        SceneManager.LoadScene("TutorialOne");
    }

    public void LoadTutorialTwo()
    {
        SceneManager.LoadScene("TutorialTwo");
    }

    public void LoadTutorialThree()
    {
        SceneManager.LoadScene("TutorialThree");
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void StartLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }
    
    public void StartLevelFour()
    {
        SceneManager.LoadScene("LevelFour");
    }

    public void RestartLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        firebaseData.UsedReset();
    }
}
