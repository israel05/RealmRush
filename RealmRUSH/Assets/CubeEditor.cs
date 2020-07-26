using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SelectionBase]
[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{


    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    TextMesh textMeshTop;
   // TextMesh textMeshIzq;


    private void Start()
    {
       
    }

    private void Update()
    {
        
        Vector3 snapPosition;
    
        snapPosition.x = Mathf.RoundToInt( transform.position.x / gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0.0f, snapPosition.z);

        textMeshTop = GetComponentInChildren<TextMesh>();
       string labelText = (snapPosition.x / gridSize).ToString() + "," + (snapPosition.z / gridSize).ToString();

        textMeshTop.text = labelText;
        gameObject.name = labelText;


    }
}
