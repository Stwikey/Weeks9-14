using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Vector2 position;
    public float speed = 5;
    public GameObject fish;



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

    public void Eat(GameObject fishEat)
    {
    }


}
