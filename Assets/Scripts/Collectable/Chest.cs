using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite openSprite;
    SpriteRenderer chestSR;
    public GameObject key1;
    void Start()
    {
        chestSR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //chestSR.sprite = openSprite;
        Destroy(this.gameObject);
        key1.gameObject.SetActive(true);
    }
}
