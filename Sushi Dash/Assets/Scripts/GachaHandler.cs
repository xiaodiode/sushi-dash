using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaHandler : MonoBehaviour
{
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
                Debug.Log("sushiName: " + sushiName);
                sushiBuff.setSushiName(sushiName);
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
        }
        else{
            Debug.Log("did not add to inventory -- " + randomSprite);
        }
        
    }
}
