using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
