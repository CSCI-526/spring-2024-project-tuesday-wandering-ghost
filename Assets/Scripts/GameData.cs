using System;
using UnityEngine;

[Serializable]
public class RoomData
{
    public string roomID;
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
                roomID = "Room1",
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
                roomID = "Room2",
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
                roomID = "Room3",
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
    
    public static LevelData LevelTwo = new LevelData
    {
        levelID = "Level2",
        levelName = "LevelTwo",
        
        rooms = new RoomData[]
        {
            new RoomData
            {
                roomID = "Room1",
                roomName = "RoomInit",
                roomRange = new Vector2[]
                {
                    new Vector2(-3, 3),       //top let
                    new Vector2(4, 3),        //top right
                    new Vector2(-3, -2),      //bottom let
                    new Vector2(4, -2)        //bottom right
                }
            },
        
            new RoomData
            {
                roomID = "Room2",
                roomName = "RoomChest",
                roomRange = new Vector2[]
                {
                    new Vector2(7, 13),
                    new Vector2(15, 13),
                    new Vector2(7, 5),
                    new Vector2(15, 5)
                }
            },
            
            new RoomData
            {
                roomID = "Room3",
                roomName = "RoomLeft",
                roomRange = new Vector2[]
                {
                    new Vector2(-10, 12),
                    new Vector2(-7, 12),
                    new Vector2(-10, 7),
                    new Vector2(-7, 7)
                }
            },
            
            new RoomData
            {
                roomID = "Room4",
                roomName = "RoomGate",
                roomRange = new Vector2[]
                {
                    new Vector2(-6, 23),
                    new Vector2(7, 23),
                    new Vector2(-6, 17),
                    new Vector2(7, 17)
                }
            },
        }
    };
}
