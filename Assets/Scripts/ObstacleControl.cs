using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float impactForce = 10f;
    
    [SerializeField] Vector2 startPos;
    [SerializeField] float deathTime = 1;
    [SerializeField] TimeManager timeMgr;
    [SerializeField] int currentLvl;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float endTime = 10f;

    private bool isReturning = false;
    private float time = 0f;

    private float startTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindAnyObjectByType<AudioManager>().Play("Song");
        startTime = Time.time;
    }

    private void Update()
    {
        DisplayCountdown();
        if (!isReturning) return;

        timerText.text = "...";
        time += Time.unscaledDeltaTime;
        if (time >= deathTime) ReturnByDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;

        CollisionForce();
        isReturning = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("WinCon")) return;
        SceneManager.LoadScene(currentLvl + 1);
    }

    private void CollisionForce()
    {
        //timeMgr.SlowDown();
        FindAnyObjectByType<AudioManager>().PlayOnce("FallSound");
        rb.AddForceY(impactForce, ForceMode2D.Impulse);
    }

    private void ReturnByDeath()
    {
        FindAnyObjectByType<AudioManager>().PlayOnce("Return");

        //Resetting variables
        time = 0;
        isReturning = false;
        startTime = Time.time;

        //Placing player back
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }

    private void DisplayCountdown()
    {
        timerText.text = Mathf.FloorToInt(endTime - (Time.time - startTime)).ToString();
    }
}