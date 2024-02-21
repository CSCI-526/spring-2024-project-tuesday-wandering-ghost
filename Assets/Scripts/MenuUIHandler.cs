using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startMenuButtons;
    public GameObject levelSelectionButtons;
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

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
