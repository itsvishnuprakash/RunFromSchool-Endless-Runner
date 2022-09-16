using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public static ObstaclePool instance;
    private List<GameObject> pooledObjects=new List<GameObject>();
    int amountToPool=2;
    [SerializeField] private GameObject[] prefab;
    private void Awake() 
    {
        if(instance==null)
        {
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int j=0;j<prefab.Length;j++)
        {
            
            for(int i=0;i<amountToPool;i++)
            {
                GameObject obj=Instantiate(prefab[j]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        
    }

    public GameObject GetPooledObject()
    {
        int i=Random.Range(0,pooledObjects.Count);
        if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }

        // for(int i=0;i<pooledObjects.Count;i++)
        // {
        //     if(!pooledObjects[i].activeInHierarchy)
        //     {
        //         return pooledObjects[i];
        //     }
        // }
        return null;
    }
}
