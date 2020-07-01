using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class QuadStack : MonoBehaviour
{
    public float stackHeight;
    public float quadSize;
    public int quadCount;

    public new Camera camera;
    public Material material;

    Mesh quad;

    private int renderLayer = 0;
    private bool castShadows = true;
    private bool recvShadows = false;
    private bool lightProbes = false;

    private void DrawQuadStack()
    {
        Vector3 step = Vector3.up * (stackHeight / quadCount);
        Vector3 pos = transform.position + (Vector3.up * (stackHeight * 0.5f));

        for(int i = 0; i < quadCount; i++, pos -= step)
        {
            Matrix4x4 matrix = Matrix4x4.TRS(pos, transform.rotation, transform.localScale);

            Graphics.DrawMesh(quad, matrix, material, renderLayer, camera, 0, null, castShadows, recvShadows, lightProbes);
        }
    }

    void Awake()
    {
        quad = gameObject.GetComponent<MeshFilter>().mesh;        
    }

    void Start()
    {
        CreateQuad(quadSize * 0.5f);
    }

    void Update()
    {
        DrawQuadStack();
    }

    private void CreateQuad(float dv)
    {
        quad.Clear();

        quad.vertices = new Vector3[] { new Vector3(-dv, 0, -dv), new Vector3(-dv, 0, dv), new Vector3(dv, 0, -dv), new Vector3(dv, 0, dv) };
        quad.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1.0f), new Vector2(1.0f, 0), new Vector2(1.0f, 1.0f) };
        quad.triangles = new int[] { 2, 1, 0, 1, 2, 3 };

        quad.RecalculateNormals();
    }

}
