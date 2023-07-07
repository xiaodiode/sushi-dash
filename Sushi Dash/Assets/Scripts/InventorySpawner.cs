using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventorySpawner : MonoBehaviour
{
    #pragma warning disable
    public GachaPopup gachaPopup;
    public TextMeshProUGUI sushiBuffText;
    public string sushiName, sushiBuff, sushiRarity;
    public int sushiLevel;
    private Customizer inventoryObject;
    public StallManager[] stallManagers;
    public Image selectedSushi;
    public bool ready;
    private Image sushi, background, foreground;
    private string contentType;

    // Start is called before the first frame update
    void Start()
    {
        selectedSushi = null;
        ready = false;
        if(gameObject.CompareTag("sushi")){
            contentType = "sushi";
        }
        else if(gameObject.CompareTag("background")){
            contentType = "background";
        }
        else if(gameObject.CompareTag("foreground")){
            contentType = "foreground";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(contentType == "sushi" && selectedSushi!= null){
            // Debug.Log("selectedSushi.sprite: " + selectedSushi.sprite);
            for(int i=0; i<stallManagers.Length; i++){
                stallManagers[i].newSushiImage = selectedSushi;
            }
            sushiBuffText.text = sushiName + "\nLevel: " + (sushiLevel+1).ToString() + "\nRarity: " + sushiRarity
                + "\n\nSushi Buff: " + sushiBuff;
            selectedSushi = null;
        }
        else if(contentType != "sushi"){
            // sushiBuffText.text = "";
            selectedSushi = null;
            for(int i=0; i<stallManagers.Length; i++){
                stallManagers[i].newSushiImage = null;
            }
        }
        
    }

    public void setContent(Image newSushi, Image newBackground, Image newForeground){
        sushi = newSushi;
        background = newBackground;
        foreground = newForeground;
        ready = true;
    }
    public void setInventoryObject(Customizer gachaItem){
        inventoryObject = gachaItem;
    }

    public void createButton(){
        Customizer newButton = Instantiate(inventoryObject, inventoryObject.transform.position, inventoryObject.transform.rotation);
        
        newButton.transform.parent = transform;
        
        newButton.GetComponent<RectTransform>().localScale = inventoryObject.GetComponent<RectTransform>().localScale;
        
        gachaPopup.gachaItemCanvas.gameObject.SetActive(true);


        if(contentType == "sushi"){
            // Debug.Log("sushibuff: " + newButton.transform.GetComponent<SushiBuff>());
            // Debug.Log("gachaPopup: " + gachaPopup);
            // SushiBuff newSushiBuff = newButton.transform.GetComponent<SushiBuff>();
            newButton.setSushi(sushi);
            newButton.setInventorySpawner(this);
            //Debug.Log("sushi.sprite: " + sushi.sprite);
            // Debug.Log("\ngachapopup.sushi.sprite: " + gachaPopup.sushi.sprite);
            
            // gachaPopup.background.gameObject.SetActive(false);
            // gachaPopup.foreground.gameObject.SetActive(false);
            // gachaPopup.sushi.gameObject.SetActive(true);
            // gachaPopup.sushi.sprite = sushi.sprite;
            // gachaPopup.gachaItemText.text = newSushiBuff.sushiName + "\nLevel: " + (newSushiBuff.level+1).ToString() + "\nRarity: " + 
            //     newSushiBuff.rarity + "\n\nSushi Buff: " + newSushiBuff.buffDescription;
        }
        else if(contentType == "background"){
            newButton.setBackground(background);

            
        }
        else if(contentType == "foreground"){
            newButton.setForeground(foreground);

            
        }
    }
    #pragma warning restore
}
