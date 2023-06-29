using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditController : MonoBehaviour
{
    public Image background, foreground;
    public GameObject editCanvas;
    public GameObject sushiScroll, backgroundScroll, foregroundScroll;
    private Button[] sushiInventory, backgroundInventory, foregroundInventory;
    // Start is called before the first frame update
    void Start()
    {
        
        sushiScroll.SetActive(true);
        backgroundScroll.SetActive(false);
        foregroundScroll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBackground(Button button){
        Transform backgroundButton = transform.parent;
        Image newBackground = backgroundButton.gameObject.GetComponent<Image>();
        background.sprite = newBackground.sprite;
        Debug.Log("changing background!!");
    }

    public void changeForeground(Button button){
        Debug.Log("changing foreground!!");
        Debug.Log("transform: " + transform);
        Transform foregroundButton = button.transform.Find("ForegroundButton").GetComponent<Transform>();
        Image newForeground = foregroundButton.gameObject.GetComponent<Image>();
        Debug.Log("newForeground: " + newForeground);
        foreground.sprite = newForeground.sprite;
        Debug.Log("foreground.sprite: " + foreground.sprite);

        
    }

    public void enableSushiScroll(){
        sushiScroll.SetActive(true);
        backgroundScroll.SetActive(false);
        foregroundScroll.SetActive(false);
    }

    public void enableBackgroundScroll(){
        sushiScroll.SetActive(false);
        backgroundScroll.SetActive(true);
        foregroundScroll.SetActive(false);
    }

    public void enableForegroundScroll(){
        sushiScroll.SetActive(false);
        backgroundScroll.SetActive(false);
        foregroundScroll.SetActive(true);
    }
}
