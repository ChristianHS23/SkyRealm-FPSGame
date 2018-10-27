using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerHealth : MonoBehaviour {




	//Health Bar
	public int hp = 200;
	public Text HPUI;

	//Blood Effect
	public GameObject CanvasBlood;
	private float bloodTime = 0.2f;

	//camera and death animation
	public bool deathPlayer;
	public Camera camPlayer;
	public Camera camWorld;
	public GameObject player;
	public Animator anim;

	//score related things
	public int totalDamageTaken;


	public GameObject gameOverCanvas;

	public bool playerDeathStatus;

	FirstPersonController fpscontroller;

	//stagemanager
	public GameObject stage1Manager;
	//stagemanager
	public GameObject stage2Manager;
	//stagemanager
	public GameObject stage3Manager;


	private GameObject weapon;

	void Start () {
//		camWorld.enabled = false;

		deathPlayer =false;
		anim = GetComponent<Animator> ();
		gameOverCanvas = GameObject.FindGameObjectWithTag ("UserCanvasS3");

		weapon = GameObject.FindGameObjectWithTag("Weapon");

		totalDamageTaken = 0;

		stage1Manager = GameObject.FindGameObjectWithTag ("Stage1Manager");
		stage2Manager = GameObject.FindGameObjectWithTag ("Stage2Manager");
		stage3Manager = GameObject.FindGameObjectWithTag ("Stage3Manager");
		playerDeathStatus = false;

		fpscontroller = GetComponent<FirstPersonController> ();
	}

	// Update is called once per frame
	void Update () {


		if (hp < 0) {
			hp = 0;
		}
		HPUI.text = hp.ToString ();

		if (stage1Manager != null) {
			stage1Manager.GetComponent<Stage1Manager> ().totalDamageTaken = totalDamageTaken;
		}
		if (stage2Manager != null) {
			stage2Manager.GetComponent<Stage2Manager> ().totalDamageTaken = totalDamageTaken;
		}
		if (stage3Manager != null) {
			stage3Manager.GetComponent<Stage3Manager> ().totalDamageTaken = totalDamageTaken;
		}


		if (Input.GetKeyDown (KeyCode.H)) {
			
			anim.Play ("DeathAnimation");


		}

		if (hp <= 0 && playerDeathStatus == false) {
			playerDeathStatus = true;
			gameOver ();
		}



	}

	void ShowBloodEffect()
	{
		if (CanvasBlood != null) {
//			print ("darah");
			StopAllCoroutines ();
			CanvasBlood.SetActive (true);
			StartCoroutine (ResetBloodCanvas ());

		} else {
			
		}
	}

	IEnumerator ResetBloodCanvas()
	{
		yield return new WaitForSeconds (bloodTime);
		CanvasBlood.SetActive (false);
	}
	void gameOver(){
		
			//player.GetComponent<FirstPersonController> ().GetComponent<MouseLook> ().enabled = false;
			weapon.GetComponent<Crosshair> ().isCrossHairOn = false;
			Time.timeScale = 0;
			fpscontroller.enabled = false;
			Cursor.visible = true;
			SetCursorState (CursorLockMode.None);
			gameOverCanvas.GetComponent<GameOverS3> ().GameOverMenu.enabled = true;



	}

	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}
	void TakeDamage(int dmg)
	{
		ShowBloodEffect ();
		hp = hp - dmg;
		totalDamageTaken += dmg;
	}



	void OnTriggerEnter(Collider other)
	{
		//take damage from Bullet
		//Debug.Log (other.gameObject.name);
		if (other.gameObject.CompareTag ("bullet")) 
		{
			ShowBloodEffect ();
			TakeDamage (10);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("Tornado")) 
		{
			ShowBloodEffect ();
			TakeDamage (100);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("SoundWave")) 
		{
			ShowBloodEffect ();
			TakeDamage (100);
			Destroy (other.gameObject);
		}

		//get healthpack
		if (other.gameObject.CompareTag ("HealthPack")) 
		{
			hp = hp + 20;
			Destroy (other.gameObject);
		}


	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag ("DragonIceBreath")) 
		{
			ShowBloodEffect ();
			TakeDamage (1);
		}

	}
}
