using UnityEngine;

public class CrushingBlock : MonoBehaviour
{
    public float moveDistance = 3f;
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    public Vector2 direction = Vector2.up;
    public bool isMovingDown = false; 

    private Vector2 lastPosition;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingDown = true;
    private float waitTimer;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + (Vector3)(-direction.normalized * moveDistance);
        waitTimer = waitTime;
        lastPosition = transform.position;
    }

    void Update()
    {

        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        Vector3 target = movingDown ? targetPos : startPos;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            movingDown = !movingDown;
            waitTimer = waitTime;
        }
        isMovingDown = transform.position.y < lastPosition.y;
        lastPosition = transform.position;
    }
}
