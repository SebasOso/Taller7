using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUps : MonoBehaviour
{
    LifeSystem playerHealth;

    public float healthBonus = 0;

    public GameObject vfxCollectHealth;


    void Awake()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LifeSystem.Instance.health += healthBonus;
            Vector3 position = transform.position;
            GameObject HealthRecolect = Instantiate(vfxCollectHealth) as GameObject;
            HealthRecolect.transform.position = position;
            Destroy(HealthRecolect, 1);
            gameObject.SetActive(false);
        }
    }
}
