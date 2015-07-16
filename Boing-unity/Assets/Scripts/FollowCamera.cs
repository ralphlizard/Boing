using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.LerpAngle (transform.eulerAngles.x, Camera.main.transform.eulerAngles.x, speed);
		float y = Mathf.LerpAngle (transform.eulerAngles.y, Camera.main.transform.eulerAngles.y, speed);
		float z = Mathf.LerpAngle (transform.eulerAngles.z, Camera.main.transform.eulerAngles.z, speed);

		transform.eulerAngles = new Vector3(x, y, z);
	}
}
