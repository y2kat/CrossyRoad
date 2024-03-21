using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("car"))
        {
            other.transform.Translate(0,0,40);
        }
    }
}
