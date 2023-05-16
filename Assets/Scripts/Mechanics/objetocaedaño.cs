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
                Destroy(this.gameObject);
            }
           
        }
        
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag=="Destruir")
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {

    
        
    }
}

    
