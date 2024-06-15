using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed = 0.8f;
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x -= speed * Time.deltaTime;

        transform.position = pos;
    }
}
