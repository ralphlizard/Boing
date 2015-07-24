using UnityEngine;
using System.Collections;

public class FinderController : MonoBehaviour {
	
	public bool isPlayer;
	public float movementSpeed = 10.0f;
	public float mouseSensitivity = 5.0f;
	public float upDownRange = 60.0f;
	public GameObject tutorial;
	public bool roundStarted;
	public int health;

	private float verticalRotation = 0;
	private CharacterController cc;
	private Vector3 speed;
	private Transform head;
	private GameObject tutorialClone;
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		head = transform.FindChild("CardboardMain").FindChild("Head");
		Control ();
		PlaceTutorial ();
	}
	
	// Update is called once per frame
	void Update () {
		Control ();
		if (!roundStarted)
			CheckTurn ();
		else 
		{
//			CheckWin();
			CheckLose();
		}
	}

	void CheckLose ()
	{
		if (health <= 0)
		{
			//lose
			return;
		}
	}

	void CheckTurn ()
	{
		float dx = transform.position.x - tutorialClone.transform.position.x;
		float dy = transform.position.z - tutorialClone.transform.position.z;
		float radians = Mathf.Atan2(dx,dy);
		Quaternion initAngle = Quaternion.identity;
		Quaternion curAngle = transform.rotation;
		initAngle.eulerAngles = new Vector3(0, radians * 180 / Mathf.PI + 180, 0);
		curAngle.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		float diffAngle = Quaternion.Angle (initAngle, curAngle);

		if(diffAngle > 120)
		{
			gameManager.GetComponent<GameManager>().roundStarted = true;
			print ("Round Started");
		}
	}

	void Control() {
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

		if (roundStarted)
			cc.SimpleMove (speed);
	}

	void PlaceTutorial() 
	{
		tutorialClone = Instantiate (tutorial) as GameObject;
		tutorialClone.transform.SetParent (this.transform);
		tutorialClone.transform.localPosition = new Vector3 (0, 0, 3);
		tutorialClone.transform.localEulerAngles = new Vector3 (270, 0, 0);
		tutorialClone.transform.parent = null;

	}
}