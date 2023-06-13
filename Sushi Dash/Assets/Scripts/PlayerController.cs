using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PlayerController : MonoBehaviour
{
    //movement variables
    private float horizontalInput,verticalInput;
    private float moveStep,tableX,yLimit;

    //player attributes
    private bool hasSushi;
    private SushiMovement heldSushi, chosenSushi, thrownSushi;
    public int playerLevel=1;
    public int playerCoins=0;

    //sushi stall and table variables
    public GameObject[] upgradeArrows;
    public Tilemap sushiMap,plateMap;
    public Sprite[] sushi;
    public Tile plate;
    private Vector3Int[,] tablePositions;
    private int currTable, currTableLvl;
    private Vector3 heldSushiOffset = new Vector3(0.1f,0,0);
    private Vector3 forwardOffset = new Vector3(0,0,1);
    private Vector3 tempScale = new Vector3();
    int flag=0;
    
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
            if(Input.GetKeyDown(KeyCode.Space) && hasSushi){
                thrownSushi = Instantiate(heldSushi, heldSushi.transform.position, heldSushi.transform.rotation);
                SushiMovement sushiScript = thrownSushi.GetComponent<SushiMovement>();
                sushiScript.enabled = true;
                Debug.Log("heldSushi: " + heldSushi);
                heldSushi.destroy();
                thrownSushi.spin = true;
                Debug.Log("thrownSushi: " + thrownSushi + " " + thrownSushi.spin);
                hasSushi = false;
            }
        }

    }
    void playerMovement(){
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)){
            if(transform.position.x+moveStep <= tableX)
                transform.position=new Vector3(transform.position.x+moveStep,transform.position.y,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)){
            if(transform.position.x-moveStep > 2)
                transform.position=new Vector3(transform.position.x-moveStep,transform.position.y,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)){
            if(transform.position.y+moveStep <= 0)
                transform.position=new Vector3(transform.position.x,transform.position.y+moveStep,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)){
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
}
