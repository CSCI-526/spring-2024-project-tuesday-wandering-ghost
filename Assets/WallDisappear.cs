using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallDisappear : MonoBehaviour
{
    public Tilemap tilemapToDisable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bone>() != null)
        {
            if (tilemapToDisable != null)
            {
                TilemapRenderer rendererToDisable = tilemapToDisable.GetComponent<TilemapRenderer>();
                if (rendererToDisable != null)
                {
                    rendererToDisable.enabled = false;
                }
                TilemapCollider2D colliderToDisable = tilemapToDisable.GetComponent<TilemapCollider2D>();
                if (colliderToDisable != null)
                {
                    colliderToDisable.enabled = false;
                }
            }
        }
    }

}
