using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public float UIDistance = 5.0f;

    private Capsule capsule;

	// Use this for initialization
	void Start () {
        capsule = GameObject.FindObjectOfType<Capsule>();
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(capsule.GazeDirection());
        transform.position = capsule.transform.position;
        transform.position += capsule.GazeDirection() * UIDistance;
	}
}
