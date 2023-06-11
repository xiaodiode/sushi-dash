using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalInput,verticalInput;
    private float moveStep,xLimit,yLimit;
    //private bool hasSushi;
    public int playerLevel=1;
    public int playerCoins;
    public GameObject canvas;
    public GameObject[] upgradeArrows;
    public Tilemap sushiMap;
    public Tilemap plateMap;
    public Sprite[] sushi;
    public Tile plate;
    private Vector3Int[,] tablePositions;
    private int currTable, currTableLvl;
    
    void Start()
    {
        //hasSushi=false;
        playerCoins=0;
        moveStep=3;
        xLimit=6;
        yLimit=(playerLevel*(-3))- 3;
        canvas.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        if(Math.Round(transform.position.x)==6){
            if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("This is the player table level: " + currTableLvl);
                Debug.Log("This is the player table: " + currTable);
            }
        }
    }
    void playerMovement(){
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)){
            if(transform.position.x+moveStep <= xLimit)
                transform.position=new Vector3(transform.position.x+moveStep,transform.position.y,transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)){
            if(transform.position.x-moveStep > -xLimit)
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
}
