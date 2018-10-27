using UnityEngine;
using System.Collections;

public class Portal2Script : MonoBehaviour {
	public AudioClip finishedSound;

	public GameObject stage3Manager;
	void Start () {

		stage3Manager = GameObject.FindGameObjectWithTag ("Stage3Manager");


	}

	// Update is called once per frame
	void Update () {



	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint (finishedSound, this.transform.position, 5f);
			stage3Manager.GetComponent<Stage3Manager> ().isStage3Finished = true;

	
		}
	}
}
