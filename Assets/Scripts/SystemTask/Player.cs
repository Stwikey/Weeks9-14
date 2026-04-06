using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Vector2 position;
    public float speed = 5;
    public GameObject fish;
    public UnityEvent gameEnd;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)position*speed*Time.deltaTime;
        //if the fish is big enough, invoke a unity event to end the game
        if (transform.localScale.x > 30f)
        {
            gameEnd.Invoke();

            //keeps the player in the same position when the game ends
            transform.position = new Vector2(0f, 0f);
        }
        
        

    }
    //basic movement done with the input system
    public void OnMove(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }

    //if it collided with a fish, change the player size by half the fish size
    public void Eat(float fishSize)
    {
        fishSize = Mathf.Abs(fishSize);
        Vector3 newPlayerScale = new Vector3(fishSize/2, fishSize/2, fishSize/2);
        transform.localScale += newPlayerScale;

    }


}
