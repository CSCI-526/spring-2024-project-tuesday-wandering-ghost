using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject key;
    public Sprite keySprite;
    SpriteRenderer keySR;

    void Start()
    {
        keySR = gameObject.GetComponent<SpriteRenderer>();
        
        // distinguish collectable
        if (keySR.sprite.name == "key-white")
        {
            keySR.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(keySR.sprite.name);
        if (keySR.sprite.name == "key-white") {
            key.SetActive(true);
            Destroy(this.gameObject);
        } else if (keySR.sprite.name == "key_broken" && collision.gameObject.name == "SpiderWeb(Clone)") {
            keySR.sprite = keySprite;
            keySR.color = Color.yellow;
            Destroy(collision.gameObject);
        }
    }
}
