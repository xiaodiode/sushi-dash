using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public CustomerMovement[] customerTypes;
    private CustomerMovement customer;
    public PlayerController player;
    public bool gameOver;
    
    private int[] lanes = {0,-3,-6};
    private int randomLaneIndex;
    private int randomCustomerIndex;
    private float startSpawnTime = 5;
    private float repeatRate = 10;

    private int totalCoins;

    int stop = 0; int initialize = 1; int proceed = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameMode == proceed)
            InvokeRepeating("spawnCustomer",startSpawnTime,repeatRate);
        if(gameOver){
            CancelInvoke("spawnCustomer");
        }
        if(player.playerCoins != totalCoins){
            setCoins();
        }
        
    }

    void spawnCustomer(){
        randomLaneIndex = Random.Range(0,lanes.Length);
        randomCustomerIndex = Random.Range(0,customerTypes.Length);

        Vector3 spawnPos = new Vector3(-20,lanes[randomLaneIndex],0);
        CustomerMovement customerType = (customerTypes[randomCustomerIndex]);

        customer = Instantiate(customerType,spawnPos,customerType.transform.rotation);

        customer.transform.parent = transform;
    }

    public void updateCoins(int coins){
        totalCoins += coins;
    }
    private void setCoins(){
        player.playerCoins = totalCoins;
    }

}