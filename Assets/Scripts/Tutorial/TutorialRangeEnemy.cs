using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRangeEnemy : MonoBehaviour
{
    [SerializeField] private float retreat_distance;
    [SerializeField] private float stop_distance;
    [SerializeField] private float speed;
    private bool canTakeDamage = true;
    private float timeBetweenShots;
    [SerializeField] private float damageDelay;
    [SerializeField] private float startTimeBetweenShots;
    [SerializeField] private float radio;
    [SerializeField] private bool playerDetected = false;
    [SerializeField] private LayerMask playerMask;
    private TutorialEnemyRangeHealth health;
    [SerializeField] private Transform player;
    void Start()
    {
        health = GetComponent<TutorialEnemyRangeHealth>();
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        playerDetected = Physics.CheckSphere(transform.position, radio, playerMask);
        if (playerDetected)
        {
            EnemyMovement();
            Bullets();
            //Debug.Log("HOY TE MUEREEEEEEEEEEEEEEES");
            HurtEnemyRange();
        }
    }

    private void EnemyMovement()
    {
        if (Vector3.Distance(transform.position, player.position) > stop_distance)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stop_distance && Vector3.Distance(transform.position, player.position) > retreat_distance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) <= retreat_distance)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, -speed * Time.deltaTime);
        }
    }

    private void Bullets()
    {
        if (timeBetweenShots <= 0 && TutorialMovement.Instance.isMoving)
        {
            Vector3 position = transform.position;
            EnemyBulletPool.Instance.Get().transform.position = this.transform.position;
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    private void HurtEnemyRange()
    {
        if (!TutorialMovement.Instance.isMoving && canTakeDamage)
        {
            health.TakeDamage(TutorialMovement.Instance.stayDamage);
            canTakeDamage = false;
            StartCoroutine(ResetCanTakeDamage());
        }
    }
    private IEnumerator ResetCanTakeDamage()
    {
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }
}
