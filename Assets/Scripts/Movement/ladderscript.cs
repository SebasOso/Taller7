using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderscript : MonoBehaviour
{


public Transform chController;
    bool inside = false;
    public float speedDown = 3.2f;
    public vThirdPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<vThirdPersonController>();
        inside = false;
    }

 void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="ladder")
        {
            controller.enabled = false;
            inside = !inside;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "ladder")
        {
            controller.enabled = true;
            inside = !inside;
        }
    }

 void Update()
    {
        
        if (inside == true && Input.GetKey("up"))
        {
            chController.transform.position += Vector3.up / speedDown;
        }
        if (inside == true && Input.GetKey("down"))
        {
            chController.transform.position += Vector3.down / speedDown;
        }
    }

    // Update is called once per frame
   
}
