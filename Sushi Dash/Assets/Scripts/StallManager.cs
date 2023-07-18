using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class StallManager : MonoBehaviour
{
    public ActiveBuffs activeBuffs;
    public InventorySpawner inventorySpawner;
    public Image sushiImage;
    public Image newSushiImage;
    public Button sushiButton;
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
    private float baseProgressTime = 2.75f;
    private float actualProgressTime;
    private float startTime, passedTime, progress, progressUpdating;

    int tableLeft = 2;
    int tableRight = 3;
    int tableYOffset = -3;

    private SpriteRenderer outButton, inButton;
    Color color;
    float darken = .5f; float lighten = 1f;
        
    
    // Start is called before the first frame update
    void Start()
    {
        newSushiImage = null;
        //wait for dictionary to completely fill before setting private variables
        StartCoroutine(WaitForDictionary());
        //mainMenuCanvas = gameObject.transform.Find("MainMenu Canvas").GetComponent<Canvas>();

        progressUpdating = 0;
        
        outButton = sushiButton.transform.Find("OuterButton").GetComponent<SpriteRenderer>();
        inButton = outButton.transform.Find("InnerButton").GetComponent<SpriteRenderer>();

        enableUI(false);
        upgradeAction = false;

        int tableTop = tableNum*tableYOffset;
        int tableBot = (tableNum*tableYOffset)-1;
        platePositions[0] = new Vector3Int(tableLeft,tableTop,0);
        platePositions[1] = new Vector3Int(tableLeft,tableBot,0);
        platePositions[2] = new Vector3Int(tableRight,tableTop,0);
        platePositions[3] = new Vector3Int(tableRight,tableBot,0);

        tableLevel = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.inEditMode == true){
            enableUI(true);
        }
        if(gameManager.gameMode == gameManager.proceed){
            if(player.playerCoins >= 50 && tableLevel != 3){
                enableUI(true);
            }
            else{
                enableUI(false);
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
        else if(gameManager.gameMode == gameManager.stop){
            stallProgress.value = 0;
            progressUpdating = 0;
        }
        
        
    }
    
    /*
        Makes sure the sushi tile and sushi object dictionaries are 
        completely filled and ready to use before calling them to 
        initialize the respective stall manager variables.
    */
    private IEnumerator WaitForDictionary(){
        while(!sushiConversions.dictionaryReady){
            yield return null;
        }
        sushiSprite = sushiImage.sprite;
        sushiTile = sushiConversions.getSushiTile(sushiSprite);
        sushiObject = sushiConversions.getSushiObject(sushiSprite);
        // Debug.Log("sushiSprite: " + sushiSprite + " sushiTile: " + sushiTile + " sushiObject: " + sushiObject);
    }

    private void enableUI(bool enable){
        if(!enable){
            color = outButton.color;
            color.a = darken;
            outButton.color = color;

            color = inButton.color;
            color.a = darken;
            inButton.color = color;

            color = sushiImage.color;
            color.a = darken;
            sushiImage.color = color;
            
            upgradeArrow.SetActive(false);
        }
        else{
            color = outButton.color;
            color.a = lighten;
            outButton.color = color;

            color = inButton.color;
            color.a = lighten;
            inButton.color = color;

            color = sushiImage.color;
            color.a = lighten;
            sushiImage.color = color;
            
            if(!gameManager.inEditMode)
                upgradeArrow.SetActive(true);
            else   
                upgradeArrow.SetActive(false);
        }
    }

    /*
        The nearest empty position is found on the table and triggers
        the sushi stall's progress bar to make another sushi. 
        The new sushi will be placed at the given empty position
    */
    void runSushiMaker(Vector3Int position, float timeStarted){
        
        //when progress bar is maxed, place the appropriate sushi at the open position
        if(stallProgress.value==100){
            sushiMap.SetTile(position, sushiTile);
            stallProgress.value=0;
            progressUpdating = 0;
        }
        else{
            progressUpdating = 1;
            passedTime = Time.time - timeStarted;
            progress = Mathf.Clamp01(passedTime/actualProgressTime);
            //gradually fill the sushi stall's progress bar
            stallProgress.gameObject.SetActive(true);
            stallProgress.value = progress * 100;
        }
        
    }



    /*
        Checks the table for any empty plates based on level. If an empty
        position is found, the sushi maker and its progress bar are triggered
    */
    void checkEmptyPlates(){
        if(tableLevel==0){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[0], startTime);
            }
            else{
                stallProgress.gameObject.SetActive(false);
            }
        }
        else if(tableLevel==1){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[0], startTime);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushiTile){
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[1], startTime);
            }
            else{
                stallProgress.gameObject.SetActive(false);

            }
        }
        else if(tableLevel==2){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[0], startTime);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushiTile){
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[1], startTime);
            }
            else if(sushiMap.GetTile(platePositions[2])!=sushiTile){
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[2], startTime);
            }
            else{
                sushiPosition=2;
                stallProgress.gameObject.SetActive(false);
            }
        }
        else if(tableLevel==3){
            if(sushiMap.GetTile(platePositions[0])!=sushiTile){ 
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[0], startTime);
            }
            else if(sushiMap.GetTile(platePositions[1])!=sushiTile){
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[1], startTime);
            }
            else if(sushiMap.GetTile(platePositions[2])!=sushiTile){
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[2], startTime);
            }
            else if(sushiMap.GetTile(platePositions[3])!=sushiTile){
                if(progressUpdating == 0 ){
                    startTime = Time.time;
                }
                runSushiMaker(platePositions[3], startTime);
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
        enableUI(false);

        stallProgress.gameObject.SetActive(false);
        stallProgress.value = 0;

        for(int i=0; i<platePositions.Length; i++){
            sushiMap.SetTile(platePositions[i], null);
            plateMap.SetTile(platePositions[i], null);
        }

        plateMap.SetTile(platePositions[0], plate);
        
    }

    public void sushiButtonPressed(){
        if(gameManager.gameMode != gameManager.stop){
           if(upgradeArrow.activeSelf){
                upgradeAction = true;
            } 
        }
        else{
            if(newSushiImage != null){
                sushiImage.sprite = newSushiImage.sprite;
                StartCoroutine(WaitForDictionary());
                for(int i=0; i<inventorySpawner.stallManagers.Length; i++){
                    inventorySpawner.stallManagers[i].newSushiImage = null;
                }
                activeBuffs.updateActiveBuff();
            }
        }
        
    }

    public void applySpeedBuff(float buff){
        actualProgressTime = baseProgressTime - (baseProgressTime*buff);
        //Debug.Log("updated progressTime: " + actualProgressTime);
    }

}
