using UnityEngine;
using System.Collections;

public class Portal1Script : MonoBehaviour {

	public AudioClip finishedSound;

	public GameObject stage1Manager;
	void Start () {

		stage1Manager = GameObject.FindGameObjectWithTag ("Stage1Manager");
	

	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint (finishedSound, this.transform.position, 5f);
			stage1Manager.GetComponent<Stage1Manager> ().isStage1Finished = true;


		}
	}
}
