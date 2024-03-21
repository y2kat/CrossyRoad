using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab; // Asigna tu prefab de moneda aquí en el Inspector de Unity
    public float roadLength = 5f; // Ajusta esto al largo de tu carretera

    void Start()
    {
        GenerateCoins();
    }

    void GenerateCoins()
    {
        // Genera monedas en una posición aleatoria a lo largo del largo de la carretera
        float randomX = Random.Range(-roadLength / 2, roadLength / 2);
        Vector3 coinPosition = new Vector3(transform.position.x + randomX, transform.position.y + .5f, transform.position.z); // Ajusta la posición y altura como necesites
        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }
}
