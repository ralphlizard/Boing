using UnityEngine;
using System.Collections;

public class FinderController : MonoBehaviour {
	
	public bool isPlayer;
	public float movementSpeed = 10.0f;
	public float mouseSensitivity = 5.0f;
	public float upDownRange = 60.0f;
	
	private float verticalRotation = 0;
	private CharacterController cc;
	private Vector3 speed;
	private Transform head;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
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
				head.localRotation = rot;
				head.localRotation = Quaternion.Euler (rot.eulerAngles.x, 0, rot.eulerAngles.z);
				transform.localRotation = Quaternion.Euler (0, rot.eulerAngles.y, 0);
			}
			//pc testing
			else
			{
				verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
				verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
				head.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
				
				float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
				transform.Rotate (0, rotLeftRight, 0);
			}
			
			//Movement
			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
			
			speed = new Vector3 (sideSpeed, 0, forwardSpeed);
			speed = transform.rotation * speed;
		}
		
		cc.SimpleMove (speed);
	}
}