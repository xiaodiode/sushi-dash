using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    public GameObject[] customers;
    public CustomerSpawner customerSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject == customers[0] || collision.gameObject == customers[1]
        || collision.gameObject == customers[2]){
            customerSpawner.gameOver = true;
            Destroy(collision.gameObject);
        }
    }
}
