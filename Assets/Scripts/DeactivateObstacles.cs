using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject triggerOnChild;
    public GameObject obstacle;
    void Start()
    {
        // triggerOnChild = transform.Find("Trigger_on").gameObject;
        triggerOnChild = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Deactivate();
    }

    void Deactivate()
    {
        if (triggerOnChild.activeSelf)
        {
            obstacle.SetActive(false);
        }
    }
}
