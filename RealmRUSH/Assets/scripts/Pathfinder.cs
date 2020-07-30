using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;



////
/// <summary>
/// BreadthFirstSearcher es un diccionario que contiene la información sobre cada celda del waypoint, impide que dos bloques esten 
/// en el mismo sitio a la vez
/// </summary>
public class Pathfinder : MonoBehaviour

{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Waypoint searchCenter; //el que esta trabajando ahora
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true; //indica la parada del algoritmo de busqueda

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private List<Waypoint> path = new List<Waypoint>(); //el camino 



    public List<Waypoint> getPath()
    {
        if (path.Count == 0)
        {
            CalcularElCamino();
        }
        return path;
    }

    private void CalcularElCamino()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
        //invertir la lista
    }
        
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true; 
            HaltIfEndFound();
            ExploreNeighbours();

        }
       
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false; //para el algoritmo
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;           
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }            
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];       
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.cyan);
        endWaypoint.SetTopColor(Color.black);
       

    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {                    
            Vector2Int gridPos = waypoint.GetGridPos();          
            if (grid.ContainsKey(gridPos))
            {
            }else
            {                
                grid.Add(gridPos, waypoint);
             }                     
        }
        
    }

}
