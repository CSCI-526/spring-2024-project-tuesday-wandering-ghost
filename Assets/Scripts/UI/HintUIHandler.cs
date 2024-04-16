using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintUIHandler : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float displayDistance = 5.00f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        textMesh.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < displayDistance)
        {
            textMesh.enabled = true;
        }
        else
        {
            textMesh.enabled = false;
        }
    }
}
