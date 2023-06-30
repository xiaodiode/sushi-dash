using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaHandler : MonoBehaviour
{
    public Sprite[] common, uncommon, rare;
    public checkClick gachaItem;
    public ContentSpawner contentSpawner;
    private Sprite randomSprite;
    private Button button;
    private int commonChance = 6; private int uncommonChance = 3; private int rareChance = 1;
    private List<string> rarityPicker = new List<string>();
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

        for(int i=0; i<rarityPicker.Count; i++){
            Debug.Log("rarityPicker[" + i + "]: " + rarityPicker[i]);
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
        int randomRarityIndex = Random.Range(0,rarityPicker.Count);
        Debug.Log("limit: " + rarityPicker.Count);
        Debug.Log("rarityPicker[limit]: " + rarityPicker[rarityPicker.Count - 1]);
        randomRarity = rarityPicker[randomRarityIndex];
        if(randomRarity == "common"){
            randomRarityIndex = Random.Range(0,common.Length);
            randomSprite = common[randomRarityIndex];
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
        }
        else if(randomRarity == "uncommon"){
            randomRarityIndex = Random.Range(0,uncommon.Length);
            randomSprite = uncommon[randomRarityIndex];
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
        }
        else{
            randomRarityIndex = Random.Range(0,rare.Length);
            randomSprite = rare[randomRarityIndex];
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
        }
        contentSpawner.setInventoryObject(gachaItem);
        contentSpawner.createButton();
    }
}
