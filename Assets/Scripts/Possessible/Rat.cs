using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Rat : MonoBehaviour
{
    // Start is called before the first frame update
    public string type = "Rat";
    public MaskControllerTest maskControllerTest;
    private UnityEngine.Color highLight = new UnityEngine.Color(0.7f, 1, 0.7f);
    private UnityEngine.Color deHighLight = new UnityEngine.Color(1, 1, 1);
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            //ShrinkRat();
            MaskChange();
        }
        else
        {
            //NormalRat();
        }
    }
    public string GetType()
    {
        return type;
    }

    void MaskChange()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            maskControllerTest.StopShrinking();
            maskControllerTest.SetFixedMaskSize();

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = highLight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = deHighLight;
        }
    }
    //void ShrinkRat()
    //{
    //    // Rat scale to size that can pass the narrow path
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        transform.localScale = new Vector3(1, 1, 1);
    //    }
    //}

    //void NormalRat()
    //{
    //    transform.localScale = new Vector3(1f, 1f, 1);
    //}
}
