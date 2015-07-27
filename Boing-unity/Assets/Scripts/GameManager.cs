using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Range(0, 1)]
	public int playerID;
	public bool roundStarted;
	public int numItems;
	public GameObject tutorial;

	private GameObject tutorialClone;
	private GameObject finder;
	private GameObject ghost;
	private Transform finderCam;
	private Transform ghostCam;
	private GhostDetection ghostDetection;

	// Use this for initialization
	void Start () {

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		finder = GameObject.FindGameObjectWithTag ("Finder");
		ghost = GameObject.FindGameObjectWithTag ("Ghost");
		finderCam = finder.transform.FindChild("CardboardMain").FindChild("Head").FindChild("Main Camera");

		ghostDetection = GameObject.FindGameObjectWithTag ("GhostDetection").GetComponent<GhostDetection> ();

		//testing
		PlaceTutorial ();
		StartRound ();
	}
	
	// Update is called once per frame
	void Update () {
		if (roundStarted) {
			CheckNumItem();
		}
	}

	void CheckNumItem () {
		if (numItems == 0) 
		{
			FinderWin();
		}
	}

	public void StartRound() {
		print ("Round started");
		roundStarted = true;

		finder.GetComponent<FinderController> ().roundStarted = roundStarted;
		finder.GetComponent<FinderController> ().health = 100;

		ghost.GetComponent<GhostScript> ().roundStarted = roundStarted;
		ghostDetection.roundStarted = roundStarted;

		//instantiate items
		numItems = 1;
	}

	public void GhostWin() {
		print ("Round over");
		roundStarted = false;
		ghost.GetComponent<GhostScript> ().roundStarted = roundStarted;
		finder.GetComponent<FinderController> ().roundStarted = roundStarted;
		ghostDetection.roundStarted = roundStarted;
	}

	public void FinderWin() {
		print ("Round over");
		roundStarted = false;
		ghost.GetComponent<GhostScript> ().roundStarted = roundStarted;
		finder.GetComponent<FinderController> ().roundStarted = roundStarted;
		ghostDetection.roundStarted = roundStarted;
	}

	void PlaceTutorial() 
	{
		tutorialClone = Instantiate (tutorial) as GameObject;
		tutorialClone.transform.SetParent (finder.transform);
		tutorialClone.transform.localPosition = new Vector3 (0, 0, 3);
		tutorialClone.transform.localEulerAngles = new Vector3 (270, 0, 0);
		tutorialClone.transform.parent = null;
		
	}
}