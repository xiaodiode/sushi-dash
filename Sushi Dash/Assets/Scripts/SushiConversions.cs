using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SushiConversions : MonoBehaviour
{
    public Tile[] sushiTiles;
    public SushiMovement[] sushiObjects;
    public Sprite[] sushiSprites;
    private IDictionary<Sprite, Tile> spriteToTile = new Dictionary<Sprite, Tile>();
    private IDictionary<Sprite, SushiMovement> spriteToObject = new Dictionary<Sprite, SushiMovement>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<sushiTiles.Length; i++){
            spriteToTile.Add(sushiSprites[i], sushiTiles[i]);
            spriteToObject.Add(sushiSprites[i], sushiObjects[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tile getSushiTile(Sprite sushi){
        return spriteToTile[sushi];
    }
    public SushiMovement getSushiObject(Sprite sushi){
        return spriteToObject[sushi];
    }
}
