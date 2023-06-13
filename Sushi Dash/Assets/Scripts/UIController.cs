using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        Canvas coinCanvas = gameObject.transform.Find("Coin Canvas").GetComponent<Canvas>();
        TextMeshProUGUI coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        Debug.Log("coinCanvas: " + coinCanvas + " coinText: " + coinText);
        coinText.text = player.playerCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
