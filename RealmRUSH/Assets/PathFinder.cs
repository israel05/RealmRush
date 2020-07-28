using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



////
/// <summary>
/// PathFinder es un diccionario que contiene la información sobre cada celda del waypoint, impide que dos bloques esten 
/// en el mismo sitio a la vez
/// </summary>
public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        //todo lo que sea waypoint se metera en esta lista
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();          
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block " + waypoint + "no añadido");
            }else
            {
                grid.Add(gridPos, waypoint);
            }                     
        }
        print("Cargados en total "+ grid.Count + " bloques para el camino");
    }

}
