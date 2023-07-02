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
    private Image locked;
    private int level;
    private bool first_clear, unlocked;
    private float lockedAlpha = 0.5f;

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
        tempColor.a = lockedAlpha;
        
        Debug.Log("locked object: " + locked);
        unlocked = boolean;
        if(boolean){
            button.interactable = true;
        }
        else{
            button.interactable = false;
            button.GetComponent<Image>().color = tempColor;
        }
    }

    public void setFirstClear(bool boolean){
        first_clear = boolean;
    }
}
