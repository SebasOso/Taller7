using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRange : MonoBehaviour
{
    public Animator animator;
    public Boss boss;
    public int melee;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Te viiiiiiiiiiiiiiiiiiiiiiiiiii soy el bossssssssssss");
            melee = Random.Range(0, 1);
            switch(melee)
            {
                case 0:
                    animator.SetFloat("skills", 0);
                break;
            }
            animator.SetBool("attack", true);
            boss.isAttacking = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
