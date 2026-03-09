using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStickBarrel : MonoBehaviour
{
    Vector2 rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {

        rotation = context.ReadValue<Vector2>() - (Vector2)transform.position;
        transform.up = rotation;
    }

}
