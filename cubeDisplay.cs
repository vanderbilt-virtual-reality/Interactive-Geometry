using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeDisplay : MonoBehaviour
{
    public float area;
    public float volume;
    public Text areaDisplay;
    public Text volumeDisplay;

    public float MeshArea(Vector3[] vertices, int[] triangles)
    {
        float result = 0f;
        for (int p = 0; p < triangles.Length; p += 3)
        {
            result += (Vector3.Cross(vertices[triangles[p + 1]] - vertices[triangles[p]],
                vertices[triangles[p + 2]] - vertices[triangles[p]])).magnitude;
        }
        return result;
        // if triangle
        // result *= 0.5f;
    }

    // source: https://answers.unity.com/questions/52664/how-would-one-calculate-a-3d-mesh-volume-in-unity.html
    // https://forum.unity.com/threads/figuring-out-the-volume-and-surface-area.117388/

    public float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float v321 = p3.x * p2.y * p1.z;
        float v231 = p2.x * p3.y * p1.z;
        float v312 = p3.x * p1.y * p2.z;
        float v132 = p1.x * p3.y * p2.z;
        float v213 = p2.x * p1.y * p3.z;
        float v123 = p1.x * p2.y * p3.z;
        return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
    }
    public float VolumeOfMesh(Mesh mesh)
    {
        float volume = 0;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        for (int i = 0; i & lt; mesh.triangles.Length; i += 3)
      {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle(p1, p2, p3);
        }
        return Mathf.Abs(volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        // area stuff
        Vector3[] vertices = this.GetComponent<MeshFilter>().mesh.vertices;
        int[] triangles = this.GetComponent<MeshFilter>().mesh.triangles;
        // vol stuff
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        area = MeshArea(Vector3[] vertices, int[] triangles);
        volume = VolumeOfMesh(mesh);
   
  

    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = this.GetComponent<MeshFilter>().mesh.vertices;
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        areaDisplay.text = area.ToString();
        volumeDisplay.text = area.ToString();
    }
}

