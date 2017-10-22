/*
 * SelfDestruct.cs
 * Destroys the gameObject it is attacehd to after a specified time (lifeTime)
 * Author: Sebastian Friston, Maria Murcia
 * Use: Attach script to the gameObject to be destroyed
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float lifeTime; //in seconds

    private float startTime;

	void Start () {
        startTime = Time.time;
	}
	
	void Update () {
		if(Time.time - startTime > lifeTime) {
            Destroy(this.gameObject);
        }
	}
}
