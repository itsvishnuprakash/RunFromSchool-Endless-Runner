using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
