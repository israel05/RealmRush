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
        
        // gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
      //  gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        int gridSize = waypoint.GetGridSize();
       
        transform.position = new Vector3( 
            waypoint.GetGridPos().x * gridSize,
            0.0f,
            waypoint.GetGridPos().y * gridSize); //es y como segundo valir del bidimensional Vector2, no como altura
    }

    private void UpdateLabel()
    {
        TextMesh textMeshTop = GetComponentInChildren<TextMesh>();              
        string labelText = 
            waypoint.GetGridPos().x + 
            "," + 
            waypoint.GetGridPos().y; //es y porque viene de un vector2
        textMeshTop.text = labelText;
        gameObject.name = labelText;
    }
}
