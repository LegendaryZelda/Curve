﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SnakeTail : NetworkBehaviour
{
    LineRenderer line;
    EdgeCollider2D edgeCollider;
    List<Vector2> linePoints;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
        line.useWorldSpace = true;
        linePoints = new List<Vector2>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    public void SetColor(Color color)
    {
        line.startColor = color;
        line.endColor = color;
    }

    public void SetWidth(float width)
    {
        line.startWidth = width;
        line.endWidth = width;
    }

    public void UpdateTail(Vector2 position)
    {
        if (linePoints.Count > 1)
        {
            edgeCollider.points = linePoints.ToArray();
        }

        linePoints.Add(position);
        line.positionCount = linePoints.Count;
        line.SetPosition(linePoints.Count - 1, linePoints[linePoints.Count - 1]);
    }
}