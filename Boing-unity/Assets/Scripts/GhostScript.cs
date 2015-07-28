using UnityEngine;
using System.Collections;

public class GhostScript: MonoBehaviour {

	public bool roundStarted;
	public float movementSpeed = 2.0f;
	public float minRange = 5f;
	
	private GameManager gameManager;
	private CharacterController cc;
	private FinderController finder;
	private Transform player;
	private int item = 0;
	private Vector3 speed;
	private Transform ghostModel;
	private float turnTimer;
	private bool killing;
	
	// Use this for initialization
	void Start () {
		//playerHealth = FirstPersonController.GetPlayerHealth (); // need to write this or something
		player = GameObject.FindWithTag("Finder").transform;
		finder = player.GetComponent<FinderController> ();
		cc = GetComponent<CharacterController> ();
		ghostModel = transform.GetChild (0);
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
//		print ("item " + item);
	}
	
	// Update is called once per frame
	void Update () {
		if (roundStarted) {
			turnTimer += Time.deltaTime;
			Patrol ();
		}
		if (killing) {
			MoveKill ();
		}
		//always face player
		ghostModel.LookAt (player.position);
	}

	void Patrol () {
		float range = minRange + (gameManager.maxItems - gameManager.numItems);
		float totaldistance = Vector3.Distance (player.position, transform.position);
		//print (totaldistance + ", " + range);
		if (totaldistance > range) {
			WalkTowards ();
		} else {
			WalkRandom ();
		}

	}

	//The robot walks towards the player
	void WalkTowards (){
		transform.LookAt (player.position);
		float random = Random.Range (-1f, 1f);
		float rotLeftRight = random * 20;
		random = Random.Range (-1f, 1f);
		float rotUpDown = random * 20;
		transform.Rotate (rotUpDown, rotLeftRight, 0); 
		//moves forward one unit per second
		speed = new Vector3 (0, 0, Time.deltaTime * movementSpeed);
		speed = transform.rotation * speed;
		cc.Move (speed);
	}

	//The robot walks around randomly
	void WalkRandom (){
		//every three seconds change direction
		if (turnTimer > 3) {
			turnTimer = 0;
			float random = Random.Range (-1f, 1f);
			float rotLeftRight = random * 20;
			random = Random.Range (-1f, 1f);
			float rotUpDown = random * 20;
			transform.Rotate (rotUpDown, rotLeftRight, 0); 
		}
		//moves forward one unit per second
		speed = new Vector3 (0, 0, Time.deltaTime * movementSpeed);
		speed = transform.rotation * speed;
		cc.Move (speed);
	}

	public void KillPlayer() {
		transform.SetParent (player.FindChild("CardboardMain").GetChild(0).GetChild(0));
		killing = true;
	}

	void MoveKill() {
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3 (0,0,2), .05f);
	}

}
