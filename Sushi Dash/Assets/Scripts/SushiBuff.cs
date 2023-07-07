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
    // Start is called before the first frame update
    void Start()
    {
        level = 0;

        // switch(sushiName){
        //     case "Salmon Nigiri":
        //         salmonBuff();
        //         break;
        //     case "Tuna Nigiri":
        //         tunaBuff();
        //         break;
        //     case "Egg Nigiri":
        //         eggBuff();
        //         break;
        // }

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
    }
    private void tunaBuff(){
        baseBuff = 5;
        buffRate = 5;
        rarity = "Common";
        buffDescription = "Start each game with <color=red>\n" + (baseBuff + (buffRate*level)).ToString() + 
        "</color> coins (+" + (buffRate).ToString() + " coins / level)";

    }
    private void eggBuff(){
        baseBuff = .01f;
        buffRate = .01f;
        rarity = "Common";
        buffDescription = "Slow down customers' walking speed by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";
    }

    public void setSushiDescription(){
        
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
