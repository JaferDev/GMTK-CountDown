using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float sdFactor = 0.05f; //Lower = slower
    [SerializeField] float sdLength = 2f;
    private bool slowedDown = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) SlowDown();

        if (slowedDown) Time.timeScale += (1 / sdLength) * Time.unscaledDeltaTime;
        if (Time.timeScale == 1) slowedDown = false;
    }

    private void SlowDown()
    {
        slowedDown = true;
        Time.timeScale = sdFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
