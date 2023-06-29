using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public CustomerSpawner customerSpawner;
    public StallManager[] stallManagers;
    private Canvas gameplayCanvas, mainMenuCanvas, pauseCanvas, coinCanvas, editCanvas;
    public Canvas backgroundCanvas;
    private TextMeshProUGUI coinText;
    private Button resume;
    public int gameMode;
    public int stop = 0; public int initialize = 1; public int proceed = 2; public int pause = 3;
    private Vector3 intialPlayerPosition = new Vector3(5.95f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        customerSpawner.gameObject.SetActive(false);
        mainMenuCanvas = gameObject.transform.Find("MainMenu Canvas").GetComponent<Canvas>();

        gameplayCanvas = gameObject.transform.Find("Gameplay Canvas").GetComponent<Canvas>();
        pauseCanvas = gameplayCanvas.transform.Find("Pause Canvas").GetComponent<Canvas>();
        resume = pauseCanvas.transform.Find("Resume Button").GetComponent<Button>();
        coinCanvas = gameplayCanvas.transform.Find("Coin Canvas").GetComponent<Canvas>();
        coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();

        //backgroundCanvas = gameObject.transform.Find("Background/Foreground").GetComponent<GameObject>();

        editCanvas = gameObject.transform.Find("Edit Canvas").GetComponent<Canvas>();

        gameMode = stop;

        gameObject.SetActive(true);
        editCanvas.gameObject.SetActive(true);
        backgroundCanvas.gameObject.SetActive(true);
        //mainMenuCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        gameplayCanvas.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == initialize){
            player.transform.position = intialPlayerPosition;
            coinText.text = player.playerCoins.ToString();
            gameplayCanvas.gameObject.SetActive(true);
            pauseCanvas.gameObject.SetActive(false);
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
        Time.timeScale = 1;
        //customerSpawner.startCustomerSpawner();
    }

    public void pauseGameMode(){
        pauseCanvas.gameObject.SetActive(true);
        resume.gameObject.SetActive(true);
        gameMode = pause;
        Time.timeScale = 0;
    }
    public void resumeGameMode(){
        pauseCanvas.gameObject.SetActive(false);
        gameMode = proceed;
        Time.timeScale = 1;
    }

    public void quitGameMode(){
        Time.timeScale = 0;
        gameMode = stop;
        mainMenuCanvas.gameObject.SetActive(true);
        gameplayCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);

        player.resetPlayer();
        customerSpawner.resetCustomerSpawner();
        for(int i=0; i<stallManagers.Length; i++){
            stallManagers[i].resetStallManager();
        }
        SushiMovement[] sushis = FindObjectsOfType<SushiMovement>();
        foreach(SushiMovement sushi in sushis){
            Destroy(sushi.gameObject);
        }
    }

    public void gameOver(){
        pauseCanvas.gameObject.SetActive(true);
        resume.gameObject.SetActive(false);
        gameMode = pause;
        Time.timeScale = 0;
    }

}
