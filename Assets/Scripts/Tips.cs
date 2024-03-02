using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tips : MonoBehaviour
{
    private string sceneName;
    public TextMeshProUGUI useAbilityTextUI;
    public Vector3 UIoffset = new Vector3(300, 300, 0);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        setTextBasedOnScene();
        useAbilityTextUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        useAbilityTextUI.transform.position = UIoffset + player.transform.position;
        if(Input.GetKeyDown(KeyCode.T))
        {
            ShowUI();
            Invoke("HideUI", 3f);
        }
    }

    void setTextBasedOnScene()
    {
        switch (sceneName) 
        { 

        case "LevelTutorial":
            useAbilityTextUI.text = "LevelTutorial";
            break;
        case "LevelOne":
            useAbilityTextUI.text = "LevelOne";
            break;
        default:
            break;
        }
    }
    
    void ShowUI()
    {
        useAbilityTextUI.enabled = true;
    }

    void HideUI()
        {
            useAbilityTextUI.enabled = false;
        }
}
