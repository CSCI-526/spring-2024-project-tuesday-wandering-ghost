using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public PlayerController playerController;
    void Start()
    {
         GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<PlayerController>();
            //log.Debug("playerController is ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeInHierarchy) {
                panel.SetActive(false);
                playerController.SetPlayerMovement(true);
            } else
            {
                panel.SetActive(true);
                playerController.SetPlayerMovement(false);
            }

        }
    }

    public void DisablePanel()
    {
        panel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void StartLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
