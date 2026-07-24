using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Instantiate(wallPrefab, new Vector3(0, transform.position.y - 60f, 0), Quaternion.identity);
    }
}
