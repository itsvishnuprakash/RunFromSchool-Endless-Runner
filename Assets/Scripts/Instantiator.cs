using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public float obstaclerespawnTime=2.6f;
    public float collectableRespwanTime=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleWave()); 
        StartCoroutine(CollectableWave()); 
    }
    void SpawnObstacle()
    {
        GameObject obstacle=ObstaclePool.instance.GetPooledObject();
        if(obstacle!=null)
        {
            obstacle.transform.position=new Vector3(Random.Range(-2.1f,2.0f),0f,12.8f);
            obstacle.SetActive(true);
        }
    }
    void SpawnCollectable()
    {
        GameObject collectable=CollectablePool.instance.GetPooledObject();
        if(collectable!=null)
        {
            collectable.transform.position=new Vector3(Random.Range(-2.0f,2.0f),0.8f,12.8f);
            collectable.SetActive(true);
        }
    }
    IEnumerator ObstacleWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(obstaclerespawnTime);
            SpawnObstacle();
        }
    }
    IEnumerator CollectableWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(collectableRespwanTime);
            SpawnCollectable();
        }
    }
}
