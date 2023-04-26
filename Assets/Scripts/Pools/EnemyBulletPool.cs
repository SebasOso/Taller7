using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{

    public GameObject bulletPrefab;
    public int initialAmount = 10;

    List<GameObject> enemyPool = new List<GameObject>();

    private static EnemyBulletPool instance;
    public static EnemyBulletPool Instance { get { return instance; } }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        FillPoll();
    }

    void FillPoll()
    {
        for (int t = 0; t < initialAmount; t++)
        {
            GameObject go = Instantiate(bulletPrefab);
            go.SetActive(false);
            enemyPool.Add(go);
        }
    }

    public GameObject Get()
    {
        GameObject ret;
        if (enemyPool.Count > 0)
        {
            ret = enemyPool[enemyPool.Count - 1];
            enemyPool.RemoveAt(enemyPool.Count - 1);
        }
        else
        {
            ret = Instantiate(bulletPrefab);
        }
        ret.SetActive(true);
        return ret;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        enemyPool.Add(go);
    }



}
