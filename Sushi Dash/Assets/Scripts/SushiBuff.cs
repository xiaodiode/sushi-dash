using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SushiBuff : MonoBehaviour
{
    public string sushiName;
    private int level;
    private string rarity, buffDescription;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        buffDescription = "Skill: ";

        switch(sushiName){
            case "salmon":
                salmonBuff();
                break;
            case "tuna":
                tunaBuff();
                break;
            case "egg":
                eggBuff();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void salmonBuff(){
        rarity = "common";
    }
    private void tunaBuff(){
        rarity = "common";
    }
    private void eggBuff(){
        rarity = "common";
    }

}
