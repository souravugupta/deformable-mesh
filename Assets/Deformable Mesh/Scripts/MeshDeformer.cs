using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshCollider))]
public class MeshDeformer : MonoBehaviour
{
    // If checked normals of the mesh will be recalculated after every deformation
    public bool recalculateNormals;

    // If checked MeshCollider will be updated after every deformation
    public bool collisionDetection;

    Mesh mesh;
    MeshCollider meshCollider;
    List<Vector3> vertices;

    // Start is called before the first frame update
    void Start () {
        mesh = GetComponent<MeshFilter> ().mesh;
        meshCollider = GetComponent<MeshCollider> ();
        vertices = mesh.vertices.ToList ();
    }

    /* Deforms this mesh
       point: The point from which deformation of the mesh starts
       radius: The maximum radius to which the deformation affects
       stepRadius: The small step value of the maximum radius
       strength: The maximum strength of the deformation
       stepStrength: The small step value of the maximum strength
       direction: The direction of the deformation relative to mesh
    */

    public void Deform (Vector3 point, float radius, float stepRadius, float strength, float stepStrength, Vector3 direction) {
        for (int i = 0; i < vertices.Count; i++) {
            Vector3 vi = transform.TransformPoint (vertices[i]);
            float distance = Vector3.Distance (point, vi);
            float s = strength;
            for (float r = 0.0f; r < radius; r += stepRadius) {
                if (distance < r) {
                    Vector3 deformation = direction * s;
                    vertices[i] = transform.InverseTransformPoint (vi + deformation);
                    break;
                }
                s -= stepStrength;
            }
        }
        if (recalculateNormals)
            mesh.RecalculateNormals ();
            
        if (collisionDetection) {
            meshCollider.sharedMesh = null;
            meshCollider.sharedMesh = mesh;   
        }           
        mesh.SetVertices (vertices);
    }
}