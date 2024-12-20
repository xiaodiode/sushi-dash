using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaHandler : MonoBehaviour
{
    private SushiBuff[] sushiBuffs;
    public GachaPopup gachaPopup;
    public SushiConversions sushiConversions;
    public Sprite[] common, uncommon, rare;
    public Customizer gachaItem;
    public InventorySpawner contentSpawner;
    private Sprite randomSprite;
    private Button button;
    int commonChance = 6; int uncommonChance = 3; int rareChance = 1;
    private List<string> rarityPicker = new List<string>();
    private List<Sprite> inInventory = new List<Sprite>();
    private bool addToInventory;
    private string randomRarity, imageName;
    // Start is called before the first frame update
    void Start()
    {
        

        button = gameObject.transform.GetComponent<Button>();
        for(int i=0; i<commonChance; i++){
            rarityPicker.Add("common");
        }
        for(int i=0; i<uncommonChance; i++){
            rarityPicker.Add("uncommon");
        }
        for(int i=0; i<rareChance; i++){
            rarityPicker.Add("rare");
        }


        if(gachaItem.CompareTag("sushi")){
            imageName = "Image_S";        
        }
        else if(gachaItem.CompareTag("background")){
            imageName = "Image_B";
        }
        else if(gachaItem.CompareTag("foreground")){
            imageName = "Image_F";
        }

        button.onClick.AddListener(setInventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sushiGacha(){
        
    }
    private void setInventory(){
        addToInventory = false;
        int randomRarityIndex = Random.Range(0,rarityPicker.Count);
        randomRarity = rarityPicker[randomRarityIndex];
        if(randomRarity == "common"){
            randomRarityIndex = Random.Range(0,common.Length);
            randomSprite = common[randomRarityIndex];
            
            if(!inInventory.Contains(randomSprite)){
                inInventory.Add(randomSprite);
                addToInventory = true;
            }
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            if(gachaItem.CompareTag("sushi")){
                SushiBuff sushiBuff = gachaItem.transform.GetComponent<SushiBuff>();
                string sushiName = sushiConversions.getSushiName(randomSprite);
                sushiBuff.setSushiName(sushiName);

                gachaPopup.sushi.sprite = randomSprite;
                gachaPopup.background.gameObject.SetActive(false);
                gachaPopup.foreground.gameObject.SetActive(false);
                gachaPopup.sushi.gameObject.SetActive(true);

                // if(addToInventory){
                //     gachaPopup.gachaItemText.text = sushiBuff.sushiName + "\nRarity: " + sushiBuff.rarity +
                //         "\nLevel: 1 \n\nSushi Buff: " + sushiBuff.buffDescription;
                // }
                // else{
                //     sushiBuff.increaseLevel();
                //     gachaPopup.gachaItemText.text = sushiBuff.sushiName + "\nRarity: " + sushiBuff.rarity +
                //         "\n<color=red>Level: " + (sushiBuff.level+1).ToString() + "</color>\n\nSushi Buff: " + sushiBuff.buffDescription;
                // }
            }
            else if(gachaItem.CompareTag("background")){
                gachaPopup.background.sprite = randomSprite;
                gachaPopup.background.gameObject.SetActive(true);
                gachaPopup.foreground.gameObject.SetActive(false);
                gachaPopup.sushi.gameObject.SetActive(false);
            }
            else{
                gachaPopup.foreground.sprite = randomSprite;
                gachaPopup.background.gameObject.SetActive(false);
                gachaPopup.foreground.gameObject.SetActive(true);
                gachaPopup.sushi.gameObject.SetActive(false);
            }
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
        if(addToInventory){
            contentSpawner.setInventoryObject(gachaItem);
            contentSpawner.createButton();
            if(gachaItem.CompareTag("sushi")){
                sushiBuffs = GameObject.FindObjectsOfType<SushiBuff>();
                foreach(SushiBuff sushiBuff in sushiBuffs){
                    if(sushiBuff.sushiName == gachaItem.transform.GetComponent<SushiBuff>().sushiName){
                        gachaPopup.gachaItemText.text = sushiBuff.sushiName + "\nRarity: " + sushiBuff.rarity +
                                "\nLevel: 1 \n\nSushi Buff: " + sushiBuff.buffDescription;
                    }
                }
            }
        }
        else{
            Debug.Log("did not add to inventory -- " + randomSprite);
            if(gachaItem.CompareTag("sushi")){
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
        }
        
        gachaPopup.enablePopup();
    }
}
