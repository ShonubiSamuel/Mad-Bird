using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Bird bird = other.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Destroy(gameObject);
        }
    }
}
