using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField, Header("��m���I")]
    private Transform[] vertices;
    MeshFilter meshFilter;
    Mesh mesh;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        // �w�q�����Ϊ����I��m

        // �w�q�����Ϊ��T���έ�
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

        // ��s Mesh �����I��m�P�T���έ�
        List<Vector3> vector3s = new List<Vector3>();
        foreach(Transform tmp in vertices)
        {
            vector3s.Add(tmp.position);
        }
        mesh.vertices = vector3s.ToArray();
        mesh.triangles = triangles;

        // �� Mesh �۰ʭp�⭱���k�V�q�P���u�V�q
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    void Update()
    {
        // ����I��m
        Vector3[] vertices = mesh.vertices;
        vertices[1].y = Mathf.Sin(Time.time) * 0.5f;
        vertices[2].x = Mathf.Cos(Time.time) * 0.5f;
        mesh.vertices = vertices;
    }
}
