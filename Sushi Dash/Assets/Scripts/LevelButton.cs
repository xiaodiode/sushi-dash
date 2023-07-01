using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    private PlayerController player;
    private GameManager gameManager;
    private Button button;
    private TextMeshProUGUI levelText;
    private int level;
    private bool first_clear, unlocked;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(levelSelected);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void levelSelected(){
        Debug.Log("LEVEL SELECTED: " + level.ToString());
        if(unlocked){
            player.selectedLevel = level;
            gameManager.setGameMode();
        }
    }

    public void setPlayer(PlayerController newPlayer){
        player = newPlayer;
    }
    public void setGameManager(GameManager newGameManager){
        gameManager = newGameManager;
    }
    public void setLevel(int newLevel){
        level = newLevel;
        levelText = transform.Find("LvlText").GetComponent<TextMeshProUGUI>();
        levelText.text = "Level " + level.ToString();
        
    }
    public void setUnlocked(bool boolean){
        unlocked = boolean;
    }

    public void setFirstClear(bool boolean){
        first_clear = boolean;
    }
}
