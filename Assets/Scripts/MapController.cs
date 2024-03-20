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
    public GameObject[] tiles;
    private int tileDifference;

    public Transform tileSpawnPoint;

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
        Vector3 direction = new Vector3(0, 0, movementInput.y) * forceMovement;
        transform.Translate(direction);
        if (movementInput.y > 0)
        {
            CreateTile();
        }
    }

    public void CreateTile()
    {
        Vector3 spawnPosition = tileSpawnPoint.position - Vector3.forward * lane;
        Instantiate(tiles[Random.Range(0, tiles.Length)], Vector3.forward * lane, Quaternion.identity);
        lane++;
    }
}
