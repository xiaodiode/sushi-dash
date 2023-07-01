using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customizer : MonoBehaviour
{
    private Image sushi, foreground, background;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();

        if(gameObject.CompareTag("sushi")){
            button.onClick.AddListener(changeSushi);
        }
        else if(gameObject.CompareTag("background")){
            button.onClick.AddListener(changeBackground);
        }
        else if(gameObject.CompareTag("foreground")){
            button.onClick.AddListener(changeForeground);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void changeSushi(){
        Transform sushiButton = button.transform.Find("Image_S").GetComponent<Transform>();
        Image newSushi = sushiButton.gameObject.GetComponent<Image>();
    }
    private void changeBackground(){
        Transform backgroundButton = button.transform.Find("Image_B").GetComponent<Transform>();
        Image newBackground = backgroundButton.gameObject.GetComponent<Image>();
        Debug.Log("original background.sprite: " + background.sprite);
        background.sprite = newBackground.sprite;
        Debug.Log("new background.sprite: " + background.sprite);
    }
    private void changeForeground(){
        Transform foregroundButton = button.transform.Find("Image_F").GetComponent<Transform>();
        Image newForeground = foregroundButton.gameObject.GetComponent<Image>();
        foreground.sprite = newForeground.sprite;
    }

    public void setSushi(Image newSushi){
        sushi = newSushi;
    }
    public void setBackground(Image newBackground){
        background = newBackground;
    }
    public void setForeground(Image newForeground){
        foreground = newForeground;
    }
}
