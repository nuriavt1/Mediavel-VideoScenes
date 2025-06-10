using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltearNormales : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("No se encontró MeshFilter");
            return;
        }

        Mesh mesh = meshFilter.mesh;

        // Invertir normales
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = -normals[i];
        mesh.normals = normals;

        // Invertir el orden de los triángulos para que se dibuje por el lado interno
        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] triangles = mesh.GetTriangles(i);
            for (int j = 0; j < triangles.Length; j += 3)
            {
                // Cambiar el orden de los índices del triángulo
                int temp = triangles[j];
                triangles[j] = triangles[j + 1];
                triangles[j + 1] = temp;
            }
            mesh.SetTriangles(triangles, i);
        }
    }
}
