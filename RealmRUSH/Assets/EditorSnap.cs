using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
       private void Update()
    {
        Debug.Log("Editor casa Update");
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt( transform.position.x / 10f) *10f;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        transform.position = new Vector3(snapPosition.x, 0.0f, snapPosition.z);
    }
}
