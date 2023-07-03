using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public PlayerController player;
    public GameManager gameManager;
    public LevelButton levelButton;
    public List<LevelButton> levelButtons = new List<LevelButton>();
    public bool ready = false;
    private int maxLevels = 100;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1; i<=maxLevels; i++){
            LevelButton newButton = Instantiate(levelButton, levelButton.transform.position, levelButton.transform.rotation);
            newButton.transform.parent = transform;
            newButton.GetComponent<RectTransform>().localScale = levelButton.GetComponent<RectTransform>().localScale;
            newButton.setLevel(i);
            newButton.setFirstClear(false);
            newButton.setGameManager(gameManager);
            levelButtons.Add(newButton);
            

            if(i >= 1 && i <=10){
                newButton.setUnlocked(true);
            }
            else{
                newButton.setUnlocked(false);
            }
            
            newButton.setPlayer(player);
        }
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
