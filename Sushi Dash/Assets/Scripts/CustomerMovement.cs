using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Checkmark checkmark1, checkmark2, checkmark3;
    private SushiSpot sushi1,sushi2,sushi3;
    public GameObject[] sushiImages;
    
    private int randomSushiIndex;
    private int customerType;
    private float speed = 5f;
    void Start()
    {
        checkmark1 = getCheckmarkByName(gameObject,"Checkmark1");
        checkmark2 = getCheckmarkByName(gameObject,"Checkmark2");
        checkmark3 = getCheckmarkByName(gameObject,"Checkmark3");

        
        checkmark1.enable(false);
        customerType = 1;
        
        if(checkmark2 != null){
            checkmark2.enable(false);
            customerType = 2;
        }
        if(checkmark3 != null){
            checkmark3.enable(false);
            customerType = 3; 
        }

        if(customerType==1){
            randomSushiIndex = Random.Range(0,sushiImages.Length);
            sushi1 = getSushiByName(gameObject,"Sushi1");
            Instantiate(sushiImages[randomSushiIndex],sushi1.transform.position,sushiImages[randomSushiIndex].transform.rotation);
            sushi1.Destroy();
        }
        else if(customerType==2){
            randomSushiIndex = Random.Range(0,sushiImages.Length);
            sushi1 = getSushiByName(gameObject,"Sushi1");
            Instantiate(sushiImages[randomSushiIndex],sushi1.transform.position,sushiImages[randomSushiIndex].transform.rotation);
            sushi1.Destroy();

            randomSushiIndex = Random.Range(0,sushiImages.Length);
            sushi2 = getSushiByName(gameObject,"Sushi2");
            Instantiate(sushiImages[randomSushiIndex],sushi2.transform.position,sushiImages[randomSushiIndex].transform.rotation);
            sushi2.Destroy();
        }
        else{
            randomSushiIndex = Random.Range(0,sushiImages.Length);
            sushi1 = getSushiByName(gameObject,"Sushi1");
            Instantiate(sushiImages[randomSushiIndex],sushi1.transform.position,sushiImages[randomSushiIndex].transform.rotation);
            sushi1.Destroy();

            randomSushiIndex = Random.Range(0,sushiImages.Length);
            sushi2 = getSushiByName(gameObject,"Sushi2");
            Instantiate(sushiImages[randomSushiIndex],sushi2.transform.position,sushiImages[randomSushiIndex].transform.rotation);
            sushi2.Destroy();

            randomSushiIndex = Random.Range(0,sushiImages.Length);
            sushi3 = getSushiByName(gameObject,"Sushi3");
            Instantiate(sushiImages[randomSushiIndex],sushi3.transform.position,sushiImages[randomSushiIndex].transform.rotation);
            sushi3.Destroy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    private Checkmark getCheckmarkByName(GameObject gameObject, string componentName){
        Checkmark[] components = gameObject.GetComponentsInChildren<Checkmark>(true);
        foreach(Checkmark component in components){
            if(component.name == componentName){
                return component;
            }
        }
        return null;
    }
    private SushiSpot getSushiByName(GameObject gameObject, string componentName){
        SushiSpot[] components = gameObject.GetComponentsInChildren<SushiSpot>(true);
        foreach(SushiSpot component in components){
            if(component.name == componentName){
                return component;
            }
        }
        return null;
    }
}
