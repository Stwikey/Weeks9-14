using UnityEngine;
using UnityEngine.Events;


public class FishMovement : MonoBehaviour
{
    public float speed = 3;
    public Vector3 fishMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        checkBounds();

        //moves the fish across the screen
        fishMovement = transform.position;
        fishMovement.x = transform.position.x + speed * Time.deltaTime;
        transform.position = fishMovement;
        
    }

    //checks if the player is out of the screen
    void checkBounds()
    {
        if (transform.localScale.x < 0 && transform.position.x < -20)
        {
            //if it is, destroy it
            Destroy(gameObject);
        }
        if (transform.localScale.x > 0 && transform.position.x > 20)
        {
            // if it is, destroy it
            Destroy(gameObject);
        }

    }



}
