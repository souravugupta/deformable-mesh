using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButton (0)) {
            if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
                if (hit.transform.gameObject.tag == "DeformableMesh") {
                    hit.transform.GetComponent<MeshDeformer> ().Deform (hit.point, 1.0f, 0.1f, -1.0f, -0.1f, hit.normal);
                }
            }
        }
    }
}
