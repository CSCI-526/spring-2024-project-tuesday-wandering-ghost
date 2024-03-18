using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject torch;
    SpriteRenderer torchSR;
    void Start()
    {
        torchSR = torch.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (torchSR != null)
        {
            if (torchSR.sprite.name == "Torch_Light")
            {
                gameObject.SetActive(false);
            }
        }

    }
}
