using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public CustomerSpawner customerSpawner;
    private Canvas gameplayCanvas, mainMenuCanvas, coinCanvas;
    private TextMeshProUGUI coinText;
    public int gameMode;
    int stop = 0; int initialize = 1; int proceed = 2;
    private Vector3 intialPlayerPosition = new Vector3(5.95f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        customerSpawner.gameObject.SetActive(false);
        mainMenuCanvas = gameObject.transform.Find("MainMenu Canvas").GetComponent<Canvas>();

        gameplayCanvas = gameObject.transform.Find("Gameplay Canvas").GetComponent<Canvas>();
        coinCanvas = gameplayCanvas.transform.Find("Coin Canvas").GetComponent<Canvas>();
        coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();

        gameMode = stop;

        gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(true);
        gameplayCanvas.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == initialize){
            player.transform.position = intialPlayerPosition;
            coinText.text = player.playerCoins.ToString();
            gameplayCanvas.gameObject.SetActive(true);
            mainMenuCanvas.gameObject.SetActive(false);
            customerSpawner.gameObject.SetActive(true);
            gameMode = proceed;
        }
        if(gameMode == proceed){
            coinText.text = player.playerCoins.ToString();
        }
        else{
            
        }
    }
    public void setGameMode(){
        gameMode = initialize;
    }

}
