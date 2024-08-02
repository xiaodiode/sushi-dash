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
