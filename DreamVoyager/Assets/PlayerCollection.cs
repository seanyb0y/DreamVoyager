using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Key to interact with objects
    public float interactionDistance = 3f; // Distance to interact with objects

    void Update()
    {
        // Check for the interact key press
        if (Input.GetKeyDown(interactKey))
        {
            // Check for nearby objects with the CollectDreamer script
            InteractWithCollectible();
        }
    }

    private void InteractWithCollectible()
    {
        // Find all objects with the CollectDreamer script
        CollectDreamer[] collectibles = FindObjectsOfType<CollectDreamer>();

        foreach (CollectDreamer collectible in collectibles)
        {
            // Check if the collectible is within interaction distance
            float distance = Vector3.Distance(transform.position, collectible.transform.position);
            if (distance <= interactionDistance)
            {
                // Trigger the fade on the collectible
                collectible.StartFading();
                break; // Interact with only one object at a time
            }
        }
    }
}