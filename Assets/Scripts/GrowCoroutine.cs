using System.Collections;
using UnityEngine;

public class GrowCoroutine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform thing;
    public AnimationCurve curve;
    void Start()
    {
        thing.localScale = Vector2.zero;
        StartCoroutine(Grow());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Grow()
    {
        float t = 0;
        thing.localScale = Vector2.zero;
        while (t < 1)
        {
            t += Time.deltaTime;
            thing.localScale = Vector2.one * curve.Evaluate(t);
            yield return null;
        }

    }
}
