using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleMesh : MonoBehaviour
{
    public float scaleFactor = 100.0f; // 크기 조정 비율

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            ScaleMeshSize(meshFilter.mesh, scaleFactor);
        }
    }

    void ScaleMeshSize(Mesh mesh, float scale)
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] *= scale;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
