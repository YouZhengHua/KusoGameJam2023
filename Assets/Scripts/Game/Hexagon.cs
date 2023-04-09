using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField, Header("位置頂點")]
    private Transform[] vertices;
    MeshFilter meshFilter;
    Mesh mesh;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        // 定義六角形的頂點位置

        // 定義六角形的三角形面
        int[] triangles = new int[18];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 5;
        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 5;
        triangles[9] = 3;
        triangles[10] = 4;
        triangles[11] = 5;

        // 更新 Mesh 的頂點位置與三角形面
        List<Vector3> vector3s = new List<Vector3>();
        foreach(Transform tmp in vertices)
        {
            vector3s.Add(tmp.position);
        }
        mesh.vertices = vector3s.ToArray();
        mesh.triangles = triangles;

        // 讓 Mesh 自動計算面的法向量與切線向量
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    void Update()
    {
        // 控制頂點位置
        Vector3[] vertices = mesh.vertices;
        vertices[1].y = Mathf.Sin(Time.time) * 0.5f;
        vertices[2].x = Mathf.Cos(Time.time) * 0.5f;
        mesh.vertices = vertices;
    }
}
