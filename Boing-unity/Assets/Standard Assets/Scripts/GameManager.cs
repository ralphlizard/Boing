using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Range(0, 1)]
	public int playerID;

	private GameObject finder;
	private GameObject ghost;

	// Use this for initialization
	void Start () {

		finder = GameObject.FindGameObjectWithTag ("Finder");
		ghost = GameObject.FindGameObjectWithTag ("Ghost");

		Camera finderCamera = finder.transform.FindChild ("Head").FindChild ("Main Camera").GetComponent<Camera> ();
		Camera ghostCamera = ghost.transform.FindChild("Head").FindChild("Main Camera").GetComponent<Camera>();
		AudioListener finderListener = finder.transform.FindChild ("Head").FindChild ("Main Camera").GetComponent<AudioListener> ();
		AudioListener ghostListener = ghost.transform.FindChild ("Head").FindChild ("Main Camera").GetComponent<AudioListener> ();

		//player is finder
		if (playerID == 0) 
		{
			finderCamera.enabled = true;
			finderListener.enabled = true;
			ghostCamera.enabled = false;
			ghostListener.enabled = false;
		}

		//player is ghost
		else if (playerID == 1) 
		{
			finderCamera.enabled = false;
			finderListener.enabled = false;
			ghostCamera.enabled = true;
			finderListener.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
