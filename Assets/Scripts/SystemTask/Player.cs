using UnityEngine;
using UnityEngine.InputSystem;

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
        if (checkCollision(fish, gameObject))
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }

    public bool checkCollision(GameObject fish, GameObject player)
    {
        Vector2 fishPos = fish.transform.position;
        Vector2 playerPos = player.transform.position;

        float fishLength = fish.transform.localScale.x;
        float playerLength = player.transform.localScale.x;

        float fishWidth = fish.transform.localScale.x / 2;
        float playerWidth = player.transform.localScale.x / 2;

        if (Mathf.Abs(fishPos.x - playerPos.x) <= fishLength + playerLength)
        {
            return true;
        }
        else if (Mathf.Abs(fishPos.y - playerPos.y) <= fishWidth + playerWidth)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
}
