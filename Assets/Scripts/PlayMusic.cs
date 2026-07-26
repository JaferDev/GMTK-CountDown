using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private void Start()
    {
        FindAnyObjectByType<AudioManager>().PlayOnce("Jingle");
    }

}
