using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kaiju : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
    public CinemachineImpulseSource impulseSource;
    public Vector2 movement;
    public float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        if (movement == Vector2.zero)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

    }

    public void kaiju()
    {
        impulseSource.GenerateImpulse();
    }



    public void OnMove(InputAction.CallbackContext context) 
    {
        movement = context.ReadValue<Vector2>();
    }
        
    


}
