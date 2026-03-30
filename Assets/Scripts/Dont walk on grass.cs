using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Dontwalkongrass : MonoBehaviour
{
    public Vector2 movement;
    public Vector2 newPosition;
    public float t = 0;
    public Vector2 mousePos;
    public Tilemap tilemap;
    public Tile grass;
    public Vector3Int cellPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = Vector2.Lerp(transform.position, mousePos, Time.deltaTime);
        transform.position = newPosition;
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        cellPos = tilemap.WorldToCell(movement);
        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (tilemap.GetTile(cellPos) == grass)
        {

        }
        else
        {
            mousePos = movement;
        }
            
    }
}
