using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiSpot : MonoBehaviour
{
    //public Sprite[] sushiImages;
    private List<Sprite> sushiSprites = new List<Sprite>();
    private KeyPressButton[] sushiButtons;
    private Sprite sushiTrigger;
    private SpriteRenderer spriteRenderer;
    private int randomSushiIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        sushiButtons = GameObject.FindObjectsOfType<KeyPressButton>();
        foreach(KeyPressButton button in sushiButtons){
            Image sushiImage = button.transform.Find("SushiImage").GetComponent<Image>();
            sushiSprites.Add(sushiImage.sprite);
        }
        randomSushiIndex = Random.Range(0,sushiSprites.Count);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.sprite = sushiSprites[randomSushiIndex];

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
