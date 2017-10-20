using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {

    public GameObject prototypeBall;
    public int ballNumber = 1000;

    private int ballCounter = 0;
    private List<Material> materialList = new List<Material>();
    private int materialNumber = 128;

    private void Start() {
        for (int i = 0; i < materialNumber; i++) {
            var material = Instantiate(prototypeBall.GetComponent<MeshRenderer>().material);
            material.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
            materialList.Add(material);
        }
    }

	void Update () {
        if (ballCounter <= ballNumber) {
            var clone = Instantiate(prototypeBall, this.transform);
            clone.GetComponent<MeshRenderer>().sharedMaterial = materialList[Random.Range(0, materialList.Count)];
            ballCounter++;
        }
	}
}
