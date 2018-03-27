﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;

    [Range(10, 100)]
    public int resolution = 10;

    Transform[] points;

    private void Awake()
    {
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localScale = scale;
            point.localPosition = position;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }

    }
}
