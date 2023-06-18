using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerController player;
    private Canvas gameplayCanvas, coinCanvas;
    private TextMeshProUGUI coinText;
    public GameManager gameManager;
    int stop = 0; int initialize = 1; int proceed = 2;
    private Vector3 intialPlayerPosition = new Vector3(5.95f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        gameplayCanvas = gameObject.transform.Find("Gameplay Canvas").GetComponent<Canvas>();
        coinCanvas = gameplayCanvas.transform.Find("Coin Canvas").GetComponent<Canvas>();
        coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();

        gameManager.gameMode = stop;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameMode == initialize){
            player.transform.position = intialPlayerPosition;
            coinText.text = player.playerCoins.ToString();
            gameplayCanvas.gameObject.SetActive(true);
            gameManager.gameMode = proceed;
        }
    }

}
