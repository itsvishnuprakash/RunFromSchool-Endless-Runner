using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePool : MonoBehaviour
{
    public static CollectablePool instance;
    private List<GameObject> pooledObjects=new List<GameObject>();
    public int amountToPool=5;
    [SerializeField] private GameObject[] collectablePrefab;
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
        for(int j=0;j<collectablePrefab.Length;j++)
        {
            for(int i=0;i<amountToPool;i++)
            {
                GameObject obj=Instantiate(collectablePrefab[j]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        // for(int i=0;i<amountToPool;i++)
        // {
        //     GameObject obj=Instantiate(collectablePrefab[i]);
        //     obj.SetActive(false);
        //     pooledObjects.Add(obj);
        // }
        
    }

    public GameObject GetPooledObject()
    {
        for(int i=0;i<pooledObjects.Count;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
