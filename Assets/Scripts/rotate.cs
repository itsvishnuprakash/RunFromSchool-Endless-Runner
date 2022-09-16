using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Vector3 turnVelocity=new Vector3(0f,2f,0f);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnVelocity*Time.deltaTime);
    }
}
