using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SkinnedMeshToMesh : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect VFXGraph;
    public float refreshRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {
        while(gameObject.activeSelf)
        {
            Mesh mesh = new Mesh();
            skinnedMesh.BakeMesh(mesh);
            Vector3[] vertices = mesh.vertices;
            Mesh mesh1 = new Mesh();
            mesh1.vertices = vertices;
            VFXGraph.SetMesh("Mesh", mesh1);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
