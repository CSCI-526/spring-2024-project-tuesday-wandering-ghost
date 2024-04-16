using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startMenuButtons;
    public GameObject levelSelectionButtons;
    public Button startBtn;
    GameObject title;
    void Start()
    {
        title = GameObject.Find("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelection()
    {
        startMenuButtons.SetActive(false);
        title.SetActive(false);
        levelSelectionButtons.SetActive(true);
    }

    public void BackToMenu()
    {
        startMenuButtons.SetActive(true);
        title.SetActive(true);
        levelSelectionButtons.SetActive(false);
    }

    public void LoadSceneOne()
    {
        SceneManager.LoadScene("LevelOne");
    }
    
    public void LoadTutorial()
    {
        SceneManager.LoadScene("LevelTutorial");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void LoadLevelFour()
    {
        SceneManager.LoadScene("LevelFour");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
