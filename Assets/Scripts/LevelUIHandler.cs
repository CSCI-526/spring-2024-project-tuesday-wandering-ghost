using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
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
}
