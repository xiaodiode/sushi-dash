using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveBuffs : MonoBehaviour
{
    public StallManager[] stallManagers;
    public CustomerSpawner customerSpawner;
    private KeyPressButton[] activeBuffs;
    private SushiBuff[] inventoryBuffs;
    private List<Image> activeSushi = new List<Image>();

    private float speedBuff, freezeBuff, completionBuff, killBuff, 
        lifeBuff, levelBuff;
    public float slowBuff;
    private int coinBuff, gemBuff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateActiveBuff(){
        activeBuffs = GameObject.FindObjectsOfType<KeyPressButton>();
        clearBuffs();
        inventoryBuffs = GameObject.FindObjectsOfType<SushiBuff>();
        for(int i=0; i<activeBuffs.Length; i++){
            activeSushi.Add(activeBuffs[i].transform.Find("SushiImage").GetComponent<Image>());
            foreach(SushiBuff sushi in inventoryBuffs){
                Image inventoryImage = sushi.transform.Find("Image_S").GetComponent<Image>();
                if(inventoryImage.sprite == activeSushi[i].sprite){
                    // Debug.Log("found matching buff inventoryImage.sprite: " + inventoryImage.sprite);
                    speedBuff += sushi.speedBuff;
                    freezeBuff += sushi.freezeBuff; 
                    completionBuff += sushi.completionBuff; 
                    slowBuff += sushi.slowBuff; 
                    killBuff += sushi.killBuff; 
                    lifeBuff += sushi.lifeBuff; 
                    levelBuff += sushi.levelBuff;
                    coinBuff += sushi.coinBuff; 
                    gemBuff += sushi.gemBuff;

                }
            }
        }
        for(int i=0; i<stallManagers.Length; i++){
            stallManagers[i].applySpeedBuff(speedBuff);
        }
        customerSpawner.applyCoinBuff(coinBuff);
        customerSpawner.applySlowBuff(slowBuff);
        Debug.Log("activeBuffs: \nspeedBuff: " + speedBuff + "\nfreezeBuff: " + freezeBuff +
            "\ncompletionBuff: " + completionBuff + "\nslowBuff: " + slowBuff + "\nkillBuff: " +
            killBuff + "\nlifeBuff: " + lifeBuff + "\nlevelBuff: " + levelBuff + "\ncoinBuff: " +
            coinBuff + "\ngemBuff: " + gemBuff); 
        
    }

    private void clearBuffs(){
        speedBuff=0; 
        freezeBuff=0; 
        completionBuff=0; 
        slowBuff=0; 
        killBuff=0; 
        lifeBuff=0; 
        levelBuff=0;
        coinBuff=0; 
        gemBuff=0;
    }
}
