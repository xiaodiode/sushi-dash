using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkClick : MonoBehaviour
{
    private Image sushi, foreground, background;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("foreground")){
            button.onClick.AddListener(changeForeground);
        }
        
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
