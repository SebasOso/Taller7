using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePool : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private int poolSize = 4;
    [SerializeField] private List<GameObject> healthList;

    private static LifePool instance;
    public static LifePool Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AddHealthToPool(poolSize);
    }

    private void AddHealthToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject health = Instantiate(healthPrefab);
            health.SetActive(false);
            healthList.Add(health);
            health.transform.parent = transform;
        }
    }

    public GameObject requestHealth()
    {
        for (int i = 0; i < healthList.Count; i++)
        {
            if (!healthList[i].activeSelf)
            {
                healthList[i].SetActive(true);
                return healthList[i];
            }
        }
        AddHealthToPool(1);
        healthList[healthList.Count - 1].SetActive(true);
        return healthList[healthList.Count - 1];
    }
}
