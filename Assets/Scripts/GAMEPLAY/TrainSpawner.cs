using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public Transform defaultSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
            GameObject train = TrainObjectPool.SharedInstance.GetPooledTrain();
            if (train != null)
            {   
                train.transform.position = defaultSpawnPoint.position + new Vector3(0f, 0f, 50f);
                train.GetComponent<TrainController>().ActivateTrain();
            }
    }
}