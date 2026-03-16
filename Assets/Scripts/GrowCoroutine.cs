using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GrowCoroutine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform thing;
    public AnimationCurve curve;
    public Button button;
    void Start()
    {
        thing.localScale = Vector2.zero;
        StartCoroutine(Grow());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void growFlora()
    {
        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        button.interactable = false;
        float t = 0;
        thing.localScale = Vector2.zero;
        while (t < 1)
        {
            t += Time.deltaTime;
            thing.localScale = Vector2.one * curve.Evaluate(t);
            yield return null;
        }
        button.interactable = true;

    }
}
