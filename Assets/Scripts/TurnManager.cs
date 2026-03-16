using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Button playerAButton;
    public Button playerBButton;
    public GameObject playerA;
    public GameObject playerB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnableManager());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator EnableManager()
    {
        playerAButton.interactable = true;
        playerBButton.interactable = false;
        while (playerA.GetComponent<GrowCoroutine>().finished == false)
        {
            yield return null;
        }
        playerAButton.interactable = false;
        playerBButton.interactable = true;
        while (playerB.GetComponent<GrowCoroutine>().finished == false)
        {
            yield return null;
        }
    }
}
