using UnityEngine;
using System;
using UnityEngine.Networking;
public class GameManager : MonoBehaviour {
	[Range(0, 1)]
	public int playerID;

	private GameObject finder;
	private GameObject ghost;
	private Transform finderCam;
	private Transform ghostCam;
	
	// Use this for initialization
	void Start () {

		//settings for phone usage
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		/*
		finder = GameObject.FindGameObjectWithTag ("Finder");
		ghost = GameObject.FindGameObjectWithTag ("Ghost");
		finderCam = finder.transform.FindChild("CardboardMain").FindChild("Head").FindChild("Main Camera");
		ghostCam = ghost.transform.FindChild("CardboardMain").FindChild("Head").FindChild("Main Camera");

		//player is finder
		if (playerID == 0) 
		{
			finderCam.GetComponent<Camera>().enabled = true;
			finderCam.tag = "MainCamera";
			finderCam.GetComponent<AudioListener>().enabled = true;
		}

		//player is ghost
		else if (playerID == 1) 
		{
			ghostCam.GetComponent<Camera>().enabled = true;
			ghostCam.tag = "MainCamera";
			ghostCam.GetComponent<AudioListener>().enabled = true;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	}
}
