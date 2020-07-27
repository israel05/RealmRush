using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SelectionBase]
[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))] //así lo que acepta es un conjunto de waypoints
public class CubeEditor : MonoBehaviour
{


    
    Waypoint waypoint;


    /// <summary>
    /// Cuando sea llamado volvera desde aquí
    /// </summary>
    private void Awake()
    {
        //coge los componentes waypoints que enceuntre más cerca, serán lo s que estan requeridos
        waypoint = GetComponent<Waypoint>();
    }

    
    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
       // gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
      //  gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3( 
            waypoint.GetGridPos().x,
            0.0f,
            waypoint.GetGridPos().y); //es y como segundo valir del bidimensional Vector2, no como altura
    }

    private void UpdateLabel()
    {
        TextMesh textMeshTop = GetComponentInChildren<TextMesh>(); 
        int gridSize = waypoint.GetGridSize();        
        string labelText = 
            (waypoint.GetGridPos().x / gridSize).ToString() + 
            "," + 
            (waypoint.GetGridPos().y / gridSize).ToString(); //es y porque viene de un vector2
        textMeshTop.text = labelText;
        gameObject.name = labelText;
    }
}
