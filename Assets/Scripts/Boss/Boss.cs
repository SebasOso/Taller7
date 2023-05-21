using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("General")]
    public int rutine = 1;
    public float timekeeper;
    public Animator animator;
    public Quaternion angle;
    public float degree;
    public GameObject target;
    public bool isAttacking;
    public float speed;
    public GameObject[] hit;
    public int hitSelect;
    public int rangeStart = 20;
    //public bool canAttack = false;

    [Header("Base")]
    public int fase = 1;
    public float minHealth;
    public float maxHealth;
    public Image healthBar;
    public AudioSource battleMusic;
    public bool isDead;

    /// <FlameThrower>
    [Header("Flame Thrower")]
    public bool flamethrower;
    public List<GameObject> flamePool = new List<GameObject>();
    public GameObject fire;
    public GameObject head;
    private float timekeeper2;
    /// </FlameThrower>


    /// <ThrowingObjects>
    [Header("Throwing Objects")]
    public GameObject objectToThrow;
    public GameObject pointFrom;
    public List<GameObject> objectPool = new List<GameObject>();
    public static Boss Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        healthBar.fillAmount = minHealth / maxHealth;
        if (minHealth > 0)
        {
            Alive();
        }
        else
        {
            if (!isDead)
            {
                animator.SetTrigger("dead");
                battleMusic.enabled = false;
                isDead = true;
            }
        }
    }
    public void Behavior()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < rangeStart)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            pointFrom.transform.LookAt(target.transform.position);
            battleMusic.enabled = true;
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !isAttacking)
            {
                switch (rutine)
                {
                    case 0:
                        //FlameThrower
                        animator.SetBool("attack", true);
                        animator.SetFloat("skills", 0.8f);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        break;
                    case 1:
                        //ThrowObject
                        animator.SetBool("attack", true);
                        animator.SetFloat("skills", 1);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                        break;
                }
            }
        }
    }
    public void FinalAni()
    {
        //rutine = 1;
        animator.SetBool("attack", false);
        isAttacking = false;
        flamethrower = false;
    }
    public void ColliderWeaponTrue()
    {
        hit[hitSelect].GetComponent<Collider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hit[hitSelect].GetComponent<Collider>().enabled = false;
    }
    public GameObject GetBullet()
    {
        for (int i = 0; i < flamePool.Count; i++)
        {
            if (!flamePool[i].activeInHierarchy)
            {
                flamePool[i].SetActive(true);
                return flamePool[i];
            }
        }
        GameObject obj = Instantiate(fire, head.transform.position, head.transform.rotation) as GameObject;
        flamePool.Add(obj);
        return obj;
    }
    public void FlameThrower()
    {
        timekeeper2 += 1 * Time.deltaTime;
        if (timekeeper2 > 0.1f)
        {
            GameObject obj = GetBullet();
            obj.transform.position = head.transform.position;
            obj.transform.rotation = head.transform.rotation;
            timekeeper2 = 0;
        }
    }
    public void StartFire()
    {
        flamethrower = true;
    }
    public void StopFire()
    {
        flamethrower = false;
    }
    public GameObject GetThrowingObject()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                objectPool[i].SetActive(true);
                return objectPool[i];
            }
        }
        GameObject obj = Instantiate(objectToThrow, pointFrom.transform.position, pointFrom.transform.rotation) as GameObject;
        objectPool.Add(obj);
        return obj;
    }
    public void ThrowingObject()
    {
        GameObject obj = GetThrowingObject();
        obj.transform.position = pointFrom.transform.position;
        obj.transform.rotation = pointFrom.transform.rotation;
    }
    public void Alive()
    {
            Behavior();
            if (flamethrower)
            {
                FlameThrower();
            }
    }
    public void HurtBoss(float damage)
    {
        if (minHealth > 0)
        {
            minHealth -= damage;
        }
    }
}