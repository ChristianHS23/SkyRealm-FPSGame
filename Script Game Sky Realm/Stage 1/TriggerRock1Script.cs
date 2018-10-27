using UnityEngine;
using System.Collections;

public class TriggerRock1Script : MonoBehaviour {

	// Use this for initialization

	public GameObject Rock1;
	void Start () {
		//Rock1 = this.transform.gameObject.pare
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			print ("object tersentuh");
			if (Input.GetKeyDown (KeyCode.E)) {
				if (Rock1.GetComponent<BarrierRock1Script> ().naikAnimation == false) {
					print ("object naik");
					Rock1.GetComponent<BarrierRock1Script> ().naikAnimation = true;
					Rock1.GetComponent<BarrierRock1Script> ().turunAnimation = false;
				}

				else if(Rock1.GetComponent<BarrierRock1Script> ().naikAnimation == true) {
					print ("object turun");
					Rock1.GetComponent<BarrierRock1Script> ().naikAnimation = false;
					Rock1.GetComponent<BarrierRock1Script> ().turunAnimation = true;
				}
			}
		}

	}
}
