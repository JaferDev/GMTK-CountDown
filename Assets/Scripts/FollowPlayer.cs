using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTr;
    [SerializeField] private Vector3 offset;
    private void Update()
    {
        transform.position = new Vector3(offset.x, offset.y + playerTr.position.y, offset.z + playerTr.position.z);
    }
}
