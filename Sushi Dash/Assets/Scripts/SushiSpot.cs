using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpot : MonoBehaviour
{
    public Sprite[] sushiImages;
    private Sprite sushiTrigger;
    private SpriteRenderer spriteRenderer;
    private int randomSushiIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        randomSushiIndex = Random.Range(0,sushiImages.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.sprite = sushiImages[randomSushiIndex];

        sushiTrigger = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy(){
        Destroy(gameObject);
    }
    public Sprite getSushiTrigger(){
        return sushiTrigger;
    }
}
