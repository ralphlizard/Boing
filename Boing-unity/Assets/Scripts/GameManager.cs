﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Range(0, 1)]
	public int playerID;
	public GameObject cardboard;
	public GameObject finderCardboard;

	private GameObject finder;
	private GameObject ghost;

	// Use this for initialization
	void Start () {

		finder = GameObject.FindGameObjectWithTag ("Finder");
		ghost = GameObject.FindGameObjectWithTag ("Ghost");


		//player is finder
		if (playerID == 0) 
		{
			GameObject cardboardClone = Instantiate (finderCardboard);
			cardboardClone.transform.SetParent (finder.transform);
			finder.GetComponent<FinderController>().isPlayer = true;
			cardboardClone.transform.localPosition = new Vector3(0,0,0);
			cardboardClone.transform.localRotation = new Quaternion(0,0,0,0);
		}

		//player is ghost
		else if (playerID == 1) 
		{
			GameObject cardboardClone = Instantiate (cardboard);
			cardboardClone.transform.SetParent (ghost.transform);
			ghost.GetComponent<GhostController>().isPlayer = true;
			cardboardClone.transform.localPosition = new Vector3(0,0,0);
			cardboardClone.transform.localRotation = new Quaternion(0,0,0,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
