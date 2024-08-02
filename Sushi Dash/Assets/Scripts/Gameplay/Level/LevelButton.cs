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
    private float lockedAlpha = 0.5f;
    private float unlockedAlpha = 1f;

    Color tempColor;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(levelSelected);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void levelSelected(){
        Debug.Log("levelSelected: " + level + " unlocked: " + unlocked);
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
        button = transform.Find("Level Button").GetComponent<Button>();
        level = newLevel;
        levelText = button.transform.Find("LvlText").GetComponent<TextMeshProUGUI>();
        levelText.text = "Level " + level.ToString();
        
    }
    public void setUnlocked(bool boolean){
        tempColor = button.GetComponent<Image>().color;
        
        unlocked = boolean;
        if(boolean){
            tempColor.a = unlockedAlpha;
            button.interactable = true;
            button.GetComponent<Image>().color = tempColor;
        }
        else{
            tempColor.a = lockedAlpha;
            button.interactable = false;
            button.GetComponent<Image>().color = tempColor;
        }
    }

    public void setFirstClear(bool boolean){
        first_clear = boolean;
    }
}
