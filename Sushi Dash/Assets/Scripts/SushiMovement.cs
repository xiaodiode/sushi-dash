using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool spin;
    void Start()
    {
        spin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<-20){
            Destroy(gameObject);
        }
        
        transform.position += Vector3.left*20*Time.deltaTime;
        transform.Rotate(0,0,2f);
    }
    private void launchSushi(){
        transform.Rotate(0,0,180f*Time.deltaTime);
        transform.position += Vector3.left*20*Time.deltaTime;
    }
    public void destroy(){
        Destroy(gameObject);
    }
}
