using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SushiBuff : MonoBehaviour
{
    public string sushiName;
    public int level;
    public string rarity, buffDescription;
    public float baseBuff, buffRate;

    public float speedBuff, freezeBuff, completionBuff, slowBuff, killBuff, 
        lifeBuff, levelBuff;
    public int coinBuff, gemBuff;
    // Start is called before the first frame update
    void Start()
    {
        speedBuff = 0;
        freezeBuff = 0;
        completionBuff = 0;
        slowBuff = 0;
        killBuff = 0;
        lifeBuff = 0;
        levelBuff = 0;
        coinBuff = 0; 
        gemBuff = 0;

        level = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSushiName(string newSushiName){
        sushiName = newSushiName;
        switch(sushiName){
            case "Salmon Nigiri":
                salmonBuff();
                break;
            case "Tuna Nigiri":
                tunaBuff();
                break;
            case "Egg Nigiri":
                eggBuff();
                break;
        }
    }

    private void salmonBuff(){
        baseBuff = .01f;
        buffRate = .01f;
        rarity = "Common";
        buffDescription = "Speed up the sushi-making progress by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        speedBuff = baseBuff + (buffRate*level);
    }
    private void tunaBuff(){
        baseBuff = 5;
        buffRate = 5;
        rarity = "Common";
        buffDescription = "Start each game with <color=red>\n" + (baseBuff + (buffRate*level)).ToString() + 
        "</color> coins (+" + (buffRate).ToString() + " coins / level)";

        coinBuff = Mathf.FloorToInt(baseBuff + (buffRate*level)); 
    }
    private void eggBuff(){
        baseBuff = .01f;
        buffRate = .01f;
        rarity = "Common";
        buffDescription = "Slow down customers' walking speed by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        slowBuff = baseBuff + (buffRate*level);
    }

    public void increaseLevel(){
        level+=1;
        switch(sushiName){
            case "Salmon Nigiri":
                salmonBuff();
                break;
            case "Tuna Nigiri":
                tunaBuff();
                break;
            case "Egg Nigiri":
                eggBuff();
                break;
        }
    }
}
