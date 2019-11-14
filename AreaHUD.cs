using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaHUD : MonoBehaviour
{
    public float area;
    public Text areaDisplay;

    public float MeshArea(Vector3[] vertices, int[] triangles)
    {
        float result = 0;
        for (int p = 0; p < triangles.Length; p += 3)
        {
            result += Vector3.Cross(vertices[triangles[p + 1]] - vertices[triangles[p]],
                vertices[triangles[p + 2]] - vertices[triangles[p]]).magnitude;
        }
       result *= 0.5f;
       return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices = this.GetComponent<MeshFilter>().mesh.vertices;
        int[] triangles = this.GetComponent<MeshFilter>().mesh.triangles;
        area = MeshArea(vertices, triangles);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = this.GetComponent<MeshFilter>().mesh.vertices;
        int[] triangles = this.GetComponent<MeshFilter>().mesh.triangles;
        area = MeshArea(vertices, triangles);
        area *= this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z;
        float temp = area;
        temp.ToString("0.00");
    }
}

// Source: // https://forum.unity.com/threads/figuring-out-the-volume-and-surface-area.117388/