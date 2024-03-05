using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    float cooldownTime = 2f;

    public GameObject cannotEnterUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (key1.activeInHierarchy && key2.activeInHierarchy && key3.activeInHierarchy)
        {
            Destroy(this.gameObject);
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
