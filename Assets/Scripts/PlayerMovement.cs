using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float fallSpeed = 0.5f;

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - fallSpeed);
        PlayerInput();    
    }

    private void PlayerInput()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        if (Input.GetKey(KeyCode.A)) transform.position = new Vector2(xPos - speed, yPos);
        if (Input.GetKey(KeyCode.D)) transform.position = new Vector2(xPos + speed, yPos);
    }
}
