using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ActiveBuffs activeBuffs;
    public sushiGacha s_gacha;
    public GemController gemController;
    public bool inEditMode;
    public Timer timer;
    public PlayerController player;
    public CustomerSpawner customerSpawner;
    public LevelSpawner levelSpawner;
    public StallManager[] stallManagers;
    [SerializeField] private AudioController audioController;
    
    [SerializeField] private Canvas gameplayCanvas, mainMenuCanvas, pauseCanvas, coinCanvas, editCanvas, gachaCanvas, 
                    wallpaperCanvas, returnCanvas, levelCanvas, sushiBuffCanvas, gachaItemCanvas, settingsCanvas;
    public Button resetEditTab;
    [SerializeField] private TextMeshProUGUI coinText, modeText;
    [SerializeField] private Button resumeButton, returnButton;
    public int gameMode;
    public int stop = 0; public int initialize = 1; public int proceed = 2; public int pause = 3;
    [SerializeField] private bool levelMode;
    public bool endlessMode;
    // private float endlessRate = 4f;
    [SerializeField] private float endlessRate = 3f;
    [SerializeField] private float endlessSpeed = 1f;
    [SerializeField] private float levelRate = 4f;
    [SerializeField] private float levelSpeed = 0.5f;
    [SerializeField] private float levelRateDecrease = -0.02f;
    [SerializeField] private float levelSpeedIncrease = 0.015f;
    [SerializeField] private Vector3 intialPlayerPosition = new Vector3(5.95f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        inEditMode = false;
        levelMode = false;
        endlessMode = false; 
        levelSpawner.gameObject.SetActive(true);
        customerSpawner.gameObject.SetActive(true);

        gameMode = stop;

        StartCoroutine(WaitForSushiGacha());
        gameObject.SetActive(true);
        sushiBuffCanvas.gameObject.SetActive(true);
        editCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(true);
        wallpaperCanvas.gameObject.SetActive(true);
        gameplayCanvas.gameObject.SetActive(false);
        returnCanvas.gameObject.SetActive(true);
        gachaItemCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        //gemController.gameObject.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Gemcontroller: " + gemController);
        if(gameMode == initialize){
            player.transform.position = intialPlayerPosition;
            
            coinText.text = player.playerCoins.ToString();
            levelCanvas.gameObject.SetActive(false);
            gameplayCanvas.gameObject.SetActive(true);
            editCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(false);
            mainMenuCanvas.gameObject.SetActive(false);
            customerSpawner.startCustomerSpawner();
            returnButton.gameObject.SetActive(false);
            settingsCanvas.gameObject.SetActive(false);

            
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

    private IEnumerator WaitForSushiGacha(){
        while(!s_gacha.ready){
            yield return null;
        }
        gachaCanvas.gameObject.SetActive(false);
    }
    public void setGameMode(){
        if(endlessMode){
            customerSpawner.initializeCustomerSpeed(endlessRate, endlessSpeed);
        }
        else if(levelMode){
            float adjustedRate = levelRateDecrease*player.selectedLevel;
            float adjustedSpeed = levelSpeedIncrease*player.selectedLevel;
            customerSpawner.initializeCustomerSpeed(levelRate+adjustedRate, levelSpeed+adjustedSpeed);
        }
        

        activeBuffs.updateActiveBuff();
        gameMode = initialize;

        audioController.playGameplayMusic();
        gemController.enableGemAmount(false);
        Time.timeScale = 1;
        //customerSpawner.startCustomerSpawner();

        
    }

    public void pauseGameMode(){
        pauseCanvas.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        gameMode = pause;
        timer.pauseTimer();

        Time.timeScale = 0;

        audioController.multiplyMusicVolume(0.4f);
    } 
    public void resumeGameMode(){
        pauseCanvas.gameObject.SetActive(false);
        gameMode = proceed;
        timer.resumeTimer();

        Time.timeScale = 1;

        audioController.multiplyMusicVolume(2.5f);
    }

    public void quitGameMode(){
        Time.timeScale = 0;
        Debug.Log("entering quit mode - endlessMode: " + endlessMode);
        if(endlessMode){
            gemController.setCoins(player.playerCoins);
            timer.sendTime();
        }
        timer.resetTimer();
        
        levelMode = false;
        endlessMode = false;
        gameMode = stop;
        returnButton.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(true);
        editCanvas.gameObject.SetActive(true);
        gameplayCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);
        
        gemController.enableGemAmount(true);

        player.resetPlayer();
        customerSpawner.resetCustomerSpawner();
        for(int i=0; i<stallManagers.Length; i++){
            stallManagers[i].resetStallManager();
            Debug.Log("Stall " + i + " table level: " + stallManagers[i].tableLevel);
        }
        Debug.Log("stall managers reset");
        SushiMovement[] sushis = FindObjectsOfType<SushiMovement>();
        foreach(SushiMovement sushi in sushis){
            Destroy(sushi.gameObject);
        }

        audioController.playMainMenuMusic();
    }

    public void gameOver(){
        pauseCanvas.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        gameMode = pause;
        Time.timeScale = 0;
    }

    public void editMode(){
        modeText.text = "EDIT MODE";
        inEditMode = true;
        gemController.enableGemAmount(false);
        mainMenuCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(false);

    }

    public void gachaMode(){
        modeText.text = "Gacha";
        gemController.enableGemAmount(true);
        mainMenuCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(false);
        gachaCanvas.gameObject.SetActive(true);
    }

    public void settingsMode(){
        modeText.text = "Settings";
        gemController.enableGemAmount(false);
        levelCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
    }

    public void returnToMainMenu(){
        gemController.enableGemAmount(true);
        inEditMode = false;
        gameMode = stop;
        returnButton.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(true);
        gachaCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        resetEditTab.onClick.Invoke();
        levelMode = false;
        endlessMode = false;

    }

    public void enableLevelMode(){
        gemController.enableGemAmount(false);
        levelMode = true;
        modeText.text = "Level Selection";
        mainMenuCanvas.gameObject.SetActive(false);
        levelCanvas.gameObject.SetActive(true);
        if(timer.levelClear && player.levelsUnlocked!=101){
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
