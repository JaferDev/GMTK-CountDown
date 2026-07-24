using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float impactForce = 10f;

    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject winPanel;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winPanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;

        CollisionForce();
        DeathScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("WinCon")) return;

        winPanel.SetActive(true);
    }

    private void CollisionForce()
    {
        rb.AddForceY(impactForce, ForceMode2D.Impulse);
    }

    private void DeathScreen()
    {
        deathPanel.SetActive(true);
    }
}
