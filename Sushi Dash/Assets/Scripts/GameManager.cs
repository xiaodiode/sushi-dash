using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public PlayerController player;
    public CustomerSpawner customerSpawner;
    public LevelSpawner levelSpawner;
    public StallManager[] stallManagers;
    
    private Canvas gameplayCanvas, mainMenuCanvas, pauseCanvas, coinCanvas, editCanvas, gachaCanvas, 
                    wallpaperCanvas, returnCanvas, levelCanvas, sushiBuffCanvas;
    public Canvas backgroundCanvas;
    public Button resetEditTab;
    private TextMeshProUGUI coinText, modeText;
    private Button resumeButton, returnButton;
    public int gameMode;
    public int stop = 0; public int initialize = 1; public int proceed = 2; public int pause = 3;
    private bool levelMode;
    private bool endlessMode;
    private Vector3 intialPlayerPosition = new Vector3(5.95f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        levelMode = false;
        endlessMode = false; 
        levelSpawner.gameObject.SetActive(true);
        customerSpawner.gameObject.SetActive(false);
        mainMenuCanvas = gameObject.transform.Find("MainMenu Canvas").GetComponent<Canvas>();

        returnCanvas = gameObject.transform.Find("Return Canvas").GetComponent<Canvas>();
        modeText = returnCanvas.transform.Find("Mode Text").GetComponent<TextMeshProUGUI>();
        returnButton = returnCanvas.transform.Find("Return Button").GetComponent<Button>();

        gameplayCanvas = gameObject.transform.Find("Gameplay Canvas").GetComponent<Canvas>();
        
        pauseCanvas = gameplayCanvas.transform.Find("Pause Canvas").GetComponent<Canvas>();
        resumeButton = pauseCanvas.transform.Find("Resume Button").GetComponent<Button>();
        coinCanvas = gameplayCanvas.transform.Find("Coin Canvas").GetComponent<Canvas>();
        coinText = coinCanvas.transform.Find("Coin Text").GetComponent<TextMeshProUGUI>();

        wallpaperCanvas = gameObject.transform.Find("Wallpaper").GetComponent<Canvas>();

        editCanvas = gameObject.transform.Find("Edit Canvas").GetComponent<Canvas>();
        sushiBuffCanvas = gameObject.transform.Find("SushiBuff Canvas").GetComponent<Canvas>();

        gachaCanvas = gameObject.transform.Find("Gacha Canvas").GetComponent<Canvas>();

        levelCanvas = gameObject.transform.Find("Level Canvas").GetComponent<Canvas>();

        gameMode = stop;

        gameObject.SetActive(true);
        sushiBuffCanvas.gameObject.SetActive(true);
        editCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
        wallpaperCanvas.gameObject.SetActive(true);
        gameplayCanvas.gameObject.SetActive(false);
        returnCanvas.gameObject.SetActive(true);


        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == initialize){
            player.transform.position = intialPlayerPosition;
            
            coinText.text = player.playerCoins.ToString();
            levelCanvas.gameObject.SetActive(false);
            gameplayCanvas.gameObject.SetActive(true);
            editCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(false);
            mainMenuCanvas.gameObject.SetActive(false);
            customerSpawner.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            
            if(levelMode){
                modeText.text = "Level " + player.selectedLevel.ToString();
                timer.startCountDown();
            }
            else if(endlessMode){
                modeText.text = "Endless Mode";
                timer.startCountUp();
            }
            
            gameMode = proceed;
            
        }
        if(gameMode == proceed){
            coinText.text = player.playerCoins.ToString();
            
        }
        //  Debug.Log("gameMode: " + gameMode + " stop = 0; initialize = 1; proceed = 2; pause = 3;");
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
        timer.pauseTimer();
        Time.timeScale = 0;
    }
    public void resumeGameMode(){
        pauseCanvas.gameObject.SetActive(false);
        gameMode = proceed;
        timer.resumeTimer();
        Time.timeScale = 1;
    }

    public void quitGameMode(){
        timer.resetTimer();
        Debug.Log("ENTERED QUIT MODE");
        Time.timeScale = 0;
        levelMode = false;
        endlessMode = false;
        gameMode = stop;
        returnButton.gameObject.SetActive(true);
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
        levelCanvas.gameObject.SetActive(false);

    }

    public void gachaMode(){
        modeText.text = "Gacha";
        mainMenuCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(false);
        gachaCanvas.gameObject.SetActive(true);

    }

    public void returnToMainMenu(){
        gameMode = stop;
        returnButton.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(false);
        resetEditTab.onClick.Invoke();
        levelMode = false;
        endlessMode = false;

    }

    public void enableLevelMode(){
        levelMode = true;
        modeText.text = "Level Selection";
        mainMenuCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(true);
        if(timer.levelClear){
            Debug.Log("levelSpawner size: " + levelSpawner.levelButtons.Count);
            Debug.Log("player.levelUnlocked: " + player.levelsUnlocked);
            levelSpawner.levelButtons[player.levelsUnlocked-1].setUnlocked(true);
        }
        timer.levelClear = false;
    }

    public void enableEndlessMode(){
        endlessMode = true;
        setGameMode();
    }

    public void levelSelected(){

    }

    

}
