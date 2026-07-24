using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float endTime = 10f;

    private void Update()
    {
        CountDown();
    }

    private void CountDown() { timerText.text = Mathf.FloorToInt(endTime - Time.time).ToString(); }
}