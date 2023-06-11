using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class StallManager : MonoBehaviour
{
    public Tile plate;
    public Tile sushi;
    public GameObject upgradeArrow;
    public Tilemap plateMap;
    public Tilemap sushiMap;
    public int playerCoins;
    public int tableNum;
    public Slider stallProgress;
    public PlayerController player;

    private Vector3Int[] positions = new Vector3Int[4];
    private int tableLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //tableLevel = 1;
        positions[0] = new Vector3Int(2,tableNum*(-3),0);
        positions[1] = new Vector3Int(2,tableNum*(-3)-1,0);
        positions[2] = new Vector3Int(3,tableNum*(-3),0);
        positions[3] = new Vector3Int(3,tableNum*(-3)-1,0);

        //tableLevel = (int)player.tableLevels[tableNum];
        tableLevel=0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if((int)(Math.Round(player.transform.position.x))==6 && (int)(Math.Round(player.transform.position.y))==(tableNum*(-3))){
            if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){

                if(upgradeArrow.activeSelf && tableLevel<=2){
                    tableLevel++;
                    plateMap.SetTile(positions[tableLevel],plate);
                }
            }
        }
        
        
        if(tableLevel==0){
            if(sushiMap.GetTile(positions[0])!=sushi){ //if first plate is empty, fill with sushi
                updateStall(positions[0]);
                //Debug.Log("platemap: " + plateMap.GetTile(position1) + "sushimap: " + sushiMap.GetTile(position1));
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
        else if(tableLevel==1){
            //Debug.Log("platemap: " + plateMap.GetTile(position2) + "sushimap: " + sushiMap.GetTile(position2));
            if(sushiMap.GetTile(positions[0])!=sushi){ //if first plate is empty, fill with sushi
                updateStall(positions[0]);
                //Debug.Log("platemap: " + plateMap.GetTile(position1) + "sushimap: " + sushiMap.GetTile(position1));
            }
            else if(sushiMap.GetTile(positions[1])!=sushi){
                updateStall(positions[1]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
        else if(tableLevel==2){
            if(sushiMap.GetTile(positions[0])!=sushi){ //if first plate is empty, fill with sushi
                updateStall(positions[0]);
                //Debug.Log("platemap: " + plateMap.GetTile(position1) + "sushimap: " + sushiMap.GetTile(position1));
            }
            else if(sushiMap.GetTile(positions[1])!=sushi){
                updateStall(positions[1]);
            }
            else if(sushiMap.GetTile(positions[2])!=sushi){
                updateStall(positions[2]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
        else if(tableLevel==3){
            if(sushiMap.GetTile(positions[0])!=sushi){ //if first plate is empty, fill with sushi
                updateStall(positions[0]);
                //Debug.Log("platemap: " + plateMap.GetTile(position1) + "sushimap: " + sushiMap.GetTile(position1));
            }
            else if(sushiMap.GetTile(positions[1])!=sushi){
                updateStall(positions[1]);
            }
            else if(sushiMap.GetTile(positions[2])!=sushi){
                updateStall(positions[2]);
            }
            else if(sushiMap.GetTile(positions[3])!=sushi){
                updateStall(positions[3]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
            // if((sushiMap.GetTile(position1)==sushi)&&)
            //     stallProgress.gameObject.SetActive(false);
            // //} 
        
        else if(sushiMap.GetTile(positions[0])!=sushi || (tableLevel==1 && sushiMap.GetTile(positions[1])!=sushi) || 
        (tableLevel==2 && sushiMap.GetTile(positions[2])!=sushi) || (tableLevel==3 && sushiMap.GetTile(positions[3])!=sushi)){
            stallProgress.gameObject.SetActive(true);
            stallProgress.value+=0.0002f;
        }    
    }
    void updateStall(Vector3Int position){
        stallProgress.gameObject.SetActive(true);
        stallProgress.value+=0.0002f;
        if(stallProgress.value==1){
            sushiMap.SetTile(position, sushi);
            stallProgress.value=0;
        }
    }

}
