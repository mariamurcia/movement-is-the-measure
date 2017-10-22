/*
 * BallGenerator.cs
 * Procedurally instantiates a ballNumber of prototypeBalls
 * Author: Sebastian Friston, Maria Murcia
 * Use: Attach script to empty GameObject in Scene
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

    public GameObject prototypeBall; // Prototype gameObject that will be instantiated
    public int ballNumber = 1000; // Number of prototype gameObjects that will be instantiated

    private int ballCounter = 0;
    private List<Material> materialList = new List<Material>();
    private int materialNumber = 128;

    private void Start() {
        for (int i = 0; i < materialNumber; i++) {
            var material = Instantiate(prototypeBall.GetComponent<MeshRenderer>().material);
            material.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f); // Assign random colour to each material
            materialList.Add(material);
        }
    }

	void Update () {
        if (ballCounter <= ballNumber) { // Intantiates one ball in every frame
            var clone = Instantiate(prototypeBall, this.transform);
            clone.GetComponent<MeshRenderer>().sharedMaterial = materialList[Random.Range(0, materialList.Count)];
            ballCounter++;
        }
	}
}
