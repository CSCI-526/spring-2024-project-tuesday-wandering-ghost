using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.SceneManagement;


public class FirebaseDataCollect : MonoBehaviour
{
    private string firebaseURL = "https://wandering-ghost-default-rtdb.firebaseio.com";
    private RoomData currentRoom = null;
    private LevelData currentLevel = null;
    private System.Diagnostics.Stopwatch levelTimer = new System.Diagnostics.Stopwatch();
    private System.Diagnostics.Stopwatch roomTimer = new System.Diagnostics.Stopwatch();
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Firebase start working.");

        player = GameObject.Find("Ghost");
        
        Scene currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case "LevelOne":
                currentLevel = GameData.LevelOne;
                break;
            case "LevelTwo":
                currentLevel = GameData.LevelTwo;
                break;
            case "LevelTutorial":
                currentLevel = GameData.LevelTutorial;
                break;
            default:
                currentLevel = GameData.NoDataToCollect;
                break;
        }
        levelTimer.Start();
    }

    
    // Update is called once per frame
    void Update()
    {
        switch (currentLevel.levelName)
        {
            case "NoDataToCollect":
                return;
            case "LevelTutorial":
                // tutorial only collect total level time
                break;
            case "LevelOne":
            case "LevelTwo":
                Vector2 playerPosition = player.transform.position;
                CheckPlayerLocation(playerPosition);
                break;
        }
    }
    
    void OnApplicationQuit()
    {
        // post the data anyways
        FinishLevel(false);
        // PostLevelData(currentLevel, isFinish: false);
    }
    
    
    private void CheckPlayerLocation(Vector2 playerPosition)
    {
        foreach (var room in currentLevel.rooms)
        {
            if (IsInRoom(playerPosition, room.roomRange))
            {
                if (currentRoom == null || currentRoom.roomName != room.roomName)
                {
                    if (currentRoom != null)
                    {
                        ExitRoom();  // exit form previous
                    }
                    EnterRoom(room); // enter new
                }
                return;
            }
        }
        
        // if no room matches, consider the player is outside any room
        if (currentRoom != null)
        {
            ExitRoom();  // exit from current
        }
    }
    
    private bool IsInRoom(Vector2 position, Vector2[] corners)
    {
        return position.x >= corners[0].x && position.x <= corners[1].x && position.y >= corners[2].y && position.y <= corners[0].y;
    }
    

    private void EnterRoom(RoomData room)
    {
        // Debug.Log("enter room: " + room.roomName);
        currentRoom = room;
        roomTimer.Restart();  // starts or restarts timer
    }
    

    private void ExitRoom()
    {
        // Debug.Log("exit room: " + currentRoom.roomName + "\n location: " + player.transform.position.x + ", "+ player.transform.position.y);
        if (currentRoom != null)
        {
            roomTimer.Stop();
            float timeSpent = (float)roomTimer.Elapsed.TotalSeconds;
            currentRoom.timeSpent += timeSpent;  // update current room's timer
        }
        currentRoom = null;  // reset when exiting
    }
    

    public void FinishLevel(bool isFinish = true)
    {
        levelTimer.Stop();
        float totalTime = (float)levelTimer.Elapsed.TotalSeconds;
        currentLevel.totalTimeSpent += totalTime;
        currentLevel.isFinish = isFinish;
        PostLevelData(currentLevel, isFinish);
        // Debug.Log("Post:" + player.transform.position.x + ", "+ player.transform.position.y);
    }
    
    private void PostLevelData(LevelData levelData, bool isFinish = true)
    {
        RestClient.Post(isFinish ? $"{firebaseURL}/Finish/.json" : $"{firebaseURL}/UnFinish/.json", levelData);
    }


}
