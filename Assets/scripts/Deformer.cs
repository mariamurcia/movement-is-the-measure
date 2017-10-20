using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformer : MonoBehaviour {

    public GameObject avatarComponent;
    public float toolsize = 0.1f;

    Vector3[] vertices;

	void Start () {
        vertices = GetComponent<MeshFilter>().mesh.vertices;
	}
	
	void Update () {

        var handposition = transform.worldToLocalMatrix.MultiplyPoint(avatarComponent.transform.position);

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];
            Vector3 delta = vertex - handposition;
            float penetration = delta.magnitude - toolsize;

            if(penetration < 0)
            {
                vertex += delta.normalized * -penetration;
                vertices[i] = vertex;
            }

        }

        GetComponent<MeshFilter>().mesh.vertices = vertices;
    }
}
