using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player; // El objeto del jugador
    private Vector3 offset; // La distancia inicial entre la c�mara y el jugador

    void Start()
    {
        // Calcula la distancia inicial entre la c�mara y el jugador
        offset = transform.position - player.transform.position;
        offset.y += 10f;
    }

    void LateUpdate()
    {
        // Actualiza la posici�n de la c�mara en el eje Z para que coincida con la del jugador
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);
    }
}
