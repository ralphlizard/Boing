using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Range(0, 1)]
	public int playerID;
	public GameObject cardboard;

	private GameObject finder;
	private GameObject ghost;

	// Use this for initialization
	void Start () {

		finder = GameObject.FindGameObjectWithTag ("Finder");
		ghost = GameObject.FindGameObjectWithTag ("Ghost");

		GameObject cardboardClone = Instantiate (cardboard);

		//player is finder
		if (playerID == 0) 
		{
			cardboardClone.transform.SetParent (finder.transform);
		}

		//player is ghost
		else if (playerID == 1) 
		{
			cardboardClone.transform.SetParent (ghost.transform);
		}
		cardboardClone.transform.localPosition = new Vector3(0,0,0);
		cardboardClone.transform.localRotation = new Quaternion(0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
