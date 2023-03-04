using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody rb;
    public float speed = 5f;
    public float rotationSpeed = 50f;
    public SpawnEnemy spawnEnemy;
    public UnityEvent OnPlayerMove;
    private bool enemySpawn;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;

        if (movementDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);

        if (transform.hasChanged)
        {
            OnPlayerMove.Invoke(); 
            transform.hasChanged = false; 
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CombatZone" && !enemySpawn)
        {
            spawnEnemy.Spawn();
            enemySpawn = true;
        }
    }
}
