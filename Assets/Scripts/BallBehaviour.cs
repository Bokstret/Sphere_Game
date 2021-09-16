using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 dir = new Vector3(0, 0, 0.1f);
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.maxAngularVelocity = terminalRotationSpeed;
        rb.drag = drag;
    }

    private void Update()
    {
        if (BallFire.rbBullet != null)
            BallFire.rbBullet.AddForce(dir * moveSpeed*3);
        rb.AddForce(dir * moveSpeed);
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
