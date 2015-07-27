using UnityEngine;
using System.Collections;

public class GhostScript: MonoBehaviour {

	public float patrolSpeed = 2f;
	public bool roundStarted;
	public float movementSpeed = 2.0f;
	public float range = 5f;

	private CharacterController cc;
	private FinderController finder;
	private Transform player;
	private int frame = 0;
	private int item = 0;
	private Vector3 speed;
	private Transform ghostModel;
	
	// Use this for initialization
	void Start () {
		//playerHealth = FirstPersonController.GetPlayerHealth (); // need to write this or something
		player = GameObject.FindWithTag("Finder").transform;
		finder = player.GetComponent<FinderController> ();
		cc = GetComponent<CharacterController> ();
		ghostModel = transform.GetChild (0);
//		print ("item " + item);
	}
	
	// Update is called once per frame
	void Update () {
		if (roundStarted)
			Patrol ();

		//always face player
		ghostModel.LookAt (player.position);
	}

	void Patrol () {
		frame += 1;
		float playerHealth = finder.health;
		range = playerHealth * 0.1f;
		
		//		print ("range " + range);
		//		print ("total distance " + totaldistance);
		
		float totaldistance = Vector3.Distance (player.position, transform.position);
		print (totaldistance + ", " + range);
		if (totaldistance > range) {
			WalkTowards ();
		} else {
			WalkRandom ();
		}

		cc.Move (speed);
	}

	//The robot walks towards the player
	void WalkTowards (){
		transform.LookAt (player);
		speed = new Vector3 (0, 0, Time.deltaTime * movementSpeed);
		speed = transform.rotation * speed;
	}

	//The robot walks around randomly
	void WalkRandom (){
		//every three seconds change direction
		if (frame % 60 == 0) {
			float random = Random.Range (-1f, 1f);
			float rotLeftRight = random * 20;
			random = Random.Range (-1f, 1f);
			float rotUpDown = random * 20;
			transform.Rotate (rotUpDown, rotLeftRight, 0); 
		}
		//moves forward one unit per second
		speed = new Vector3 (0, 0, Time.deltaTime * movementSpeed);
		speed = transform.rotation * speed;
	}

}
