using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterController : MonoBehaviour {

    public GameObject avatarComponent;
    public GameObject prototypeBrick;
    public int brickXcount = 100, brickYcount = 100;
    public float threshold = 0.5f;
    public float hueMin = 0f, hueMax = 0.01f;
    public float brickLifeTime = 0.1f;
    public float distanceBetweeenBricks = 0.0001f;

    private GameObject brickHolder;

    void Start () {
        makeWall();
	}
	
	void Update () {
        if ((avatarComponent.transform.position - Physics.ClosestPoint(avatarComponent.transform.position, this.GetComponent<Collider>(), this.transform.position, this.transform.rotation)).magnitude < threshold) {
            foreach(Transform child in brickHolder.transform)
            {
                child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                child.gameObject.AddComponent<SelfDestruct>().LifeTime = brickLifeTime;
            }
        }
    }

    void makeWall() {
        brickHolder = new GameObject(this.name + "brickHolder");
        var brickWidth = prototypeBrick.transform.lossyScale.x;
        var brickHeight = prototypeBrick.transform.lossyScale.y;
        var wallWidth = brickWidth * brickXcount;
        var wallHeight = brickHeight * brickYcount;
        var brickXStart = -wallWidth / 2;
        var brickYStart = -wallHeight / 2;

        brickHolder.transform.position = this.transform.position;
        brickHolder.transform.rotation = this.transform.rotation;

        Vector3 currentposition = Vector3.zero;
        currentposition.x = brickXStart;
        currentposition.y = brickYStart;


        for (int y = 0; y < brickYcount; y++)
        {
            for (int x = 0; x < brickXcount; x++)
            {
                var clone = Instantiate(prototypeBrick, brickHolder.transform);
                clone.transform.localPosition = currentposition;
                clone.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(hueMin, hueMax);
                currentposition.x += brickWidth + distanceBetweeenBricks;
            }
            currentposition.y += brickHeight + distanceBetweeenBricks;
            currentposition.x = brickXStart;
        }

        
    }
}
