using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    Rigidbody2D rb;

    Vector2 moveInput;

    public bool hasCamera = false;
    bool canPickUp = false;
    GameObject camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        if (Keyboard.current.xKey.wasPressedThisFrame && canPickUp && !hasCamera)
        {
            hasCamera = true;
            Debug.Log("!!!");
            Destroy(camera);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            canPickUp = true;
            camera = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            canPickUp = false;
            camera = null;
        }
    }
}
