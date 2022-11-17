using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * dirX * speed *Time.deltaTime);
    }
}
