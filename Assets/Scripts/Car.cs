using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
