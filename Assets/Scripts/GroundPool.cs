using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPool : MonoBehaviour
{
    public static GroundPool instance;
    private List<GameObject> pooledObjects=new List<GameObject>();
    int amountToPool=2;
    [SerializeField] private GameObject groundPrefab;
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
        for(int i=0;i<amountToPool;i++)
        {
            GameObject obj=Instantiate(groundPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
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
