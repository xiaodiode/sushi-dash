using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerController player;
    private TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = gameObject.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = player.playerCoins.ToString();
    }
}
