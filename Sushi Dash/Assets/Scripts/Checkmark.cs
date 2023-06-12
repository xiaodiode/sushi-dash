using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkmark : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isActive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enable(bool boolean){
        gameObject.SetActive(boolean);
        isActive=boolean;
    }
    public bool isEnabled(){
        return isActive;
    }
}
