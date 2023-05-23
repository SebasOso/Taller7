using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Transform player;
    private Vector3 target;
    private Player playerMovement; // Referencia al script PlayerMovement
    private bool hasPlayerMoved; // Flag que indica si el jugador se ha movido
    public float yDelay = 2.0f;
    [SerializeField] private float maxDegreesDelta = 10;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        playerMovement = player.GetComponent<Player>();
        playerMovement.OnPlayerMove.AddListener(OnPlayerMove); // Suscribe a OnPlayerMove
    }

    private void OnPlayerMove()
    {
        hasPlayerMoved = true; // Activa el flag de movimiento del jugador
    }

    private void Update()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        if (hasPlayerMoved) // Si el jugador se ha movido
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector3(player.position.x, player.position.y + yDelay, player.position.z);
            hasPlayerMoved = false; // Reinicia el flag de movimiento del jugador
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxDegreesDelta);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < 0.1f)
        {
            DestroyProjectile();
        }
        else if (player == null)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeSystem.Instance.HurtPlayer(damage);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        EnemyBulletPool.Instance.Return(gameObject);
    }

}