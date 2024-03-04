using System;
using UnityEngine;

[Serializable]
public class RoomData
{
    public string roomName;
    public float timeSpent = 0;
    public Vector2[] roomRange;
}

[Serializable]
public class LevelData
{
    public string levelID;
    public string levelName;
    public float totalTimeSpent = 0;
    public bool isFinish = false;
    public RoomData[] rooms;
}

public class GameData
{
    public static LevelData NoDataToCollect = new LevelData
    {
        levelName = "NoDataToCollect",
    };
    
    public static LevelData LevelTutorial = new LevelData
    {
        levelID = "Level0",
        levelName = "LevelTutorial",
    };
    
    public static LevelData LevelOne = new LevelData
    {
        levelID = "Level1",
        levelName = "LevelOne",
        
        rooms = new RoomData[]
        {
            new RoomData
            {
                roomName = "RoomRat",
                roomRange = new Vector2[]
                {
                    new Vector2(-8, 4),       //top let
                    new Vector2(8, 4),        //top right
                    new Vector2(-8, -4),      //bottom let
                    new Vector2(8, -4)        //bottom right
                }
            },
        
            new RoomData
            {
                roomName = "RoomSkeleton",
                roomRange = new Vector2[]
                {
                    new Vector2(4, 14),
                    new Vector2(8, 14),
                    new Vector2(4, 9),
                    new Vector2(8, 9)
                }
            },
            
            new RoomData
            {
                roomName = "RoomDog",
                roomRange = new Vector2[]
                {
                    new Vector2(-8, 17),
                    new Vector2(1, 17),
                    new Vector2(-8, 12),
                    new Vector2(1, 12)
                }
            },
        }
    };
}
