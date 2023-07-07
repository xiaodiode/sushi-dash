using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaPopup : MonoBehaviour
{
    public Canvas gachaItemCanvas;
    public TextMeshProUGUI gachaItemText;
    public Image background, foreground, sushi;
    // Start is called before the first frame update
    void Start()
    {
        //gachaItemCanvas = transform.Find("Gacha Item Canvas").GetComponent<Canvas>();
        gachaItemText = transform.Find("Gacha Text").GetComponent<TextMeshProUGUI>();
        background = transform.Find("Background Image").GetComponent<Image>();
        foreground = transform.Find("Foreground Image").GetComponent<Image>();
        sushi = transform.Find("Sushi Image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enablePopup(){
        gachaItemCanvas.gameObject.SetActive(true);
    }
    public void disablePopup(){
        gachaItemCanvas.gameObject.SetActive(false);
    }
}
