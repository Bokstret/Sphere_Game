using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OpenGates : MonoBehaviour
{
    public float speed = 3;
    public float angle;
    public GameObject ball;
    public GameObject indicator;
 
    void Update()
    {
        float heading = indicator.transform.position.z - ball.transform.position.z;
        if (Math.Abs(heading) < 8)
            OpenGate();
        if (Math.Abs(heading) < 0.5)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenGate()
    {
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * speed);
    }
}