using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sushiGacha : MonoBehaviour
{
    
    public GachaPopup gachaPopup;
    public SushiConversions sushiConversions;
    public Sprite[] common, uncommon, rare;
    public Customizer gachaItem;
    public InventorySpawner contentSpawner;
    private SushiBuff[] sushiBuffs;
    private Sprite randomSprite;
    private Button button;
    int commonChance = 6; int uncommonChance = 3; int rareChance = 1;
    private List<string> rarityPicker = new List<string>();
    private List<Sprite> inInventory = new List<Sprite>();
    private bool addToInventory;
    private string randomRarity, imageName;
    private int randomRarityIndex;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<commonChance; i++){
            rarityPicker.Add("common");
        }
        for(int i=0; i<uncommonChance; i++){
            rarityPicker.Add("uncommon");
        }
        for(int i=0; i<rareChance; i++){
            rarityPicker.Add("rare");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void runSushiGacha(){
        imageName = "Image_S"; 
        addToInventory = false;
        randomRarityIndex = Random.Range(0,rarityPicker.Count);
        randomRarity = rarityPicker[randomRarityIndex];
        if(randomRarity == "common"){
            randomRarityIndex = Random.Range(0,common.Length);
            randomSprite = common[randomRarityIndex];
            
            if(!inInventory.Contains(randomSprite)){
                inInventory.Add(randomSprite);
                addToInventory = true;
            }
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            
            
        }
        else if(randomRarity == "uncommon"){
            if(uncommon.Length!=0){
                randomRarityIndex = Random.Range(0,uncommon.Length);
                randomSprite = uncommon[randomRarityIndex];
                if(!inInventory.Contains(randomSprite)){
                    inInventory.Add(randomSprite);
                    addToInventory = true;
                }
                gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            }
        }
        else{
            if(rare.Length!=0){
                randomRarityIndex = Random.Range(0,rare.Length);
                randomSprite = rare[randomRarityIndex];
                if(!inInventory.Contains(randomSprite)){
                    inInventory.Add(randomSprite);
                    addToInventory = true;
                }
                gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            }
        }
        SushiBuff currBuff = gachaItem.transform.GetComponent<SushiBuff>();
        string sushiName = sushiConversions.getSushiName(randomSprite);
        currBuff.setSushiName(sushiName);

        gachaPopup.sushi.sprite = randomSprite;
        gachaPopup.background.gameObject.SetActive(false);
        gachaPopup.foreground.gameObject.SetActive(false);
        gachaPopup.sushi.gameObject.SetActive(true);

        if(addToInventory){
            contentSpawner.setInventoryObject(gachaItem);
            contentSpawner.createButton();
            sushiBuffs = GameObject.FindObjectsOfType<SushiBuff>();
            foreach(SushiBuff sushiBuff in sushiBuffs){
                if(sushiBuff.sushiName == gachaItem.transform.GetComponent<SushiBuff>().sushiName){
                    gachaPopup.gachaItemText.text = sushiBuff.sushiName + "\nRarity: " + sushiBuff.rarity +
                            "\nLevel: 1 \n\nSushi Buff: " + sushiBuff.buffDescription;
                }
            }
        }
        else{
            Debug.Log("did not add to inventory -- " + randomSprite);
            sushiBuffs = GameObject.FindObjectsOfType<SushiBuff>();
            foreach(SushiBuff sushiBuff in sushiBuffs){
                if(sushiBuff.sushiName == gachaItem.transform.GetComponent<SushiBuff>().sushiName){
                    if(sushiBuff.level!=9){
                        sushiBuff.increaseLevel();
                        gachaPopup.gachaItemText.text = sushiBuff.sushiName + "\nRarity: " + sushiBuff.rarity +
                            "\n<color=red>Level: " + (sushiBuff.level+1).ToString() + "</color>\n\nSushi Buff: " + sushiBuff.buffDescription;
                    }
                }
            }
                
            
        }
        
        gachaPopup.enablePopup();
    }
}
