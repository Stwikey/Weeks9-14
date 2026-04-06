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
    public AudioSource SFX;
    public TrailRenderer trail;
    Coroutine dash;
    Coroutine squeeze;
    void Start()
    {
        squeeze = StartCoroutine(Squeeze());
        dash = StartCoroutine(Dash());
        StopCoroutine(dash);
        StopCoroutine(squeeze);
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
            SFX.Play();
            StopCoroutine(squeeze);
 
            StartCoroutine(Squeeze());

            Debug.Log("Attack!" + playerInput.playerIndex);
            manager.PlayerAttacking(playerInput);

        }

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("interact");
            StopCoroutine(dash);

            dash = StartCoroutine(Dash());
           


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

    public IEnumerator Dash()
    {
        trail.emitting = true;
        speed = 10;
        yield return new WaitForSeconds(1);
        trail.emitting = false;
        speed = 5;
    }
}
