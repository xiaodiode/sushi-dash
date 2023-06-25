using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    public GameObject[] customers;
    public CustomerSpawner customerSpawner;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Collided with: " + collision);
        if(collision.gameObject.GetComponent<CustomerMovement>() != null){
            Time.timeScale = 0;
            customerSpawner.gameOver = true;
            Debug.Log("collided");
            gameManager.gameOver();
            Destroy(collision.gameObject);

            
        }
    }
}
