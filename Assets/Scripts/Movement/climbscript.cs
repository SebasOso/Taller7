
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbscript : MonoBehaviour
{


public Transform chController;
    bool inside = false;
    public float speedDown = 3.2f;
    public ThirdPersonController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ThirdPersonController>();

        inside = false;
    }

 void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag=="escalable")
        {
         
           
            controller.enabled = false;
             inside = !inside;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "escalable")
        {
          
            controller.enabled = true;
            inside = !inside;
        }
    }

 void Update()
    {
        
        if (inside == true && Input.GetKey(KeyCode.W))
        {
            chController.transform.position += Vector3.up / speedDown;
        }
        if (inside == true && Input.GetKey(KeyCode.S))
        {
            chController.transform.position += Vector3.down / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.A))
        {
            chController.transform.position += Vector3.left / speedDown;
        }
        if(inside == true && Input.GetKey(KeyCode.D))
        {
            chController.transform.position += Vector3.right / speedDown;
        }
    }

    // Update is called once per frame
   
}
