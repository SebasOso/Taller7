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
    private Jugador playerMovement; // Referencia al script PlayerMovement
    private bool hasPlayerMoved; // Flag que indica si el jugador se ha movido

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        playerMovement = player.GetComponent<Jugador>();
        playerMovement.OnPlayerMove.AddListener(OnPlayerMove); // Suscribe a OnPlayerMove
    }

    private void OnPlayerMove()
    {
        hasPlayerMoved = true; // Activa el flag de movimiento del jugador
    }

    private void Update()
    {
        if (hasPlayerMoved) // Si el jugador se ha movido
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector3(player.position.x, player.position.y, player.position.z);
            hasPlayerMoved = false; // Reinicia el flag de movimiento del jugador
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

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
            //playerTarget.GetComponent<PlayerLife>().HurtPlayer(damage);
            LifeSystem.Instance.HurtPlayer(damage);
            //Debug.Log("Prueba cosa");
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        EnemyBulletPool.Instance.Return(gameObject);
    }
}