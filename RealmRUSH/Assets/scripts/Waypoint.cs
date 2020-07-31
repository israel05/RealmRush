using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] Torreta towerPrefab;



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


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {        
            if (isPlaceable)
            {
                Vector3 posTemp = new Vector3(0f,0f,0f);
                //debug TODO un bug que hace que las torretas se coloquen desplazadas por este margen
                posTemp = transform.position;
                posTemp.x = posTemp.x - 39f;
                posTemp.y = posTemp.y - 63f;
                posTemp.z = posTemp.z + 42f;
                print("pos Temp:" + posTemp.x + " " + posTemp.y + " " + posTemp.z);
                //todo eleminar el debug
                Instantiate(towerPrefab, posTemp, Quaternion.identity);
                print("Estoy sobre " + gameObject.name);
                isPlaceable = false;

            } else
            {
                print("No puedo poner nada sobre eso, BLOQUEADO " + gameObject.name);
            }
                
         }              
    }

 }
