﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    public List<Transform> wayPoint = null;
    public float Speed;
    public Vector3 currentPosition;

    int currentPointIndex;
    float Timer;

    private void Start()
    {
        Timer = 0;
        currentPosition = wayPoint[currentPointIndex].position;
    }

    private void Update()
    {
        Timer += Time.deltaTime * Speed;

        if (transform.position != currentPosition)
        {
            transform.position = Vector3.Lerp(transform.position, wayPoint[1].position, Timer);
        }
        else
        {
            if (currentPointIndex < wayPoint.Count -1)
            {
                currentPointIndex++;
            }
        }
    }
}
