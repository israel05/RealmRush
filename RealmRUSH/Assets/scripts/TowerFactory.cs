using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    Queue<Torreta> colaDeTorretas = new Queue<Torreta>();


    [SerializeField] Torreta towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParentTransfor;
   
    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = colaDeTorretas.Count;
        print("Llevo todas estas torres puestas : " + numTowers);

        //debug TODO un bug que hace que las torretas se coloquen desplazadas por este margen
        Vector3 posTemp = new Vector3(0f, 0f, 0f);
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
            MoveExistingTower(baseWaypoint);
        }


    }

    private void InstatiateNewTower(Waypoint baseWaypoint, Vector3 posTemp)
    {
        
        var newTower = Instantiate(towerPrefab, posTemp, Quaternion.identity);
        newTower.transform.parent = towerParentTransfor; //
        baseWaypoint.isPlaceable = false;


        //ahora tienes una torreta más en la cola, que es precisamente esa, o mejor dicho
        // precisamente la que está en ese waypoint

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        colaDeTorretas.Enqueue(newTower);
    }


    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = colaDeTorretas.Dequeue(); //cojo la que esta más abajo

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;

        //debug TODO un bug que hace que las torretas se coloquen desplazadas por este margen
        Vector3 posTemp = new Vector3(0f, 0f, 0f);
        posTemp = newBaseWaypoint.transform.position;
        posTemp.x = posTemp.x - 39f;
        posTemp.y = posTemp.y - 63f;
        posTemp.z = posTemp.z + 42f;
        print("pos Temp:" + posTemp.x + " " + posTemp.y + " " + posTemp.z);
        // otra vez el mismo error
        oldTower.transform.position = posTemp;

        colaDeTorretas.Enqueue(oldTower); //la pongo en la cabeza

        


       
    }

 
}
