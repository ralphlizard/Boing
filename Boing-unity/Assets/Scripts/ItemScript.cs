using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	private Transform item;
	private float timer; //item is picked up when this runs out
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		item = transform.GetChild (0);
		timer = 100;
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		// bounce back if not being looked at 
//		if (timer <= 100)
//			timer += Time.deltaTime;

		//pick me up
		if (timer <= 0) 
		{
			gameManager.numItems--;
			Destroy(this.gameObject);
			//play audio
		}
	}

	//called by GhostDetection script
	public void LookedAt() {
		timer -= Time.deltaTime * 20;
		float shrink = timer * 0.01f;
		item.localScale = new Vector3(shrink, shrink, shrink);
	}
}