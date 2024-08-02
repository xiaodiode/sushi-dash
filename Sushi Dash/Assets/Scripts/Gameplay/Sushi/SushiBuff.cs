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

    public float speedBuff, freezeBuff, completionBuff, slowBuff, 
        lifeBuff, levelBuff, spawnBuff, confusionBuff;
    public int coinBuff, gemBuff;
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void setSushiName(string newSushiName){
        sushiName = newSushiName;
        level = 0;
        rarity = "not set yet";
        buffDescription = "not set yet";

        baseBuff = 0;
        buffRate = 0;

        spawnBuff = 0;
        slowBuff = 0;
        speedBuff = 0;
        freezeBuff = 0;
        completionBuff = 0;
        lifeBuff = 0;
        levelBuff = 0;
        coinBuff = 0; 
        gemBuff = 0;
        confusionBuff = 0;
        
        switch(sushiName){
            case "Low-Quality Salmon Nigiri (Sake)":
                defaultSalmon();
                break;
            
            case "Low-Quality Egg Nigiri (Tamago)":
                defaultEgg();
                break;
            
            case "Low-Quality Tuna Nigiri (Maguro)":
                defaultTuna();
                break;

            case "Crab Stick Nigiri (Kanikama)":
                crabBuff();
                break;
            
            case "Cucumber Roll (Kappamaki)":
                cucumberBuff();
                break;

            case "Eel Nigiri (Unagi)":
                eelBuff();
                break;

            case "Egg Nigiri (Tamago)":
                eggBuff();
                break;

            case "Futomaki":
                futomakiBuff();
                break;
            
            case "Salmon Roe Sushi (Ikura)":
                ikuraBuff();
                break;

            case "Mackerel Nigiri (Saba)":
                mackerel();
                break;

            case "Tuna+Scallion Sushi (Negitoro Gunkan)":
                negitoroBuff();
                break;
            
            case "Octopus Nigiri (Tako)":
                octopusBuff();
                break;

            case "Salmon Nigiri (Sake)":
                salmonBuff();
                break;
            
            case "Sardine Nigiri (Iwashi)":
                sardineBuff();
                break;

            case "Scallop Nigiri (Hotate)":
                scallopBuff();
                break;
            
            case "Shrimp Nigiri (Ebi)":
                shrimpBuff();
                break;

            case "Squid Nigiri (Ika)":
                squidBuff();
                break;
            
            case "Surf Clam Nigiri (Hokkigai)":
                surfBuff();
                break;

            case "Tofu Skin Sushi (Inari)":
                tofuBuff();
                break;

            case "Tuna Nigiri (Maguro)":
                tunaBuff();
                break;
            
            case "Sea Urchin Sushi (Uni)":
                urchinBuff();
                break;
            
            case "Wagyu Beef Nigiri":
                wagyuBuff();
                break;

            case "Yellowtail Nigiri (Hamachi)":
                yellowtailBuff();
                break;

        }
    }
    private void defaultSalmon(){
        rarity = "Default";
        buffDescription = "No buffs";
        
    }
    private void defaultEgg(){
        rarity = "Default";
        buffDescription = "No buffs";
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void defaultTuna(){
        rarity = "Default";
        buffDescription = "No buffs";
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void crabBuff(){
        baseBuff = .01f;
        buffRate = .01f;
        rarity = "<color=green>Common</color>";
        buffDescription = "Slow down the customers' spawn rate by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        spawnBuff = baseBuff + (buffRate*level);
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void cucumberBuff(){
        baseBuff = .32f;
        buffRate = .02f;
        rarity = "<color=purple>Rare</color>";
        buffDescription = "<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "% chance</color> of freezing customers for 2 seconds on contact";

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        freezeBuff = baseBuff + (buffRate*level);;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void eelBuff(){
        baseBuff = 11;
        buffRate = 1;
        rarity = "<color=green>Common</color>";
        buffDescription = "Earn <color=red>" + (baseBuff + (buffRate*level)).ToString() + 
        "</color> bonus gems at the end of each game lasting at least 2 minutes (+" + (buffRate).ToString() + " gems / level)";

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        gemBuff = Mathf.FloorToInt(baseBuff + (buffRate*level)); ;
    }
    private void eggBuff(){
        baseBuff = .01f;
        buffRate = .01f;
        rarity = "<color=green>Common</color>";
        buffDescription = "Slow down customers' walking speed by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        // spawnBuff = 0;
        slowBuff = baseBuff + (buffRate*level);
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void futomakiBuff(){
        baseBuff = .11f;
        buffRate = .01f;
        rarity = "<color=blue>Uncommon</color>";
        buffDescription = "Combo Buff: Start the game with 30 coins, speed the sushi-making progress by 10%," +
        "and slow down customers' walking speed by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        // spawnBuff = 0;
        slowBuff = baseBuff + (buffRate*level);
        speedBuff = .1f;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        coinBuff = 30; 
        // gemBuff = 0;
    }
    private void ikuraBuff(){
        baseBuff = .55f;
        buffRate = .05f;
        rarity = "<color=blue>Uncommon</color>";
        buffDescription = "Survival Buff: Start the game with 50 coins, and get a \n<color=red>" + 
        (100*(baseBuff + (buffRate*level))).ToString() + "% chance</color> of gaining an extra life"
        + " at the start of the game (+" + (100*buffRate).ToString() + "% / level)";

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        lifeBuff = baseBuff + (buffRate*level);
        // levelBuff = 0;
        coinBuff = 50; 
        // gemBuff = 0;
    }
    private void mackerel(){
        baseBuff = .16f;
        buffRate = .01f;
        rarity = "<color=blue>Uncommon</color>";
        buffDescription = "Head Start Buff: Start the game with 150 coins, and speed up the sushi-making progress " + 
        "by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + "%</color> (+" + 
        (100*buffRate).ToString() + "% / level)";

        // spawnBuff = 0;
        // slowBuff = 0;
        speedBuff = baseBuff + (buffRate*level);
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        coinBuff = 150; 
        // gemBuff = 0;
    }
    private void negitoroBuff(){
        baseBuff = .21f;
        buffRate = .01f;
        rarity = "<color=purple>Rare</color>";
        buffDescription = "<color=purple>Special Protein Buff: When fed to a customer, there is a </color>\n<color=red>" + 
        (100*(baseBuff + (buffRate*level))).ToString() + "% chance (+" + 
        (100*buffRate).ToString() + "% / level)</color><color=purple> of completing their entire order</color>" +
        "\nOther Buffs: Slow down both customers' speed and spawn rate by 10% each";

        spawnBuff = .1f;
        slowBuff = .1f;
        // speedBuff = 0;
        // freezeBuff = 0;
        completionBuff = baseBuff + (buffRate*level);
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void octopusBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void salmonBuff(){
        baseBuff = .02f;
        buffRate = .02f;
        rarity = "<color=green>Common</color>";
        buffDescription = "Speed up the sushi-making progress by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        speedBuff = baseBuff + (buffRate*level);
        // freezeBuff = 0;
        // completionBuff = 0;
        // slowBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void sardineBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void scallopBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void shrimpBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void squidBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void surfBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void tofuBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void tunaBuff(){
        baseBuff = 5;
        buffRate = 5;
        rarity = "<color=green>Common</color>";
        buffDescription = "Start each game with <color=red>" + (baseBuff + (buffRate*level)).ToString() + 
        "</color> coins (+" + (buffRate).ToString() + " coins / level)";

        coinBuff = Mathf.FloorToInt(baseBuff + (buffRate*level)); 
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // slowBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0; 
        // gemBuff = 0;
    }
    private void urchinBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    private void wagyuBuff(){
        baseBuff = .02f;
        buffRate = .02f;
        rarity = "<color=green>Common</color>";
        buffDescription = "Speed up the sushi-making progress by \n<color=red>" + (100*(baseBuff + (buffRate*level))).ToString() + 
        "%</color> (+" + (100*buffRate).ToString() + "% / level)";

        speedBuff = baseBuff + (buffRate*level);
        // freezeBuff = 0;
        // completionBuff = 0;
        // slowBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
        confusionBuff = baseBuff + (buffRate*level);
    }
    private void yellowtailBuff(){
        // baseBuff = 0;
        // buffRate = 0;

        // spawnBuff = 0;
        // slowBuff = 0;
        // speedBuff = 0;
        // freezeBuff = 0;
        // completionBuff = 0;
        // lifeBuff = 0;
        // levelBuff = 0;
        // coinBuff = 0; 
        // gemBuff = 0;
    }
    

    public void increaseLevel(){
        level+=1;
        switch(sushiName){
            case "Crab Stick Nigiri (Kanikama)":
                crabBuff();
                break;
            
            case "Cucumber Roll (Kappamaki)":
                cucumberBuff();
                break;

            case "Eel Nigiri (Unagi)":
                eelBuff();
                break;

            case "Egg Nigiri (Tamago)":
                eggBuff();
                break;

            case "Futomaki":
                futomakiBuff();
                break;
            
            case "Salmon Roe Sushi (Ikura)":
                ikuraBuff();
                break;

            case "Mackerel Nigiri (Saba)":
                mackerel();
                break;

            case "Tuna+Scallion Sushi (Negitoro Gunkan)":
                negitoroBuff();
                break;
            
            case "Octopus Nigiri (Tako)":
                octopusBuff();
                break;

            case "Salmon Nigiri (Sake)":
                salmonBuff();
                break;
            
            case "Sardine Nigiri (Iwashi)":
                sardineBuff();
                break;

            case "Scallop Nigiri (Hotate)":
                scallopBuff();
                break;
            
            case "Shrimp Nigiri (Ebi)":
                shrimpBuff();
                break;

            case "Squid Nigiri (Ika)":
                squidBuff();
                break;
            
            case "Surf Clam Nigiri (Hokkigai)":
                surfBuff();
                break;

            case "Tofu Skin Sushi (Inari)":
                tofuBuff();
                break;

            case "Tuna Nigiri (Maguro)":
                tunaBuff();
                break;
            
            case "Sea Urchin Sushi (Uni)":
                urchinBuff();
                break;
            
            case "Wagyu Beef Nigiri":
                wagyuBuff();
                break;

            case "Yellowtail Nigiri (Hamachi)":
                yellowtailBuff();
                break;
        }
    }
}
