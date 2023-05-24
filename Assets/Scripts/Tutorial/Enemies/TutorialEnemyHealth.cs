using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialEnemyHealth : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private GameObject healthBar;
    private Renderer healthBarMaterial;
    public TutorialEnemyHealth Instance { get; private set; }
    [SerializeField] private Animator animator;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        healthBarMaterial = healthBar.GetComponent<Renderer>();
    }
    private void Update()
    {
        if (health > 0f)
        {
            if (health >= 50f)
            {
                healthBarMaterial.material.color = Color.green;
            }
            else if (health >= 25f)
            {
                healthBarMaterial.material.color = Color.yellow;
            }
            else
            {
                healthBarMaterial.material.color = Color.red;
            }
        }
        else
        {
            TutorialMovement.Instance.enemyIsDead = true;
            TutorialEvents.Instance.meleeEnemyIsDead = true;
            StartCoroutine(Wait());
        }
    }
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hurt");
        health -= damage;
    }
    private IEnumerator Wait()
    {
        animator.SetTrigger("dead");
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
