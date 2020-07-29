﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public Waypoint exploredFrom;

  ////
  /// <summary>
  /// Devuelve un vector bidimensional con la posición del objeto waypoint
  /// </summary>
  /// <returns>Vector bidimensional de posiciones multiples de 10</returns>
  public Vector2Int GetGridPos()
    {
           return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) ,
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }
    public int GetGridSize()
    {
        return gridSize;
    }

    public void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }

    public void SetTopColor(Color colorin)
    {
        MeshRenderer topMeshRenderer =  transform.Find("QuadBase").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = colorin;
    }
}