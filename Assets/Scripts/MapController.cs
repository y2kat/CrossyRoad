using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//https://www.youtube.com/watch?v=ANzbLekb33g&list=PLjCKKt9GhZuJzJKJu3pFS1PM1TkaW71p4&index=2
public class MapController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputActions map;
    public float forceMovement = 1;

    [SerializeField]
    private int lane = 0;
    [SerializeField]
    public GameObject[] tiles;
    [SerializeField]
    private int tileDifference = 20;

    public Transform parentObject;
    public GameObject player;

    private void Awake()
    {
        map = new PlayerInputActions();
        map.Enable();
    }

    void Start()
    {
        for (int i = 0; i < tileDifference; i++)
        {
            CreateTile();
        }

        map.Standard.Movement.performed += MapMovement;
    }

    private void MapMovement(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        if (movementInput.y > 0)
        {
            // Mueve el mapa en la dirección opuesta al jugador
            Vector3 direction = new Vector3(0, 0, -movementInput.y) * forceMovement;
            transform.Translate(direction);

            // Genera un nuevo tile
            CreateTile();

            if (player.transform.position.z >= tiles[tiles.Length - 5].transform.position.z)
            {
                // Genera tiles adicionales
                for (int i = 0; i < 3; i++)
                {
                    CreateTile();
                }
            }
        }
    }

    public void CreateTile()
    {
        Vector3 spawnPosition = parentObject.position + Vector3.forward * lane;
        Instantiate(tiles[Random.Range(0, tiles.Length)], spawnPosition, Quaternion.identity, parentObject);
        lane++;
    }
}
