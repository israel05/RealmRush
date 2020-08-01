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
       
        
        if (numTowers < towerLimit)
        {
            InstatiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }


    }

    private void InstatiateNewTower(Waypoint baseWaypoint)
    {

        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
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

        oldTower.transform.position = newBaseWaypoint.transform.position;

        colaDeTorretas.Enqueue(oldTower); //la pongo en la cabeza

        


       
    }

 
}
