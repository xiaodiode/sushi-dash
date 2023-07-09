using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemController : MonoBehaviour
{
    public PlayerController player;
    private Canvas gemPopupCanvas, gemAmountCanvas, endlessModeCanvas, levelModeCanvas;
    private Image popup;
    private TextMeshProUGUI endlessStatsText, gemAmountText;
    private Button closeButton;
    private string currMode;
    private int gemAmount;
    private int endlessGems;
    private int endlessCoins;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currMode = "";
        gemAmount = 1000;
        endlessGems = 0;

        gemPopupCanvas = transform.Find("Gem Popup Canvas").GetComponent<Canvas>();
        popup = gemPopupCanvas.transform.Find ("Popup Image").GetComponent<Image>();
        endlessModeCanvas = popup.transform.Find("Endless Mode Canvas").GetComponent<Canvas>();
        endlessStatsText = endlessModeCanvas.transform.Find("Stats Text").GetComponent<TextMeshProUGUI>();
        levelModeCanvas = popup.transform.Find("Level Mode Canvas").GetComponent<Canvas>();
        closeButton = gemPopupCanvas.transform.Find("Close Button").GetComponent<Button>();
        
        gemAmountCanvas = transform.Find("Gem Amount Canvas").GetComponent<Canvas>();
        gemAmountText = gemAmountCanvas.transform.Find("Gem Amount Text").GetComponent<TextMeshProUGUI>();


        gameObject.SetActive(true);
        gemPopupCanvas.gameObject.SetActive(false);
        enableGemAmount(true);
        updateGemAmount(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void enableGemAmount(bool boolean){
        gemAmountCanvas.gameObject.SetActive(boolean);
    }
    public void updateGemAmount(int gemChange){
        gemAmount += gemChange;
        gemAmountText.text = gemAmount.ToString();
    }
    public void enableGemPopup(string mode){
        if(mode == "endless"){
            gemPopupCanvas.gameObject.SetActive(true);
            endlessModeCanvas.gameObject.SetActive(true);
            levelModeCanvas.gameObject.SetActive(false);
        }
        else if(mode == "level"){
            gemPopupCanvas.gameObject.SetActive(true);
            endlessModeCanvas.gameObject.SetActive(false);
            levelModeCanvas.gameObject.SetActive(true);
        }
        currMode = mode;
    }
    public void setCoins(int coins){
        endlessCoins = coins;
    }

    public void closeGemPopup(){
        gemPopupCanvas.gameObject.SetActive(false);
        if(currMode == "level"){
            updateGemAmount(5);
        }
        else{
            endlessGems = 0;
        }
    }
    public int getGemAmount(){
        return gemAmount;
    }

    public void setTime(string timeText, int totalSeconds){
        int gemsEarned = (totalSeconds/30) + (endlessCoins/100);
        endlessGems = gemsEarned - player.sushiMissed;
        if(endlessGems < 0){
            endlessGems = 0;
        }
        Debug.Log("endlessCoins: " + endlessCoins);
        Debug.Log("totalSeconds: " + totalSeconds);
        endlessStatsText.text = timeText + "\n" + endlessCoins.ToString() + "\n" + 
            gemsEarned + "\n" + player.sushiMissed.ToString() +
            "\n\n" + endlessGems;

        updateGemAmount(endlessGems);
        
    }
}
