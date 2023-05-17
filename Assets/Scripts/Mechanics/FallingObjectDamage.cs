using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectDamage : MonoBehaviour
{
    public int playerDamage = 1;
    public LifeSystem player;
    private float areaWidth;
    private float areaHeight;
    public float gravityVelocity = 9.8f;
    private void Start()
    {
        areaWidth = this.transform.localScale.x;
        areaHeight = this.transform.localScale.z;
        Physics.gravity = new Vector3(0, -gravityVelocity, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag != "spawner")
        {
            if (collision.transform.gameObject.tag == "Player")
            {
                player.HurtPlayer(playerDamage);
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
}

    
