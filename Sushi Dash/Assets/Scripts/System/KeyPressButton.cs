using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressButton : MonoBehaviour
{
    public KeyCode key;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)){
            button.onClick.Invoke();
        }
    }
}
