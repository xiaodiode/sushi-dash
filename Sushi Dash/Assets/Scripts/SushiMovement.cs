using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool move;
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<-16){
            Destroy(gameObject);
        }
        // if(move){
        //     Debug.Log(gameObject + ": here" );
        //     launchSushi();
        // }
        transform.Rotate(0,0,2f);
        transform.position += Vector3.left*20*Time.deltaTime;
    }
    private void launchSushi(){
        transform.Rotate(0,0,2f);
        transform.position += Vector3.left*20*Time.deltaTime;
    }
    public void destroy(){
        Destroy(gameObject);
    }
}
