using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContentSpawner : MonoBehaviour
{
    #pragma warning disable
    private checkClick inventoryObject;
    public bool ready;
    private Image sushi, background, foreground;
    private string contentType;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    public void setContent(Image newSushi, Image newBackground, Image newForeground){
        sushi = newSushi;
        background = newBackground;
        foreground = newForeground;
        ready = true;
    }
    public void setInventoryObject(checkClick gachaItem){
        inventoryObject = gachaItem;
    }

    public void createButton(){
        checkClick newButton = Instantiate(inventoryObject, inventoryObject.transform.position, inventoryObject.transform.rotation);
        
        newButton.transform.parent = transform;
        
        newButton.GetComponent<RectTransform>().localScale = inventoryObject.GetComponent<RectTransform>().localScale;
        

        if(contentType == "sushi"){
            newButton.setSushi(sushi);
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
