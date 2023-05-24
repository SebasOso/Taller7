using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyRangeHealth : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private GameObject healthBar;
    private Renderer healthBarMaterial;
    [SerializeField] private Animator animator;
    public TutorialEnemyRangeHealth Instance { get; private set; }
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
            TutorialEvents.Instance.enemyRangeIsDead = true;
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
        animator.SetBool("isMoving", false);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
