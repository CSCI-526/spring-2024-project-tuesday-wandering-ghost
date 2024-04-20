using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GateSpider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject key;
    float cooldownTime = 2f;
    public GameObject cannotEnterUI;
    SpriteRenderer gateSR;
    public Sprite gateSprite;
    private BoxCollider2D gateCollider;
    void Start()
    {
        gateSR = gameObject.GetComponent<SpriteRenderer>();
        gateCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (key.activeInHierarchy)
        {
            gateSR.sprite = gateSprite;
            gateCollider.enabled = false;
        }
        else
        {
            cannotEnterUI.gameObject.SetActive(true);
            StartCoroutine(DeactivateAfterTime(cooldownTime));
        }
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        cannotEnterUI.gameObject.SetActive(false);
    }
}
