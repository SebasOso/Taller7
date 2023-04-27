using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetocaedaño : MonoBehaviour
{
    public int dañoalpersonaje = 1;
    public LifeSystem player;
 private float anchoArea;
 private float altoArea;



    public float velocidadGravedad=9.8f;

  
    private void Start()
    {
        anchoArea = this.transform.localScale.x;
        altoArea = this.transform.localScale.z;
        Physics.gravity = new Vector3(0, -velocidadGravedad, 0);
    }
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag != "spawner")
        {
           

            if (collision.transform.gameObject.tag == "Player")
            {
                player.HurtPlayer(dañoalpersonaje);
            }
            Destroy(this.gameObject);
        }
        
       
    }
    void Update()
    {

     
        Vector3 centro = this.transform.position;
        Vector3 tamano = new Vector3(anchoArea, 100f, altoArea);
        Collider[] objetosDentro = Physics.OverlapBox(centro, tamano, Quaternion.identity);

        foreach (Collider objeto in objetosDentro)
        {
            if (objeto.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
                Debug.Log("Está debajo");
            }
        }
    }
}

    
