using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeEnemy : MonoBehaviour
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
    [SerializeField]private Transform player;
    public UnityEvent OnDesesperation;
    [SerializeField] public bool isDesesperation;
    [SerializeField] private float effectDuration = 3.0f;
    [SerializeField] private float maxDegreeDelta = 2.0f;
    public static MeleeEnemy Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
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
        if(isDesesperation)
        {
            OnDesesperation.Invoke();
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
        }
        else if (Vector3.Distance(transform.position, player.position) < stop_distance && Vector3.Distance(transform.position, player.position) > retreat_distance)
        {
            transform.position = this.transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxDegreeDelta);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeSystem.Instance.HurtPlayer(meleeDamage);
            canDamage = false;
            Player.Instance.onDesesperation = true;
            StartCoroutine(DamageDelay());
        }
    }

    private IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(damageDelay);
        canDamage = true;
    }   
}
