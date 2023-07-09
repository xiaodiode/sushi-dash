using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    
    public bool gameOver;
    private Checkmark checkmark1, checkmark2, checkmark3;
    private SushiSpot sushi1,sushi2,sushi3;
    
    private Collider2D myCollider;
    public Vector3 speedRate;
    private int xMin = -31;
    
    // private int randomSushiIndex;
    private int customerType;
    // private float speed = 2f;
    private CustomerSpawner customerSpawner;
    void Start()
    {
        customerSpawner = GetComponentInParent<CustomerSpawner>();
        gameOver = false;
        myCollider = GetComponent<Collider2D>();

        checkmark1 = getCheckmarkByName(gameObject,"Checkmark1");
        checkmark2 = getCheckmarkByName(gameObject,"Checkmark2");
        checkmark3 = getCheckmarkByName(gameObject,"Checkmark3");

        sushi1 = getSushiByName(gameObject, "Sushi1");
        sushi2 = getSushiByName(gameObject, "Sushi2");
        sushi3 = getSushiByName(gameObject, "Sushi3");

        
        checkmark1.enable(false);
        customerType = 1;
        
        if(checkmark2 != null){
            checkmark2.enable(false);
            customerType = 2;
        }
        if(checkmark3 != null){
            checkmark3.enable(false);
            customerType = 3; 
        }
        
        Debug.Log("speedRate: " + speedRate);

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > xMin)
            transform.position = transform.position + speedRate*Time.deltaTime;
        else    
            Destroy(gameObject);
        
    }
    private Checkmark getCheckmarkByName(GameObject gameObject, string componentName){
        Checkmark[] components = gameObject.GetComponentsInChildren<Checkmark>(true);
        foreach(Checkmark component in components){
            if(component.name == componentName){
                return component;
            }
        }
        return null;
    }
    private SushiSpot getSushiByName(GameObject gameObject, string componentName){
        SushiSpot[] components = gameObject.GetComponentsInChildren<SushiSpot>(true);
        foreach(SushiSpot component in components){
            if(component.name == componentName){
                return component;
            }
        }
        return null;
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(customerType==1){
            // Debug.Log("collision.gameObject.GetComponent<SpriteRenderer>(): " + collision.gameObject.GetComponent<SpriteRenderer>().sprite + " sushi trigger: " + sushi1.getSushiTrigger());
            if((collision.gameObject.GetComponent<SpriteRenderer>().sprite == sushi1.getSushiTrigger()) && !checkmark1.isEnabled()){
                checkmark1.enable(true);
                speedRate = -speedRate;
                myCollider.enabled = false;
                Destroy(collision.gameObject);
                customerSpawner.updateCoins(10);
            }
        }
        else if(customerType == 2){
            if((collision.gameObject.GetComponent<SpriteRenderer>().sprite == sushi1.getSushiTrigger()) && !checkmark1.isEnabled()){
                checkmark1.enable(true);
                Destroy(collision.gameObject);
            }
            else if((collision.gameObject.GetComponent<SpriteRenderer>().sprite == sushi2.getSushiTrigger()) && !checkmark2.isEnabled()){
                checkmark2.enable(true);
                Destroy(collision.gameObject);
            }
            if(checkmark1.isEnabled() && checkmark2.isEnabled()){
                speedRate = -speedRate;
                myCollider.enabled = false;
                Destroy(collision.gameObject);
                customerSpawner.updateCoins(20);
            }
        }
        else if(customerType == 3){
            if((collision.gameObject.GetComponent<SpriteRenderer>().sprite == sushi1.getSushiTrigger()) && !checkmark1.isEnabled()){
                checkmark1.enable(true);
                Destroy(collision.gameObject);
            }
            else if((collision.gameObject.GetComponent<SpriteRenderer>().sprite == sushi2.getSushiTrigger()) && !checkmark2.isEnabled()){
                checkmark2.enable(true);
                Destroy(collision.gameObject);
            }
            else if((collision.gameObject.GetComponent<SpriteRenderer>().sprite == sushi3.getSushiTrigger()) && !checkmark3.isEnabled()){
                checkmark3.enable(true);
                Destroy(collision.gameObject);
            }
            if(checkmark1.isEnabled() && checkmark2.isEnabled() && checkmark3.isEnabled()){
                speedRate = -speedRate;
                myCollider.enabled = false;
                Destroy(collision.gameObject);
                customerSpawner.updateCoins(30);
            }
        }
    }
    
    
}
