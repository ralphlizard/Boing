using UnityEngine;
using System.Collections;

public class FinderController : MonoBehaviour {
	
	public float movementSpeed = 10.0f;
	public float mouseSensitivity = 5.0f;
	public float upDownRange = 60.0f;
	public bool roundStarted;
	public float health;

	private Quaternion initAngle;
	private float verticalRotation = 0;
	private CharacterController cc;
	private Vector3 speed;
	private Transform head;
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		head = transform.FindChild("CardboardMain").FindChild("Head");
		initAngle.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
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
//			gameManager.GetComponent<GameManager>().GhostWin();
		}
	}

	void CheckTurn ()
	{
		Quaternion curAngle = transform.rotation;
		curAngle.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		float diffAngle = Quaternion.Angle (initAngle, curAngle);
		if(diffAngle > 120)
		{
			gameManager.GetComponent<GameManager>().StartRound();
		}
	}

	//coneprox is how close ghost is to center of light cone
	//
	public void TakeDamage(float coneProx)
	{
		print (health);
		health -= Time.deltaTime * (10 + coneProx);
	}

	void Control() {
			
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

	}

}