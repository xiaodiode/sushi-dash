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
    
    private int orderNum;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnCustomer",2,2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnCustomer(){
        randomLaneIndex = Random.Range(0,lanes.Length);
        randomCustomerIndex = Random.Range(0,customerTypes.Length);
        orderNum = randomCustomerIndex+1;

        Vector3 spawnPos = new Vector3(-16,lanes[randomLaneIndex],0);
        GameObject customer = (customerTypes[randomCustomerIndex]);

        
    }

    private GameObject getComponentByName(GameObject gameObject, string componentName){
        GameObject[] components = gameObject.GetComponentsInChildren<GameObject>(true);
        foreach(GameObject component in components){
            if(component.name == componentName){
                return component;
            }
        }
        return null;
    }
}
// GameObject instantiatedObject = Instantiate(prefab);

//         // Access the desired component of the instantiated object
//         SomeComponent component = instantiatedObject.GetComponent<SomeComponent>();