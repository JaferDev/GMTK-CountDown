using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float sdFactor = 0.05f; //Lower = slower
    [SerializeField] float sdLength = 2f;

    private void Update()
    {
        Time.timeScale += (1 / sdLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void SlowDown()
    {
        Time.timeScale = sdFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
