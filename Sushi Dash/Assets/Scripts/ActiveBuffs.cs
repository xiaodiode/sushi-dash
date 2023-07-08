using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveBuffs : MonoBehaviour
{
    private KeyPressButton[] sushiButtons;
    private Image[] sushiImages;

    // Start is called before the first frame update
    void Start()
    {
        sushiButtons = GameObject.FindObjectsOfType<KeyPressButton>();
        for(int i=0; i<sushiButtons.Length; i++){
            sushiImages[i] = sushiButtons[i].transform.Find("SushiImage").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
