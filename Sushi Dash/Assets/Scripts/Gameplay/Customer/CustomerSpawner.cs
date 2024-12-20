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
    public Timer timer;
    public Sprite freezeSushi, completionSushi, confusionSushi;
    
    
    public Vector3 customerNormSpeed;
    public Vector3 customerReturnSpeed;
    private int[] lanes = {0,-3,-6};
    private int randomLaneIndex;
    private int randomCustomerIndex;
    private float spawnXPosition = -30;
    private float startSpawnTime = 4f;
    private float repeatRate, customerBaseSpeed;
    private bool speedFlag = true;
    private bool rateFlag = true;
    private int totalCoins;
    private Vector3 endlessSpeedIncrease = new Vector3(0.05f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // startSpawnTime = 4f;
        // repeatRate = 2f;
        // customerBaseSpeed = 2f;
        //InvokeRepeating("spawnCustomer",startSpawnTime,repeatRate);
        
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
        if(gameManager.endlessMode){
            if(rateFlag && timer.getGameTime()>0 && timer.getGameTime()%30 == 0 && timer.getGameTime() < 601){
                rateFlag = false;
                customerNormSpeed += endlessSpeedIncrease;
                Debug.Log("new customerSpeed: " + customerNormSpeed);
                
            }
            else if(timer.getGameTime()>0 && timer.getGameTime()%30 != 0){
                rateFlag = true;
            }
            if(speedFlag && timer.getGameTime()>0 && timer.getGameTime()%20 == 0 && timer.getGameTime() < 401){
                speedFlag = false;
                CancelInvoke("spawnCustomer");
                repeatRate -= 0.1f;
                InvokeRepeating("spawnCustomer",0.01f,repeatRate);
                Debug.Log("new spawningRate: " + repeatRate);
                
            }
            else if(timer.getGameTime()>0 && timer.getGameTime()%20 != 0){
                speedFlag = true;
            }
        }
        
    }

    void spawnCustomer(){
        randomLaneIndex = Random.Range(0,lanes.Length);
        randomCustomerIndex = Random.Range(0,customerTypes.Length);

        Vector3 spawnPos = new Vector3(spawnXPosition,lanes[randomLaneIndex],0);
        CustomerMovement customerType = (customerTypes[randomCustomerIndex]);

        customer = Instantiate(customerType,spawnPos,customerType.transform.rotation);
        customer.speedRate = customerNormSpeed;
        customer.transform.parent = transform;
        customer.timer = timer;
        customer.freezeSushi = freezeSushi;
        customer.completionSushi = completionSushi;
        customer.confusionSushi = confusionSushi;
    }

    public void updateCoins(int coins){
        totalCoins += coins;
    }
    private void setCoins(){
        player.playerCoins = totalCoins;
    }
    public void resetCustomerSpawner(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
        totalCoins = 0;
        gameOver = false;
        CancelInvoke("spawnCustomer");
        // gameObject.SetActive(false);
    }
    public void startCustomerSpawner(){
        InvokeRepeating("spawnCustomer",startSpawnTime,repeatRate);
    }

    public void applyCoinBuff(int buff){
        totalCoins = buff;
        Debug.Log("playerCoins: " + totalCoins);
    }
    public void applySlowBuff(float buff){
        customerNormSpeed = new Vector3(customerBaseSpeed - buff, 0, 0);
    }
    public void initializeCustomerSpeed(float newRepeatRate, float newCustomerBaseSpeed){
        repeatRate = newRepeatRate;
        customerBaseSpeed = newCustomerBaseSpeed;
        Debug.Log("repeatRate: " + repeatRate + " customerBaseSpeed: " + customerBaseSpeed);
    }

}