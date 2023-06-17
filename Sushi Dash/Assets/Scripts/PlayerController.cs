using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PlayerController : MonoBehaviour
{
    public Camera gameCamera;

    //movement variables
    private float horizontalInput,verticalInput;
    private float moveStep,tableX,yLimit;

    //player attributes
    private bool hasSushi;
    private SushiMovement heldSushi, chosenSushi, thrownSushi;
    public int playerLevel=1;
    public int playerCoins=0;

    //sushi stall and table variables
    // public GameObject[] upgradeArrows;
    // public Tilemap sushiMap,plateMap;
    // public Sprite[] sushi;
    public StallManager[] tables;
    // public Tile plate;
    // private Vector3Int[,] tablePositions;
    // private int currTable, currTableLvl;
    private Vector3 heldSushiOffset = new Vector3(0.1f,0,0);
    // private Vector3 forwardOffset = new Vector3(0,0,1);
    // private Vector3 tempScale = new Vector3();
    private Vector2 startTouchPosition, endTouchPosition;
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public bool sushiAction;

    private Vector3 touchPosition, gamePosition;
    private Touch touch;
    public Vector3 currentWorldTouch;
    
    
    void Start()
    {
        thrownSushi = null;
        tableX = 6;
        yLimit = (playerLevel*(-3))- 3;

        
        chosenSushi = null;
        hasSushi = false;
        moveStep = 3;
    }

    // Update is called once per frame
    void Update()
    {
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;

        sushiAction = false;

        

        playerMovement();


        if(hasSushi && chosenSushi!=null){
            heldSushi = Instantiate(chosenSushi,transform.position + heldSushiOffset - transform.forward,chosenSushi.transform.rotation);
            SushiMovement sushiScript = heldSushi.GetComponent<SushiMovement>();
            sushiScript.enabled = false;
            chosenSushi = null;
        }
        else if(hasSushi){
            if(Math.Round(transform.position.x)==tableX){
                heldSushi.transform.position = transform.position + heldSushiOffset - transform.forward;
            }
            else{
                heldSushi.transform.position = transform.position - heldSushiOffset - transform.forward;
            }
        }
        if(Math.Round(transform.position.x)==tableX){
            if(Input.GetKeyDown(KeyCode.Space)){
                // Debug.Log("This is the player table level: " + currTableLvl);
                // Debug.Log("This is the player table: " + currTable);
            }
        }
        else{
            if((Input.GetKeyDown(KeyCode.Space) || sushiAction) && hasSushi){
                thrownSushi = Instantiate(heldSushi, heldSushi.transform.position, heldSushi.transform.rotation);
                SushiMovement sushiScript = thrownSushi.GetComponent<SushiMovement>();
                sushiScript.enabled = true;
                Debug.Log("heldSushi: " + heldSushi);
                heldSushi.destroy();
                hasSushi = false;
            }
        }

    }
    void playerMovement(){
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");

        //touch input
        if(Input.touchCount>0){
            touch = Input.GetTouch(0);
        }

        if(Input.touchCount > 0 && touch.phase == TouchPhase.Began){
            startTouchPosition = touch.position;
            currentWorldTouch = convertTouchToWorld(startTouchPosition);
            if(currentWorldTouch.x >= 6.5 && currentWorldTouch.x <= 10.5){
                if(currentWorldTouch.y >= -1 && currentWorldTouch.y <= 1){
                    tables[0].upgradeAction = true;
                }
                else if(currentWorldTouch.y >= -4 && currentWorldTouch.y <= -2){
                    tables[1].upgradeAction = true;
                }
                else if(currentWorldTouch.y >= -7 && currentWorldTouch.y <= -5){
                    tables[2].upgradeAction = true;
                }
            }
        }
        
        if(Input.touchCount > 0 && touch.phase == TouchPhase.Ended){
            endTouchPosition = touch.position;
            touchPosition = convertTouchToWorld(startTouchPosition);
            if(touchPosition.x > 2 ){
                //if the swipe is more horizontal than vertical
                if((Math.Abs(endTouchPosition.x - startTouchPosition.x)) > (Math.Abs(endTouchPosition.y - startTouchPosition.y))){
                    if(endTouchPosition.x < startTouchPosition.x){
                        swipeLeft = true;
                        swipeRight = false; 
                        swipeUp = false;
                        swipeDown = false;
                        sushiAction = false;
                    }
                    else if(endTouchPosition.x > startTouchPosition.x){
                        swipeLeft = false;
                        swipeRight = true; 
                        swipeUp = false;
                        swipeDown = false;
                        sushiAction = false;
                    }
                }
                else{
                    if(TouchPhase.Began != TouchPhase.Ended){
                        if(endTouchPosition.y < startTouchPosition.y){
                            swipeLeft = false;
                            swipeRight = false; 
                            swipeUp = false;
                            swipeDown = true;
                            sushiAction = false;
                        }
                        else if(endTouchPosition.y > startTouchPosition.y){
                            swipeLeft = false;
                            swipeRight = false; 
                            swipeUp = true;
                            swipeDown = false;
                            sushiAction = false;
                        }
                    }
                }
            }
            else{
                swipeLeft = false;
                swipeRight = false; 
                swipeUp = false;
                swipeDown = false;
                sushiAction = true;
                Debug.Log("sushiAction: " + sushiAction + " currentWorldTouch.x: " + currentWorldTouch.x);
            }
        }
        


        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)||swipeRight){
            if(transform.position.x+moveStep <= tableX)
                transform.position=new Vector3(transform.position.x+moveStep,transform.position.y,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)||swipeLeft){
            if(transform.position.x-moveStep > 2)
                transform.position=new Vector3(transform.position.x-moveStep,transform.position.y,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)||swipeUp){
            if(transform.position.y+moveStep <= 0)
                transform.position=new Vector3(transform.position.x,transform.position.y+moveStep,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)||swipeDown){
            if(transform.position.y-moveStep >= yLimit)
                transform.position=new Vector3(transform.position.x,transform.position.y-moveStep,transform.position.z);
        }
        
        // transform.Translate(Vector3.right*horizontalInput*Time.deltaTime*speed);
        // transform.Translate(Vector3.up*verticalInput*Time.deltaTime*speed);
    }

    public void setHasSushi(bool boolean){
        hasSushi = boolean;
    }
    public bool getHasSushi(){
        return hasSushi;
    }
    public void setChosenSushi(SushiMovement currSushi){
        chosenSushi = currSushi;
    }
    public Vector3 convertTouchToWorld(Vector3 touchPosition){
        Vector3 touchPos = new Vector3(touchPosition.x, touchPosition.y, gameCamera.nearClipPlane);
        gamePosition = gameCamera.ScreenToWorldPoint(touchPos);

        return gamePosition;
    }
}
