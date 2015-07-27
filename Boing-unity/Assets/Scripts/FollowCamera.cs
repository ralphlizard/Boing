using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float speed = 0.5f;
	private Transform finder;
	private Transform finderHead;

	// Use this for initialization
	void Start () {
		finder = GameObject.FindGameObjectWithTag("Finder").transform;
		finderHead = finder.FindChild ("CardboardMain").FindChild ("Head");
	}

	// Update is called once per frame
	void Update () {
		float x = Mathf.LerpAngle (transform.eulerAngles.x, finderHead.eulerAngles.x, speed);
		float y = Mathf.LerpAngle (transform.eulerAngles.y, finder.eulerAngles.y, speed);

		transform.eulerAngles = new Vector3(x, y, 0);
		transform.position = finder.position;
	}
}