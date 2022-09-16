using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z<=-34f)
        {
            gameObject.SetActive(false);
            
        }
    }
}
