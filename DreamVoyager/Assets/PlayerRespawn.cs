using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // This is where the player will respawn from

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is a bed
        if (other.CompareTag("RespawnBed"))
        {
            Debug.Log("Touched bed — updating respawn point.");
            respawnPoint.position = other.transform.position;
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
    }
}
