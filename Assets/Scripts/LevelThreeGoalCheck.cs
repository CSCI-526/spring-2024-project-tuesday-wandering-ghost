using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelThreeGoalCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer[] triggers;
    public GameObject goalPortals;
    private List<GameObject> triggerOnChildren;

    void Start()
    {
        triggerOnChildren = new List<GameObject>();
        
        foreach (SpriteRenderer v in triggers)
        {
            Transform triggerOnTransform = v.transform.Find("Trigger_on");
            triggerOnChildren.Add(triggerOnTransform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
    }

    bool CheckStatus()
    {
        foreach (GameObject v in triggerOnChildren) {
            if (!v.activeSelf)
            {
                return false;
            }
        }
        goalPortals.SetActive(true);
        return true;
    }
}
