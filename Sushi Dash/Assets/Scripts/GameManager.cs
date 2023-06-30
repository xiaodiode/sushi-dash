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
    private Canvas gameplayCanvas, mainMenuCanvas, pauseCanvas, coinCanvas, editCanvas, gachaCanvas, 
                    wallpaperCanvas, returnCanvas;
    public Canvas backgroundCanvas;
    public Button resetEditTab;
    private TextMeshProUGUI coinText, modeText;
    private Button resumeButton;
    public int gameMode;
    public int stop = 0; public int initialize = 1; public int proceed = 2; public int pause = 3;
    private Vector3 intialPlayerPosition = new Vector3(5.95f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        customerSpawner.gameObject.SetActive(false);
        mainMenuCanvas = gameObject.transform.Find("MainMenu Canvas").GetComponent<Canvas>();
        returnCanvas = gameObject.transform.Find("Return Canvas").GetComponent<Canvas>();

        gameplayCanvas = gameObject.transform.Find("Gameplay Canvas").GetComponent<Canvas>();
        modeText = gameplayCanvas.transform.Find("Mode Text").GetComponent<TextMeshProUGUI>();
        pauseCanvas = gameplayCanvas.transform.Find("Pause Canvas").GetComponent<Canvas>();
        resumeButton = pauseCanvas.transform.Find("Resume Button").GetComponent<Button>();
        coinCanvas = gameplayCanvas.transform.Find("Coin Canvas").GetComponent<Canvas>();
        coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();

        wallpaperCanvas = gameObject.transform.Find("Wallpaper").GetComponent<Canvas>();

        editCanvas = gameObject.transform.Find("Edit Canvas").GetComponent<Canvas>();

        gachaCanvas = gameObject.transform.Find("Gacha Canvas").GetComponent<Canvas>();

        gameMode = stop;

        gameObject.SetActive(true);
        editCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
        wallpaperCanvas.gameObject.SetActive(true);
        gameplayCanvas.gameObject.SetActive(false);
        returnCanvas.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == initialize){
            player.transform.position = intialPlayerPosition;
            modeText.text = "GAME MODE";
            coinText.text = player.playerCoins.ToString();
            gameplayCanvas.gameObject.SetActive(true);
            editCanvas.gameObject.SetActive(false);
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
        resumeButton.gameObject.SetActive(true);
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
        editCanvas.gameObject.SetActive(true);
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
        resumeButton.gameObject.SetActive(false);
        gameMode = pause;
        Time.timeScale = 0;
    }

    public void editMode(){
        modeText.text = "EDIT MODE";
        mainMenuCanvas.gameObject.SetActive(false);
        returnCanvas.gameObject.SetActive(true);

    }

    public void gachaMode(){
        mainMenuCanvas.gameObject.SetActive(false);
        gachaCanvas.gameObject.SetActive(true);
        returnCanvas.gameObject.SetActive(true);

    }

    public void returnToMainMenu(){
        mainMenuCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(false);
        resetEditTab.onClick.Invoke();
        returnCanvas.gameObject.SetActive(false);

    }

    

}
