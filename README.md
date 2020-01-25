# Deformable Mesh
A Unity Game Engine Asset to Dynamically Deform a Mesh at Runtime.

# Using Deformable Mesh

Attach the MeshDeformer script to the GameObject you want to be deformed.

To deform the mesh call Deform ()
```C Sharp
public void Deform (Vector3 point, float radius, float stepRadius, float strength, float stepStrength, Vector3 direction);
```
# Parameters
    point: The point from which deformation of the mesh starts
    radius: The maximum radius to which the deformation affects
    stepRadius: The small step value of the maximum radius
    strength: The maximum strength of the deformation
    stepStrength: The small step value of the maximum strength
    direction: The direction of the deformation relative to mesh
    
# Description
  Deforms the attached mesh
```C Sharp
MeshDeformer meshDeformer = YOUR GAMEOBJECT.transform.GetComponent<MeshDeformer> ();
meshDeformer.Deform (POINT, 0.5f, 0.05f, -0.5f, -0.05f, Vector3.up);
```

For more examples browse Assets > Deformable Mesh > Examples > Scenes
