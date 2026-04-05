using UnityEngine;

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
        fishMovement = transform.position;
        fishMovement.x = transform.position.x + speed * Time.deltaTime;
        transform.position = fishMovement;
    }
}
