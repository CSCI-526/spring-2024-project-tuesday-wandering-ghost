using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeGoalCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer[] triggers;
    public GameObject goalPortals;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
    }

    bool CheckStatus()
    {
        foreach (SpriteRenderer v in triggers) {
            if (v.color != Color.green)
            {
                return false;
            }
        }
        goalPortals.SetActive(true);
        return true;
    }
}
