using UnityEngine;
using System.Collections;

public class GhostDetection : MonoBehaviour {

	public bool roundStarted;
	private Collider coll;
	private FinderController finder;

	// Use this for initialization
	void Start () {
		coll = GetComponent<Collider> ();
		finder = GameObject.FindGameObjectWithTag ("Finder").GetComponent<FinderController>();
	}

	void OnTriggerStay (Collider other) {
		if (roundStarted) {
			if (other.tag == "Ghost") {
				Transform castpoint = transform.GetChild (0).GetComponentInChildren<Transform> ();
				Vector3 fwd = other.transform.position - castpoint.position;
				Ray ray = new Ray (castpoint.position, fwd);
				float prox = Vector3.Angle (transform.forward, fwd); //proximity to center of view cone
				Debug.DrawRay (castpoint.position, fwd, Color.green);
				RaycastHit hit;
				if (Physics.Raycast (castpoint.position, fwd, out hit, 100))
					finder.TakeDamage(prox);
//			print (prox);
			}

			if (other.tag == "Item") {
				Transform castpoint = transform.GetChild (0).GetComponentInChildren<Transform> ();
				Vector3 fwd = transform.forward;
				Ray ray = new Ray (castpoint.position, fwd);
				Debug.DrawRay (castpoint.position, fwd, Color.green);
				RaycastHit hit;
				if (Physics.Raycast (castpoint.position, fwd, out hit, 100) &&
					hit.transform.tag == "Item")
					hit.transform.GetComponent<ItemScript> ().LookedAt ();
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
