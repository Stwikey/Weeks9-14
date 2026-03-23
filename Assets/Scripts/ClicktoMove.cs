using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClicktoMove : MonoBehaviour
{
    public Vector2 movement;
    public LineRenderer line;
    public List<Vector2> points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = new List<Vector2>();
        points.Add(transform.position);
        line.positionCount = points.Count;
        for(int i = 0; i < points.Count; i++)
        {
            line.SetPosition(i, points[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        points.Add(movement);

    }

    public void OnAttack(InputAction.CallbackContext context)
    {

        StartCoroutine(toMouse());
    }

    public IEnumerator toMouse()
    {
        while (Vector2.Distance(points[0], points[points.Count-1]) > 1)
        {
            Vector2 direction = points[0] - (Vector2)transform.position;
            transform.up = direction;
            while (Vector2.Distance(points[0], (Vector2)transform.position) > 1)
            {
                transform.position += transform.up;
                yield return null;

            }
            if (Vector2.Distance(points[0], (Vector2)transform.position) <= 1)
            {
                points.RemoveAt(0);
                UpdateLine();
            }
            yield return null;

        }
    }




    void UpdateLine()
    {
        line.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            line.SetPosition(i, points[i]);
        }

    }

}
