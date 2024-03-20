using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//https://www.youtube.com/watch?v=ANzbLekb33g&list=PLjCKKt9GhZuJzJKJu3pFS1PM1TkaW71p4&index=2
public class MapController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputActions map;
    private float forceMovement = 5;

    [SerializeField]
    private int lane = 0;
    public GameObject[] tiles;
    private int tileDifference;

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
        Instantiate(tiles[Random.Range(0, tiles.Length)], Vector3.forward * lane, Quaternion.identity);
        lane++;
    }
}
