using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && respawnPoint != null)
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
