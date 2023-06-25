using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float spin_speed;
    private float minXPosition = -30;
    void Start()
    {
        spin_speed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < minXPosition){
            Destroy(gameObject);
        }
        
        transform.position += Vector3.left*20*Time.deltaTime;
        transform.Rotate(0,0,spin_speed*Time.deltaTime);
    }
    public void destroy(){
        Destroy(gameObject);
    }
}
