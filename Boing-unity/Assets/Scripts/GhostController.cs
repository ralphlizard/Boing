using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {
	
	public bool isPlayer;
	public float movementSpeed = 10.0f;
	public float mouseSensitivity = 5.0f;
	public float upDownRange = 60.0f;
	public bool roundStarted;

	private float verticalRotation = 0;
	private CharacterController cc;
	private Vector3 speed;
	private Transform head;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();	
		head = transform.FindChild("CardboardMain").FindChild("Head");
	}
	
	// Update is called once per frame
	void Update () {

		if (isPlayer) {
			
			//mobile
			if (Application.isMobilePlatform)
			{
				Quaternion rot = Cardboard.SDK.HeadPose.Orientation;
				transform.localRotation = rot;
			}
			//pc testing
			else
			{
				float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
				verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
				verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
				
				transform.Rotate (0, rotLeftRight, 0);
				transform.localRotation = Quaternion.Euler (verticalRotation, transform.eulerAngles.y, 0);
			}
			
			//Movement
			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
			
			speed = new Vector3 (sideSpeed, 0, forwardSpeed);
			speed = transform.rotation * speed * 0.01f;
		}

		if (roundStarted)
			cc.Move (speed);
	}
}
