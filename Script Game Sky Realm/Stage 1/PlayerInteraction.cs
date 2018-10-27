using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteraction : MonoBehaviour {

	// Use this for initialization
	public GameObject stage1Manager;

	public int S1EnemyKillCount;
	private GameObject weapon;
	public bool currentStage1;

	private bool isPaused;
	public GameObject pauseMenu;
	private GameObject tutorialScript;

	public FirstPersonController fpscontroller;

	void Start () {
		stage1Manager  = GameObject.FindGameObjectWithTag("Stage1Manager");
		S1EnemyKillCount = 0;
		weapon = GameObject.FindGameObjectWithTag("Weapon");
		isPaused = false;

		tutorialScript = GameObject.FindGameObjectWithTag ("TutorialScript");
		pauseMenu = GameObject.FindGameObjectWithTag ("UserCanvasS3");
		fpscontroller = GetComponent<FirstPersonController> ();

	}
	
	// Update is called once per frame
	void Update () {



		stage1Manager.GetComponent<Stage1Manager> ().deathCount = S1EnemyKillCount;

		if (Input.GetKeyDown (KeyCode.Escape) && this.GetComponent<PlayerHealth>().playerDeathStatus == false) {
			Cursor.visible = true;
			SetCursorState (CursorLockMode.None);
			fpscontroller.enabled = false;
			PauseGame ();


		}

	}



	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("DeathStage1Trigger")){
			stage1Manager.GetComponent<Stage1Manager>().deathTrigger =true;
			this.GetComponent<PlayerHealth> ().hp = 0;
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage1TriggerWave2")) 
		{
			stage1Manager.GetComponent<Stage1Manager> ().wave2Trigger = true;
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage1TriggerWave3")) {
			stage1Manager.GetComponent<Stage1Manager> ().wave3Trigger = true;
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage1TriggerWave4")) {
			stage1Manager.GetComponent<Stage1Manager> ().wave4Trigger = true;
			Destroy (other.gameObject);
		}
		//tutorial related
		if (other.gameObject.CompareTag ("Stage1TriggerTutorial1")) {
			tutorialScript.GetComponent<TutorialScript> ().DisplayTutorial1 ();
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage1TriggerTutorial0")) {
			tutorialScript.GetComponent<TutorialScript> ().DisplayTutorial0 ();
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage1TriggerTutorial00")) {
			tutorialScript.GetComponent<TutorialScript> ().DisplayTutorial00 ();
			Destroy (other.gameObject);
		}
	}
	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}
	public void PauseGame(){

		if (isPaused == false) {
			Time.timeScale = 0;
			isPaused = true;
			pauseMenu.GetComponent<PauseMenu3> ().pauseMenu.enabled = true;
			pauseMenu.GetComponent<PauseMenu3> ().isGamePaused = true;

	
		} 

		else if(isPaused == true){
			Time.timeScale = 1;
			isPaused = false;
			weapon.GetComponent<Crosshair> ().isCrossHairOn = true;
			pauseMenu.GetComponent<PauseMenu3> ().pauseMenu.enabled = false;
			pauseMenu.GetComponent<PauseMenu3> ().isGamePaused = false;
			fpscontroller.enabled = true;
			Cursor.visible = false;
		}


	}

}
