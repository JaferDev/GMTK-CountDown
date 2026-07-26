using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject levelSelectPanel;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        FindAnyObjectByType<AudioManager>().Play("Song");
    }

    public void OpenLevelSelect()
    {
        FindAnyObjectByType<AudioManager>().PlayOnce("Click");
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void LevelSelect(int buildIndex)
    {
        FindAnyObjectByType<AudioManager>().PlayOnce("Click");
        SceneManager.LoadScene(buildIndex);
    }
}
