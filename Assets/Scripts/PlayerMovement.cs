using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float strafeSpeed = 0.1f;
    [SerializeField] float fallSpeed = 0.5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerFall();
    }

    private void FixedUpdate()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        if (Input.GetKey(KeyCode.A)) transform.position = new Vector2(xPos - strafeSpeed, yPos);
        if (Input.GetKey(KeyCode.D)) transform.position = new Vector2(xPos + strafeSpeed, yPos);
    }

    private void PlayerFall()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime);
    }
}