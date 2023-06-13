using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerController player;
    private Canvas coinCanvas;
    private TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinCanvas = gameObject.transform.Find("Coin Canvas").GetComponent<Canvas>();
        coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        Debug.Log("coinCanvas: " + coinCanvas + " coinText: " + coinText);
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = player.playerCoins.ToString();
    }
}
