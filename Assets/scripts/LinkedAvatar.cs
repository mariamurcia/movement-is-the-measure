/*
 * LinkedAvatar.cs
 * Renders the avatar as a number of Quads with the Head, LeftHand, RightHand, LeftFoot and RightFoot as vertices
 * Author: Maria Murcia
 * Use: Attach script to empty GameObject in Scene
 * 
 * Notes:
 * Each public list of GameObjects (headConnectedHands, headConnectedFeet, headConnectedLeftSide, headConnectedRightSide)
 * contains four GameObjects (the first and last should be the same).
 * Each of these GameObjects defines one of the vertices of the Quad.
 * The public Material is assigned to all Quads.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedAvatar : MonoBehaviour {

	public Material material;	// Material assigned to the four Quads
	private int totalParts = 4;	// Number of Quads created for the avatar

	public List<GameObject> headConnectedHands; 	// Quad between the Head, LeftHand and RightHand
	public List<GameObject> headConnectedFeet; 		// Quad between the Head, LeftFoot and RightFoot
	public List<GameObject> headConnectedLeftSide;	// Quad between the Head, LeftHand and LeftFoot
	public List<GameObject> headConnectedRightSide;	// Quad between the Head, RightHand and RightFoot

	private List<GameObject> avatarParts = new List<GameObject>(); 	// List of Quads
	private List<Mesh> avatarMeshes = new List<Mesh>();				// List of Quad Meshes to be updated
	private List<Vector3[]> avatarVertices = new List<Vector3[]>();	// List of Quad Vertices to be updated

	void Start() {  
		for (int i = 0; i<= totalParts-1; i++) {
			GameObject part = GameObject.CreatePrimitive (PrimitiveType.Quad);	// Create Quad primitive
			part.transform.SetParent (transform);								// Set Quad as child of empty GameObject
			part.GetComponent<Renderer> ().material = material;					// Set Quad material

			switch (i) {	// Name the GameObjects with the corresponding List name 
				case 0:
					part.name = "headConnectedHands"; break;
				case 1:
					part.name = "headConnectedFeet"; break;
				case 2:
					part.name = "headConnectedLeftSide"; break;
				case 3:
					part.name = "headConnectedRightSide"; break;
			}

			Vector3[] vec = new Vector3[3]; // Initialise empty Vector3[]
			avatarParts.Add(part);			// Add Quad to List of Quads
			avatarMeshes.Add (new Mesh ());	// Initialise List of Quad Meshes
			avatarVertices.Add(vec);		// Initialise List of Quad Vertices
		}
	}
		
	void Update(){
		for (int i=0; i<= totalParts-1; i++) { // Get vertices from each of the QuadMeshes
			Mesh meshPart = avatarParts[i].GetComponent<MeshFilter>().mesh;
			Vector3[] vertices = meshPart.vertices;
			avatarMeshes[i] = meshPart;
			avatarVertices[i] = vertices;
		}

		int j = 0;
		while (j < avatarVertices[1].Length) {	// Vertices are updated based on the position of the corresponding GameObjects
			avatarVertices [0] [j] = headConnectedHands [j].transform.position;
			avatarVertices [1] [j] = headConnectedFeet [j].transform.position;
			avatarVertices [2] [j] = headConnectedLeftSide [j].transform.position;
			avatarVertices [3] [j] = headConnectedRightSide [j].transform.position;
			j++;
		}
			
		for (int k = 0; k <= totalParts-1; k++) { // Mesh vertices are assigned the value of the updated vertices
			avatarMeshes[k].vertices = avatarVertices[k];
			avatarMeshes[k].RecalculateBounds();
		}
	}
}
