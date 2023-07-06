using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SushiBuff : MonoBehaviour
{
    private Button button;
    public string sushiName;
    public int level;
    public string rarity, buffDescription;
    public float baseBuff, buffRate;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        level = 0;
        buffDescription = "Skill: ";

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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSushiName(string newSushiName){
        sushiName = newSushiName;
    }

    private void salmonBuff(){
        baseBuff = .01f;
        buffRate = .01f;
        rarity = "Common";
        buffDescription = "Speed up the sushi-making progress by <color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";
    }
    private void tunaBuff(){
        rarity = "Common";
    }
    private void eggBuff(){
        rarity = "Common";
    }

    public void setSushiDescription(){
        
    }
}
