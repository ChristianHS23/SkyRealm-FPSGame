using UnityEngine;
using System.Collections;

public class BarrierRock1Script : MonoBehaviour {

	// Use this for initialization

	public bool naikAnimation;
	public bool turunAnimation;
	public AudioClip batuSound;

	public bool inTrigger = false;

	private bool timerTrigger = false;
	float timer;

	private Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
		timer = 0;


		naikAnimation = false;
		turunAnimation = true;
	}
	
	// Update is called once per frame
	void Update () {
		//print (timer);

		if (timerTrigger == true) {
			
			timer = timer + Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.E) && inTrigger == true && naikAnimation == false) {
			timerTrigger = true;
			naikAnimation = true;
			turunAnimation = false;
			this.gameObject.tag = "RockBarrierUp";
			AudioSource.PlayClipAtPoint (batuSound, transform.position, 500f);
			anim.SetTrigger ("Naik");

		}
		else if (timer >= 7) {
			naikAnimation = false;
			turunAnimation = true;
			this.gameObject.tag = "RockBarrierDown";
			AudioSource.PlayClipAtPoint (batuSound, transform.position, 500f);
			anim.SetTrigger ("Turun");

			timer = 0;
			timerTrigger = false;
		}
	
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {
			//print ("object tersentuh");
			inTrigger = true;

		}

	}

	void OnTriggerExit(Collider other){
		inTrigger = false;
	}
}
