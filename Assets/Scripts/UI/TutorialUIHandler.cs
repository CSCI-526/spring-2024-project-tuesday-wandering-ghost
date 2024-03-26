using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIHandler : MonoBehaviour
{
    public GameObject viewAlertTextUI;
    public SpriteMask mask;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // show view alert when less than half of the original
        viewAlertTextUI.SetActive(mask.transform.localScale.x < 10);
    }
}
