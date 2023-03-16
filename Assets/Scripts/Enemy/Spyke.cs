using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyke : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    public float damageDelay = 1.0f;
    private bool canDamage = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            LifeSystem.Instance.HurtPlayer(damage);
            canDamage = false;
            StartCoroutine(DamageDelay());
        }
    }

    private IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(damageDelay);
        canDamage = true;
    }
}
