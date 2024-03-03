using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStatus : MonoBehaviour
{
    // Start is called before the first frame update
    int lightNum = 1;
    public GameObject chest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightNum == 4)
        {
            chest.gameObject.SetActive(true);
        }
    }

    public void increaseNum()
    {
        lightNum++;
    }
}
