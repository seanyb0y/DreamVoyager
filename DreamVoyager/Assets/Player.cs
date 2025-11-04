using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float speed = 5;
    public float xDir = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(xDir * speed * Time.deltaTime, 0, 0));
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        xDir = ctx.ReadValue<Vector2>().x;
    }


}
