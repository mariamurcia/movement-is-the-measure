using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour {

    public GameObject avatarComponent;
    public float thresholdDistance = 1f;
    public float offset = 0.2f;

    void Start () {
		
	}
	
	void Update () {
        var colour = this.GetComponent<MeshRenderer>().material.color;
        var distance = (avatarComponent.transform.position - Physics.ClosestPoint(avatarComponent.transform.position, this.GetComponent<Collider>(), this.transform.position, this.transform.rotation)).magnitude - offset;
        colour.a = distance / thresholdDistance;
        this.GetComponent<MeshRenderer>().material.color = colour;
	}
}
