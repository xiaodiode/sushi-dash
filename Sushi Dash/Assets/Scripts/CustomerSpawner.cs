using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public CustomerMovement[] customerTypes;
    private CustomerMovement customer;
    public PlayerController player;
    public bool gameOver;
    
    private int[] lanes = {0,-3,-6};
    private int randomLaneIndex;
    private int randomCustomerIndex;
    private float startSpawnTime = 2;
    private float repeatRate = 8;

    private int totalCoins;
    

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        InvokeRepeating("spawnCustomer",startSpawnTime,repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
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