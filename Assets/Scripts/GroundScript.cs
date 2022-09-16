using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    
    public float speed=5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f,0f,-1f)*speed*Time.deltaTime,Space.World);
    }

}
