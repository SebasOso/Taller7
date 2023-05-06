using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("General")]
    public int rutine;
    public float timekeeper;
    public Animator animator;
    public Quaternion angle;
    public float degree;
    public GameObject target;
    public bool isAttacking;
    public BossRange range;
    public float speed;
    public GameObject[] hit;
    public int hitSelect;

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
    /// </FlameThrower>


    /// <ThrowingObjects>
    [Header("Throwing Objects")]
    public GameObject objectToThrow;
    public GameObject pointFrom;
    public List<GameObject> objectPool = new List<GameObject>();
    /// </ThrowingObjects>
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
