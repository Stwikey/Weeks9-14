using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LocalMultiplayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LocalMultiplayerManager manager;
    public Vector2 movementInput;
    public PlayerInput playerInput;
    public float speed = 5;
    public AnimationCurve curve;
    float t = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            StartCoroutine(Squeeze());
            Debug.Log("Attack!" + playerInput.playerIndex);
            manager.PlayerAttacking(playerInput);

        }

    }
    public IEnumerator Squeeze()
    {
        while (t < 1)
        {
            transform.localScale = new Vector3(curve.Evaluate(t), curve.Evaluate(t), curve.Evaluate(t));
            yield return null;
            t += Time.deltaTime;

        }
        t = 0;
    }
}
