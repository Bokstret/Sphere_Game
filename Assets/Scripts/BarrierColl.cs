using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierColl : MonoBehaviour
{
    public float speed = 3;
    public Color BarrierColor;
    public Color BallColor;

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Bullet")
        {
            gameObject.tag = "Untagged";
            GetComponent<Renderer>().material.color = Color.Lerp(BarrierColor, BallColor, speed);
            Destroy(gameObject,0.2f);
            Destroy(otherObj.gameObject, 0.5f);
        }
    }
}
