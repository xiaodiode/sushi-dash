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
