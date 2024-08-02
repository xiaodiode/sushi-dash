using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
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
        if(collision.gameObject.GetComponent<CustomerMovement>() != null){
            Time.timeScale = 0;
            customerSpawner.gameOver = true;
            gameManager.gameOver();
            Destroy(collision.gameObject);
        }
    }
}
