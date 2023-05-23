using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMeleeEnemie : MonoBehaviour
{
    [SerializeField] private int meleeDamage = 1;
    [SerializeField] private float retreat_distance;
    [SerializeField] private float stop_distance;
    [SerializeField] private float speed;
    [SerializeField] private float damageDelay;
    [SerializeField] private float radio;
    [SerializeField] private bool playerDetected = false;
    [SerializeField] private LayerMask playerMask;
    private EnemyHealth health;
    private bool canDamage;
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    [SerializeField] private float maxDegreeDelta = 2.0f;
    void Start()
    {
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDetected = Physics.CheckSphere(transform.position, radio, playerMask);
        if (playerDetected)
        {
            Debug.Log("Te vi gonorrea");
            EnemyMovement();
        }
    }

    private void EnemyMovement()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        if (Vector3.Distance(transform.position, player.position) > stop_distance)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxDegreeDelta);
            animator.SetBool("isMoving", true);
        }
        else if (Vector3.Distance(transform.position, player.position) < stop_distance && Vector3.Distance(transform.position, player.position) > retreat_distance)
        {
            transform.position = this.transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxDegreeDelta);
            animator.SetBool("isMoving", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            animator.SetTrigger("attack");
            animator.SetBool("isMoving", false);
            TutorialLife.Instance.HurtPlayer(meleeDamage);
            canDamage = false;
            TutorialMovement.Instance.onDesesperation = true;
            StartCoroutine(DamageDelay());
        }
    }

    private IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(damageDelay);
        canDamage = true;
    }
}
