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


    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
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
                /*               
                if (grid.Keys.First() == gridPos )
                    {
                    print("He encontrado el que es el último");
                    waypoint.SetTopColor(Color.black);
                }
                */
                grid.Add(gridPos, waypoint);
                
            }                     
        }
        
    }

}
