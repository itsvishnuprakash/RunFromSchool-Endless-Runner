using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(-0.22f,transform.position.y,transform.position.z);
    }
}
