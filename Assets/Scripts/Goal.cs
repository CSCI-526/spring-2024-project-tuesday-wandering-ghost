using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winPanel;
    public PlayerController playerController;
    public FirebaseDataCollect firebaseData;
    public MaskControllerTest maskControllerTest;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
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

        // post data to firebase
        firebaseData.FinishLevel();

        // stop shrinking
        maskControllerTest.StopShrinking();
    }
}
