using System.Collections;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector{set; get;}
    public VirtualJoystick joystick;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.maxAngularVelocity = terminalRotationSpeed;
        rb.drag = drag;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveVector = PoolInput();
        Move();
    }

    private void Move()
    {
        rb.AddForce((MoveVector * moveSpeed));
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }
}
