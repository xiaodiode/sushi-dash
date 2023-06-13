using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerTypes;
    private CustomerMovement customer;
    public bool gameOver;
    
    private int[] lanes = {0,-3,-6};
    private int randomLaneIndex;
    private int randomCustomerIndex;
    private float startSpawnTime = 2;
    private float repeatRate = 8;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCustomer",startSpawnTime,repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameOver){
            CancelInvoke("spawnCustomer");
        }
        
    }

    void spawnCustomer(){
        randomLaneIndex = Random.Range(0,lanes.Length);
        randomCustomerIndex = Random.Range(0,customerTypes.Length);

        Vector3 spawnPos = new Vector3(-20,lanes[randomLaneIndex],0);
        GameObject customerType = (customerTypes[randomCustomerIndex]);

        Instantiate(customerType,spawnPos,customerType.transform.rotation);
    }

}
// GameObject instantiatedObject = Instantiate(prefab);

//         // Access the desired component of the instantiated object
//         SomeComponent component = instantiatedObject.GetComponent<SomeComponent>();