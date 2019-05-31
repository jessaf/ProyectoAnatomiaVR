using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ModelPicking : MonoBehaviour
{
    public TextMeshPro labelMesh; // declaramos el label pasa visualizar nombre

    void OnTriggerEnter(Collider collider)
    {
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        string objectName = meshRend.GetComponent<Renderer>().name;
        //toma solo el nombre y lo despliega
        labelMesh.text = objectName.Substring(3, objectName.Length - 3); 

        //Destroy(this.gameObject);
    }
}
