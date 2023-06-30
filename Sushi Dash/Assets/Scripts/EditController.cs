using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditController : MonoBehaviour
{
    public Image sushi, background, foreground;
    public ContentSpawner[] contentSpawners;
    public GameObject editCanvas;
    public GameObject sushiScroll, backgroundScroll, foregroundScroll;
    private Button[] sushiInventory, backgroundInventory, foregroundInventory;
    private int allReady = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        sushiScroll.SetActive(true);
        backgroundScroll.SetActive(true);
        foregroundScroll.SetActive(true);

        for(int i=0; i<contentSpawners.Length; i++){
            contentSpawners[i].setContent(sushi, background, foreground);
        }

        StartCoroutine(initializeContent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator initializeContent(){
        for(int i=0; i<contentSpawners.Length; i++){
            if(contentSpawners[i].ready){
                allReady++;
            }
        }
        while(allReady != contentSpawners.Length){
            yield return null;
        }
        backgroundScroll.SetActive(false);
        foregroundScroll.SetActive(false);
    }
    public void enableSushiScroll(){
        sushiScroll.SetActive(true);
        backgroundScroll.SetActive(false);
        foregroundScroll.SetActive(false);
    }

    public void enableBackgroundScroll(){
        sushiScroll.SetActive(false);
        backgroundScroll.SetActive(true);
        foregroundScroll.SetActive(false);
    }

    public void enableForegroundScroll(){
        sushiScroll.SetActive(false);
        backgroundScroll.SetActive(false);
        foregroundScroll.SetActive(true);
    }
}
