using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winPanel;
    PlayerController playerController;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player"); // 确保你的玩家游戏对象被标记为"Player"
        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winPanel.SetActive(true);
        playerController.SetPlayerMovement(false);
    }
}
