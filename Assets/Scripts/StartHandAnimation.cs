using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandAnimation : MonoBehaviour
{
    public GameObject leftHandSprite, rightHandSprite;
    public float speed = 1.2f;
   
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1f);
        leftHandSprite.transform.localPosition = new Vector3(-6, y, 0);


        float x = Mathf.PingPong(Time.time * speed, 1f);
        rightHandSprite.transform.localPosition = new Vector3(6, x, 0);
    }
}
