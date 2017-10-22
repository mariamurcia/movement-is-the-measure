/*
 * TransparencyController.cs
 * Changes transparency of the material of the gameObject it is attached to depending on the distance between this gameObject and the selected avatarComponent
 * Author: Sebastian Friston, Maria Murcia
 * Use: Attach script to the walls or other gameObjects in Scene
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour {

    public GameObject avatarComponent;
    public float thresholdDistance = 1f;
    public float offset = 0.2f;
	
	void Update () {
        var colour = this.GetComponent<MeshRenderer>().material.color;
        var distance = (avatarComponent.transform.position - Physics.ClosestPoint(avatarComponent.transform.position, this.GetComponent<Collider>(), this.transform.position, this.transform.rotation)).magnitude - offset;
        colour.a = distance / thresholdDistance;
        this.GetComponent<MeshRenderer>().material.color = colour;
	}
}
