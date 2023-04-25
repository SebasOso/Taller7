using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimbingTutorial : MonoBehaviour
{
    public Transform chController;
    bool inside = false;
    public float speedDown = 100;
    public PlayerMovementTutorial jugador;
    public Rigidbody rigidbody;
    public GameObject timer;
    bool agarre = false;
    bool direccionz = false;
    public Image image;
    public float max_time = 7.0f;
    float time_remining;
    public bool tenerEnergia;
    void Start()
    {

        jugador = GetComponent<PlayerMovementTutorial>();
        inside = false;
        time_remining = max_time;
        timer.SetActive(false);
    }

    // Update is called once per frame


    private void OnCollisionEnter(Collision other)
    {


        Debug.Log("aqui");
        if (other.gameObject.tag == "climbz")
        {
            Debug.Log("aqui2");
            direccionz = true;
            if (tenerEnergia == true)
            {
                time_remining = max_time;
                timer.SetActive(true);
            }

            rigidbody.useGravity = false;
            jugador.enabled = false;
            inside = !inside;

        }
        else if (other.gameObject.tag == "climbx")
        {
            direccionz = false;
            if (tenerEnergia == true)
            {
                time_remining = max_time;
                timer.SetActive(true);
            }

            rigidbody.useGravity = false;
            jugador.enabled = false;
            inside = !inside;
        }
        else
        {


            Debug.Log("hit");
            timer.SetActive(false);


            rigidbody.useGravity = true;
            jugador.enabled = true;
            inside = !inside;

        }

    }

    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "climbz" || other.gameObject.tag == "climbx")
        {

            timer.SetActive(false);

            rigidbody.useGravity = true;
            jugador.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        ClimbingMovement();
    }

    private void ClimbingMovement()
    {
        if (tenerEnergia == true)
        {
            if (time_remining > 0)
            {
                time_remining -= Time.deltaTime;
                image.fillAmount = time_remining / max_time;
            }
            else
            {
                inside = false;
                timer.SetActive(false);
                rigidbody.useGravity = true;
            }
        }

        if (direccionz == false)
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
        else
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
                chController.transform.position += Vector3.back / speedDown;
            }

            if (inside == true && Input.GetKey(KeyCode.LeftArrow))
            {
                chController.transform.position += Vector3.back / speedDown;
            }

            if (inside == true && Input.GetKey(KeyCode.D))
            {
                chController.transform.position += Vector3.forward / speedDown;

            }

            if (inside == true && Input.GetKey(KeyCode.RightArrow))
            {
                chController.transform.position += Vector3.forward / speedDown;


            }
        }
    }

}
