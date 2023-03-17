using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallclimb : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform chController;
    bool inside = false;
    public float speedDown = 100;
    public Jugador jugador;
    public Rigidbody rigidbody;

   

    void Start()
    {
        jugador = GetComponent<Jugador>();
        inside = false;
     
       
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "climb")
        {

           
            rigidbody.useGravity = false;
            jugador.enabled = false;
            inside = !inside;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "climb")
        {

            rigidbody.useGravity = true;
            jugador.enabled = true;
            inside = !inside;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Untagged")
        {
           
            rigidbody.useGravity = true;
            jugador.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
       
        if (inside == true && Input.GetKey(KeyCode.W))
        {
            chController.transform.position += Vector3.up / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.UpArrow))
        {
            chController.transform.position += Vector3.up / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.S))
        {
            chController.transform.position += Vector3.down / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.DownArrow))
        {
            chController.transform.position += Vector3.down / speedDown;
        }


        if (inside == true && Input.GetKey(KeyCode.A))
        {
            chController.transform.position += Vector3.left / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.LeftArrow))
        {
            chController.transform.position += Vector3.left / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.D))
        {
            chController.transform.position += Vector3.right / speedDown;
        }

        if (inside == true && Input.GetKey(KeyCode.RightArrow))
        {
            chController.transform.position += Vector3.right / speedDown;
        }
    }



}
