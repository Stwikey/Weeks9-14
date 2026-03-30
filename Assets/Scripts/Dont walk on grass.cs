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
    public Animator anim;
    public AudioSource SFX;
    public float scale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        newPosition = Vector2.Lerp(transform.position, mousePos, Time.deltaTime);
        transform.position = newPosition;
        if (t > 1)
        {
            t = 0;
        }
        if(Vector2.Distance(transform.position, mousePos) < 1)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

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
        if (movement.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void Footsteps()
    {
        cellPos = tilemap.WorldToCell(transform.position);
        if (tilemap.GetTile(cellPos) != grass)
        {
            SFX.Play();

        }
        
    }
}
