using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SushiBuff : MonoBehaviour
{
    private Button button;
    public string sushiName;
    private int level;
    private string rarity, buffDescription;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
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
    public void setSushiName(string newSushiName){
        sushiName = newSushiName;
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

    public void setSushiDescription(){
        
    }
}
