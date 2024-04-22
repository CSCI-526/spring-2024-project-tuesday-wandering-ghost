using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    public MaskControllerTest maskControllerTest;
    public AudioClip soundClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayClip(soundClip);
        }

        if (maskControllerTest != null)
        {
            maskControllerTest.IncreaseMaxPressCount();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}