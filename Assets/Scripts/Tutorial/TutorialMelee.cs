using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMelee : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private float playerDamage;
    [SerializeField] private float attackSpeed;
    private float lastAttackTime = -Mathf.Infinity;
    [SerializeField] GameObject meleeSign;
    private bool isAttacking = false;
    [SerializeField] private Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + 1f / attackSpeed)
        {
            isAttacking = true;
            Attack();
            lastAttackTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
        }
        meleeSign.SetActive(isAttacking);
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        Collider[] enemiesCollider = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider enemies in enemiesCollider)
        {
            if (enemies.CompareTag("Enemy"))
            {
                enemies.GetComponent<TutorialEnemyHealth>().TakeDamage(playerDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
