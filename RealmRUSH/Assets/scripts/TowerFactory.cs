using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{



    [SerializeField] Torreta towerPrefab;
    [SerializeField] int towerLimit = 5;
    int numTowers = 0;
   
    public void AddTower(Waypoint baseWaypoint)
    {
        Vector3 posTemp = new Vector3(0f, 0f, 0f);
        //debug TODO un bug que hace que las torretas se coloquen desplazadas por este margen
         posTemp = baseWaypoint.transform.position;
         posTemp.x = posTemp.x - 39f;
         posTemp.y = posTemp.y - 63f;
         posTemp.z = posTemp.z + 42f;
         print("pos Temp:" + posTemp.x + " " + posTemp.y + " " + posTemp.z);
        //todo eleminar el debu

        if (numTowers < towerLimit)
        {
            InstatiateNewTower(baseWaypoint, posTemp);
        }
        else
        {
            MoveExistingTower();
        }


    }

    private static void MoveExistingTower()
    {
        print("Ya no puedo poner más torretas");
    }

    private void InstatiateNewTower(Waypoint baseWaypoint, Vector3 posTemp)
    {      
        Instantiate(towerPrefab, posTemp, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        numTowers++;
    }
}
