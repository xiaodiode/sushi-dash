using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContentSpawner : MonoBehaviour
{
    public checkClick inventoryObject;
    public Image sushi, background, foreground;
    private string contentType;

    // Start is called before the first frame update
    void Start()
    {
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

    public void createButton(){
        checkClick newButton = Instantiate(inventoryObject, inventoryObject.transform.position, inventoryObject.transform.rotation);
        Debug.Log("newbutton scale: " + newButton.transform.localScale);
        Debug.Log("inventoryObject scale: " + inventoryObject.transform.localScale);
        
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
}
