using System.Collections.Generic;
using UnityEngine;

public class TrainObjectPool : MonoBehaviour
{
    public static TrainObjectPool SharedInstance;
    public List<GameObject> PooledTrains;
    public GameObject TrainPrefab;
    public int AmountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        PooledTrains = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < AmountToPool; i++)
        {
            tmp = Instantiate(TrainPrefab);
            tmp.SetActive(false);
            PooledTrains.Add(tmp);
        }
    }

    public GameObject GetPooledTrain()
    {
        for (int i = 0; i < AmountToPool; i++)
        {
            if (!PooledTrains[i].activeInHierarchy)
            {
                return PooledTrains[i];
            }
        }
        return null;
    }
}