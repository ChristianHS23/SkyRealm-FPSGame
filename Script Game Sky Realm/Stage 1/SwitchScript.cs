using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	public AudioClip shurr;
	public float soundVolume = 5f;


	private GameObject stage1Manager;

	public GameObject textCanvas;

	private Collider box;

	public bool isSwitchDown;

	void Start () {

	
		stage1Manager = GameObject.FindGameObjectWithTag ("Stage1Manager");
		anim = GetComponent<Animator> ();
		box = GetComponent<BoxCollider> ();

		isSwitchDown = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isSwitchDown == true) {
			textCanvas.SetActive (false);
			stage1Manager.GetComponent<Stage1Manager> ().switchCounter += 1;
			Destroy (box);
			Destroy (this.GetComponent<SwitchScript> ());
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				
				anim.SetTrigger ("Turun");
				AudioSource.PlayClipAtPoint (shurr,transform.position,soundVolume);
				isSwitchDown = true;
			

			}

			textCanvas.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			textCanvas.SetActive (false);
		}
	}
		

		
}
