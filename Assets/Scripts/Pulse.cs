using UnityEngine;

public class Pulse : MonoBehaviour
{
    public float speed = 10f;
    public AnimationCurve curve;
    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 1) {
            t = 0;
        }
        Vector2 movement = transform.position;
        movement.x += speed * Time.deltaTime;
        movement.y = curve.Evaluate(t);
        transform.position = movement;
        if (Camera.main.WorldToScreenPoint(transform.position).x >= Screen.width)
        {
            movement.x = Camera.main.ScreenToWorldPoint(new Vector2 (0f, transform.position.y)).x;
            transform.position = movement;
        }
        
        
    }
}
