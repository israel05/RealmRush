using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



////
/// <summary>
/// PathFinder es un diccionario que contiene la información sobre cada celda del waypoint, impide que dos bloques esten 
/// en el mismo sitio a la vez
/// </summary>
public class PathFinder : MonoBehaviour   

{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };




    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();

    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            print("Explorando a mi vecino :" + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.yellow);
            }
            catch
            {
                print("No había celdas al lado");
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.cyan);
        endWaypoint.SetTopColor(Color.black);

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
        
    }

}
