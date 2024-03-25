using System;
using System.Collections.Generic;
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
    public List<string> roomVisits = new List<string>();
    public int restartBtnUsedTime = 0;
}

public class GameData
{
    public static LevelData NoDataToCollect = new()
    {
        levelName = "NoDataToCollect",
    };
    
    // public static LevelData LevelTutorial = new LevelData
    // {
    //     levelID = "Level0",
    //     levelName = "LevelTutorial",
    // };
    
    public static LevelData LevelOne = new()
    {
        levelID = "Level1",
        levelName = "LevelOne",
        
        rooms = new[]
        {
            new RoomData
            {
                roomID = "Room1",
                roomName = "Rat",
                roomRange = new[]
                {
                    new Vector2(-8, 4),       //top left
                    new Vector2(8, 4),        //top right
                    new Vector2(-8, -4),      //bottom left
                    new Vector2(8, -4)        //bottom right
                }
            },
        
            new RoomData
            {
                roomID = "Room2",
                roomName = "Skelefton",
                roomRange = new[]
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
                roomName = "Dog",
                roomRange = new[]
                {
                    new Vector2(-8, 17),
                    new Vector2(1, 17),
                    new Vector2(-8, 12),
                    new Vector2(1, 12)
                }
            },
        }
    };
    
    public static LevelData LevelTwo = new()
    {
        levelID = "Level2",
        levelName = "LevelTwo",
        
        rooms = new[]
        {
            new RoomData
            {
                roomID = "Room1",
                roomName = "Init",
                roomRange = new[]
                {
                    new Vector2(-3, 3),       //top left
                    new Vector2(4, 3),        //top right
                    new Vector2(-3, -2),      //bottom left
                    new Vector2(4, -2)        //bottom right
                }
            },
        
            new RoomData
            {
                roomID = "Room2",
                roomName = "Chest",
                roomRange = new[]
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
                roomName = "Left",
                roomRange = new[]
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
                roomName = "Gate",
                roomRange = new[]
                {
                    new Vector2(-6, 23),
                    new Vector2(7, 23),
                    new Vector2(-6, 17),
                    new Vector2(7, 17)
                }
            },
        }
    };
    
    public static LevelData LevelThree = new()
    {
        levelID = "Level3",
        levelName = "LevelThree",
        
        rooms = new[]
        {
            new RoomData
            {
                roomID = "Room1",
                roomName = "Init",
                roomRange = new[]
                {
                    new Vector2(-13, 14),       //top left
                    new Vector2(14, 14),        //top right
                    new Vector2(-13, -12),      //bottom left
                    new Vector2(14, -12)        //bottom right
                }
            },
        
            new RoomData
            {
                roomID = "Room2",
                roomName = "TopLeft",   //rat
                roomRange = new[]
                {
                    new Vector2(-16, 21),
                    new Vector2(-9, 21),
                    new Vector2(-16, 17),
                    new Vector2(-9, 17)
                }
            },
            
            new RoomData
            {
                roomID = "Room2",
                roomName = "TopLeft",   //switch
                roomRange = new[]
                {
                    new Vector2(-26, 28),
                    new Vector2(-19, 28),
                    new Vector2(-26, 23),
                    new Vector2(-19, 23)
                }
            },
            
            new RoomData
            {
                roomID = "Room3",
                roomName = "TopRight",  //fruit
                roomRange = new[]
                {
                    new Vector2(10, 21),
                    new Vector2(17, 21),
                    new Vector2(10, 17),
                    new Vector2(17, 17)
                }
            },
            
            new RoomData
            {
                roomID = "Room3",
                roomName = "TopRight",  // switch
                roomRange = new[]
                {
                    new Vector2(20, 28),    //TL
                    new Vector2(27, 28),    //TR
                    new Vector2(20, 23),    //BL
                    new Vector2(27, 23)     //BR
                }
            },
            
            new RoomData
            {
                roomID = "Room4",
                roomName = "BottomLeft",   //spider
                roomRange = new[]
                {
                    new Vector2(-16, -15),
                    new Vector2(-9, -15),
                    new Vector2(-16, -19),
                    new Vector2(-9, -19)
                }
            },
            
            new RoomData
            {
                roomID = "Room4",
                roomName = "BottomLeft",   //switch
                roomRange = new[]
                {
                    new Vector2(-26, -22),
                    new Vector2(-19, -22),
                    new Vector2(-26, -27),
                    new Vector2(-19, -27)
                }
            },
            
            new RoomData
            {
                roomID = "Room5",
                roomName = "BottomRight",   //skeleton
                roomRange = new[]
                {
                    new Vector2(10, -15),
                    new Vector2(17, -15),
                    new Vector2(10, -19),
                    new Vector2(17, -19)
                }
            },
            
            new RoomData
            {
                roomID = "Room5",
                roomName = "BottomRight",   //switch
                roomRange = new[]
                {
                    new Vector2(20, -21),
                    new Vector2(27, -21),
                    new Vector2(20, -26),
                    new Vector2(27, -26)
                }
            },
        }
    };
}
