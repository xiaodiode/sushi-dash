using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class StallManager : MonoBehaviour
{
    public Image sushiImage;
    private Sprite sushiSprite;
    public SushiConversions sushiConversions;
    public GameManager gameManager;
    public Tile plate;
    private Tile sushiTile;
    public GameObject upgradeArrow;
    private SushiMovement sushiObject;
    public Tilemap plateMap,sushiMap;
    public CustomerSpawner customerSpawner;
    public int tableNum;
    public Slider stallProgress;
    public PlayerController player;

    private Vector3Int[] platePositions = new Vector3Int[4];
    
    private int tableLevel;
    private int sushiPosition;
    //private float progressSpeed = 0.07f;
    public bool upgradeAction;
    private float progressSpeed=0.5f;

    int tableLeft = 2;
    int tableRight = 3;
    int tableYOffset = -3;
        
    
    // Start is called before the first frame update
    void Start()
    {
        sushiSprite = sushiImage.sprite;
        sushiTile = sushiConversions.getSushiTile(sushiSprite);
        sushiObject = sushiConversions.getSushiObject(sushiSprite);
        
        upgradeAction = false;
        int tableTop = tableNum*tableYOffset;
        int tableBot = (tableNum*tableYOffset)-1;
        platePositions[0] = new Vector3Int(tableLeft,tableTop,0);
        platePositions[1] = new Vector3Int(tableLeft,tableBot,0);
        platePositions[2] = new Vector3Int(tableRight,tableTop,0);
        platePositions[3] = new Vector3Int(tableRight,tableBot,0);

        tableLevel = 0;


        upgradeArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameMode == gameManager.proceed){
            if(player.playerCoins >= 50 && tableLevel != 3){
                upgradeArrow.SetActive(true);
            }
            else{
                upgradeArrow.SetActive(false);
            }
            
            if(upgradeAction){
                upgradeAction = false;
                if(upgradeArrow.activeSelf && tableLevel<=2){
                    tableLevel++;
                    customerSpawner.updateCoins(-50);
                    plateMap.SetTile(platePositions[tableLevel],plate);
                    
                }
            }
            if((int)(Math.Round(player.transform.position.x))==6 && 
            (int)(Math.Round(player.transform.position.y))==(tableNum*(tableYOffset))){
                    //upgrade the stall when SHIFT is pressed
                if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){
                    upgradeAction = false;
                    if(upgradeArrow.activeSelf && tableLevel<=2){
                        tableLevel++;
                        customerSpawner.updateCoins(-50);
                        plateMap.SetTile(platePositions[tableLevel],plate);
                        
                    }
                }
                //pick up any available sushi from stall when SPACE is pressed as long as player is not holding anything
                if((Input.GetKeyDown(KeyCode.Space)  || player.sushiAction) && player.getHasSushi()==false){
                    sushiPosition = getSushiPosition();
                    if(sushiPosition != -1){
                        sushiMap.SetTile(platePositions[sushiPosition],plate);
                        player.setChosenSushi(sushiObject);
                        player.setHasSushi(true);
                    }
                    else{
                        player.setHasSushi(false);
                    }
                }
            }
            
            checkEmptyPlates();
        }
        
        
    }
    
    /*
        The nearest empty position is found on the table and triggers
        the sushi stall's progress bar to make another sushi. 
        The new sushi will be placed at the given empty position
    */
    void runSushiMaker(Vector3Int position){
        //gradually fill the sushi stall's progress bar
        stallProgress.gameObject.SetActive(true);
        stallProgress.value += progressSpeed;

        //when progress bar is maxed, place the appropriate sushi at the open position
        if(stallProgress.value==100){
            sushiMap.SetTile(position, sushiTile);
            stallProgress.value=0;
        }
    }

    /*
        Checks the table for any empty plates based on level. If an empty
        position is found, the sushi maker and its progress bar are triggered
    */
    void checkEmptyPlates(){
        if(tableLevel==0){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                runSushiMaker(platePositions[0]);
            }
            else{
                stallProgress.gameObject.SetActive(false);
            }
        }
        else if(tableLevel==1){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                runSushiMaker(platePositions[0]);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushiTile){
                runSushiMaker(platePositions[1]);
            }
            else{
                stallProgress.gameObject.SetActive(false);

            }
        }
        else if(tableLevel==2){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                runSushiMaker(platePositions[0]);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushiTile){
                runSushiMaker(platePositions[1]);
            }
            else if(sushiMap.GetTile(platePositions[2])!=sushiTile){
                runSushiMaker(platePositions[2]);
            }
            else{
                sushiPosition=2;
                stallProgress.gameObject.SetActive(false);
            }
        }
        else if(tableLevel==3){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                runSushiMaker(platePositions[0]);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushiTile){
                runSushiMaker(platePositions[1]);
            }
            else if(sushiMap.GetTile(platePositions[2])!=sushiTile){
                runSushiMaker(platePositions[2]);
            }
            else if(sushiMap.GetTile(platePositions[3])!=sushiTile){
                runSushiMaker(platePositions[3]);
            }
            else
                stallProgress.gameObject.SetActive(false);
        }
    }
    int getSushiPosition(){
        if(tableLevel==0){
            if(sushiMap.GetTile(platePositions[0])==sushiTile)
                return 0;
            else
                return -1;
        }

        else if(tableLevel==1){
            if(sushiMap.GetTile(platePositions[0])==sushiTile)
                return 0;
            else if(sushiMap.GetTile(platePositions[1])==sushiTile)
                return 1;
            else
                return -1;
        }

        else if(tableLevel==2){
            if(sushiMap.GetTile(platePositions[0])==sushiTile)
                return 0;
            else if(sushiMap.GetTile(platePositions[1])==sushiTile)
                return 1;
            else if(sushiMap.GetTile(platePositions[2])==sushiTile)
                return 2;
            else
                return -1;
        }

        else if(tableLevel==3){
            if(sushiMap.GetTile(platePositions[0])==sushiTile)
                return 0;
            else if(sushiMap.GetTile(platePositions[1])==sushiTile)
                return 1;
            else if(sushiMap.GetTile(platePositions[2])==sushiTile)
                return 2;
            else if(sushiMap.GetTile(platePositions[3])==sushiTile)
                return 3;
            else
                return -1;
        }
        return -1;
    }
    
    public void resetStallManager(){
        tableLevel = 0;

        upgradeAction = false;
        upgradeArrow.SetActive(false);

        stallProgress.gameObject.SetActive(false);
        stallProgress.value = 0;

        for(int i=0; i<platePositions.Length; i++){
            sushiMap.SetTile(platePositions[i], null);
            plateMap.SetTile(platePositions[i], null);
        }

        plateMap.SetTile(platePositions[0], plate);
        
    }

}
