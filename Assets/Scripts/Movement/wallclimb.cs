using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallclimb : MonoBehaviour
{


    public Transform chController;
    bool inside = false;
    public float speedDown = 100;
    public Player jugador;
    public Rigidbody rigidbody;
    public GameObject timer;
    bool agarre = false;

    public Image image;
    public float max_time = 7.0f;
    float time_remining;
    public bool tenerEnergia;
    void Start()
    {

        jugador = GetComponent<Player>();
        inside = false;
        time_remining = max_time;
        timer.active = false;
    }

    // Update is called once per frame



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "climb")
        {
            if (tenerEnergia == true)
            {
                time_remining = max_time;
                timer.active = true;
            }

            rigidbody.useGravity = false;
            jugador.enabled = false;
            inside = !inside;
        }
        if (other.gameObject.tag != "climb")
        {


            timer.active = false;


            rigidbody.useGravity = true;
            jugador.enabled = true;
            inside = !inside;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "climb")
        {

            timer.active = false;

            rigidbody.useGravity = true;
            jugador.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        if (timer.active == true)
        {
            if (time_remining > 0)
            {
                time_remining -= Time.deltaTime;
                image.fillAmount = time_remining / max_time;
            }
            else
            {
                inside = false;
                timer.active = false;
                rigidbody.useGravity = true;
            }
        }
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