using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 position;
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)position*speed*Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }
}
