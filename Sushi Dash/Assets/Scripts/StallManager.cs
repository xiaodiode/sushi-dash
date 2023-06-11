using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class StallManager : MonoBehaviour
{
    public Tile plate,sushi;
    public GameObject upgradeArrow;
    public Tilemap plateMap,sushiMap;
    public int tableNum;
    public Slider stallProgress;
    public PlayerController player;

    private Vector3Int[] platePositions = new Vector3Int[4];
    private int tableLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
        int tableLeft = 2;
        int tableRight = 3;
        int tableYOffset = -3;
        int tableTop = tableNum*tableYOffset;
        int tableBot = (tableNum*tableYOffset)-1;
        platePositions[0] = new Vector3Int(tableLeft,tableTop,0);
        platePositions[1] = new Vector3Int(tableLeft,tableBot,0);
        platePositions[2] = new Vector3Int(tableRight,tableTop,0);
        platePositions[3] = new Vector3Int(tableRight,tableBot,0);

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
                    plateMap.SetTile(platePositions[tableLevel],plate);
                }
            }
        }
        
        updateTable();
        
        
    }
    
    /*
        The nearest empty position is found on the table and triggers
        the sushi stall's progress bar to make another sushi. 
        The new sushi will be placed at the given empty position
    */
    void runSushiMaker(Vector3Int position){
        //gradually fill the sushi stall's progress bar
        stallProgress.gameObject.SetActive(true);
        stallProgress.value+=0.0002f;

        //when progress bar is maxed, place the appropriate sushi at the open position
        if(stallProgress.value==1){
            sushiMap.SetTile(position, sushi);
            stallProgress.value=0;
        }
    }

    /*
        Checks the table for any empty plates based on level. If an empty
        position is found, the sushi maker and its progress bar are triggered
    */
    void updateTable(){
        if(tableLevel==0){
            if(sushiMap.GetTile(platePositions[0])!=sushi){ 
                runSushiMaker(platePositions[0]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
        else if(tableLevel==1){
            if(sushiMap.GetTile(platePositions[0])!=sushi){ 
                runSushiMaker(platePositions[0]);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushi){
                runSushiMaker(platePositions[1]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
        else if(tableLevel==2){
            if(sushiMap.GetTile(platePositions[0])!=sushi){ 
                runSushiMaker(platePositions[0]);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushi){
                runSushiMaker(platePositions[1]);
            }
            else if(sushiMap.GetTile(platePositions[2])!=sushi){
                runSushiMaker(platePositions[2]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
        else if(tableLevel==3){
            if(sushiMap.GetTile(platePositions[0])!=sushi){ 
                runSushiMaker(platePositions[0]);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushi){
                runSushiMaker(platePositions[1]);
            }
            else if(sushiMap.GetTile(platePositions[2])!=sushi){
                runSushiMaker(platePositions[2]);
            }
            else if(sushiMap.GetTile(platePositions[3])!=sushi){
                runSushiMaker(platePositions[3]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
    }

}
