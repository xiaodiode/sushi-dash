using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerTypes;
    
    
    private GameObject checkmark1,checkmark2,checkmark3;
    
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
        
    }

    void spawnCustomer(){
        randomLaneIndex = Random.Range(0,lanes.Length);
        randomCustomerIndex = Random.Range(0,customerTypes.Length);

        Vector3 spawnPos = new Vector3(-20,lanes[randomLaneIndex],0);
        GameObject customer = (customerTypes[randomCustomerIndex]);

        Instantiate(customer,spawnPos,customer.transform.rotation);

        
    }

}
// GameObject instantiatedObject = Instantiate(prefab);

//         // Access the desired component of the instantiated object
//         SomeComponent component = instantiatedObject.GetComponent<SomeComponent>();