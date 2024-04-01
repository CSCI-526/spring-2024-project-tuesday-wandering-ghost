using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer trigger;
    public GameObject obstacle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Deactivate();
    }

    void Deactivate()
    {
        if (trigger.color == Color.green)
        {
            obstacle.SetActive(false);
        }
    }
}
