using UnityEngine;

public class Track : MonoBehaviour
{
    public bool isMovingDown = false;
    private Vector2 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        isMovingDown = transform.position.y < lastPosition.y;
        lastPosition = transform.position;
    }
}
