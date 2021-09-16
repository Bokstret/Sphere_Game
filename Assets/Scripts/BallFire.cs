using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BallFire : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullet;

    public static Rigidbody rbBullet;
    public GameObject attack;
    static Timer timerInteract;
    private Vector3 currentBallScale;
    private Vector3 bulletScale;
    private Vector3 scaleChange = new Vector3(0.005f, 0.005f, 0.005f);
    private bool status;
    private float x, y, z;

    void Start()
    {
        timerInteract = gameObject.AddComponent<Timer>();
        timerInteract.Duration = 1;
        status = true;
        attack = GameObject.Find("Attack");
        currentBallScale = gameObject.transform.localScale;
    }

    void Update()
    {
        if (timerInteract.Finished)
        {
            attack.GetComponent<Button>().interactable = true;
        }

        if (status == false )
        {
            gameObject.transform.localScale -= scaleChange;
            
        }

        if (gameObject.transform.localScale.x < 0.1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AttackPressed()
    {
        if (attack.GetComponent<Button>().interactable)
        {
            status = false;
        }
    }

    public void AttackUnpressed()
    {
        if (attack.GetComponent<Button>().interactable)
        {
            status = true;
            NotInteractable();
            
            bulletScale = currentBallScale - gameObject.transform.localScale;
            currentBallScale = gameObject.transform.localScale;

            x = gameObject.transform.position.x;
            y = gameObject.transform.position.y;
            z = gameObject.transform.position.z;

            Vector3 location = new Vector3(x, y, z+1.5f);
            GameObject bullet = Instantiate<GameObject>(prefabBullet, location, Quaternion.identity);
            rbBullet = bullet.GetComponent<Rigidbody>();
            bullet.transform.localScale = bulletScale;
            rbBullet.AddForce(10 * (new Vector3(0,2,0.1f) * 5), ForceMode.Force);
        }
    }

    public void NotInteractable()
    {
        attack.GetComponent<Button>().interactable = false;
        timerInteract.Run();
    }
}
