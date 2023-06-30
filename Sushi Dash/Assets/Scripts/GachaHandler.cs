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
    private float commonChance = 0.6f; private float uncommonChance = 0.3f; private float rareChance = 0.1f;
    private List<string> rarityPicker = new List<string>();
    private string randomRarity, imageName;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.transform.GetComponent<Button>();
        for(int i=0; i<commonChance*10; i++){
            rarityPicker.Add("common");
        }
        for(int i=0; i<uncommonChance*10; i++){
            rarityPicker.Add("uncommon");
        }
        for(int i=0; i<rareChance*10; i++){
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
        Debug.Log("gachaItem: " + gachaItem);
        int randomRarityIndex = Random.Range(0,10);
        randomRarity = rarityPicker[randomRarityIndex];
        Debug.Log("randomRarity = " + randomRarity);
        if(randomRarity == "common"){
            randomRarityIndex = Random.Range(0,common.Length);
            randomSprite = common[randomRarityIndex];
            Debug.Log("randomSprite: " + randomSprite);
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            Debug.Log("gachaItem updated sprite: " + gachaItem.GetComponent<Image>().sprite);
        }
        else if(randomRarity == "uncommon"){
            randomRarityIndex = Random.Range(0,uncommon.Length);
            randomSprite = uncommon[randomRarityIndex];
            Debug.Log("randomSprite: " + randomSprite);
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            Debug.Log("gachaItem updated sprite: " + gachaItem.GetComponent<Image>().sprite);
        }
        else{
            randomRarityIndex = Random.Range(0,rare.Length);
            randomSprite = rare[randomRarityIndex];
            Debug.Log("randomSprite: " + randomSprite);
            gachaItem.transform.Find(imageName).GetComponent<Image>().sprite = randomSprite;
            Debug.Log("gachaItem updated sprite: " + gachaItem.GetComponent<Image>().sprite);
        }
        Debug.Log("contentSpawner: " + contentSpawner);
        contentSpawner.setInventoryObject(gachaItem);
        contentSpawner.createButton();
    }
}
