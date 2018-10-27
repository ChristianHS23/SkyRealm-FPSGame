using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteraction3 : MonoBehaviour {

	public GameObject stage3Manager;

	public int S3EnemyKillCount;

	public bool currentStage3;

	private bool isPaused;
	public GameObject pauseMenu;
	private GameObject weapon;
	private GameObject tutorialScript;

	FirstPersonController fpscontroller;

	public bool isBossSpawned = false;
	private bool isBossSpawnSoundFinished = false;

	public AudioClip bossSpawn;

	void Start () {
		stage3Manager  = GameObject.FindGameObjectWithTag("Stage3Manager");
		pauseMenu = GameObject.FindGameObjectWithTag ("UserCanvasS3");
		S3EnemyKillCount = 0;
		tutorialScript = GameObject.FindGameObjectWithTag ("TutorialScript");
		weapon = GameObject.FindGameObjectWithTag("Weapon");
		fpscontroller = GetComponent<FirstPersonController> ();

		isPaused = false;
	}

	// Update is called once per frame
	void Update () {

	//	stage3Manager.GetComponent<Stage1Manager> ().deathCount = S3EnemyKillCount;

		if (Input.GetKeyDown (KeyCode.Escape) && this.GetComponent<PlayerHealth>().playerDeathStatus == false) {

			print ("key press");
			Cursor.visible = true;
			SetCursorState (CursorLockMode.None);
			fpscontroller.enabled = false;
			PauseGame ();

		}

		if (isBossSpawned == true && isBossSpawnSoundFinished == false) {
			PlayBossSpawnSound ();
			isBossSpawnSoundFinished = true;
		}

		CameraShake ();

	}


	void CameraShake(){
		if (Input.GetKeyDown (KeyCode.T)) {
			this.gameObject.GetComponentInChildren<CameraShake> ().shakeStat = true;
		}
	}

	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}

	void OnTriggerEnter (Collider other)
	{	
		if (other.gameObject.CompareTag ("Stage3TriggerWave0")) 
		{
			stage3Manager.GetComponent<Stage3Manager> ().wave0Trigger = true;
		}
		if (other.gameObject.CompareTag ("Stage3TriggerWave1")) 
		{
			stage3Manager.GetComponent<Stage3Manager> ().wave1Trigger = true;
		}
		if (other.gameObject.CompareTag ("DeathStage3Trigger")) {
			stage3Manager.GetComponent<Stage3Manager> ().death3Trigger = true;
			this.GetComponent<PlayerHealth> ().hp = 0;
		}
		if (other.gameObject.CompareTag ("Stage2TriggerTutorial0")) {
			tutorialScript.GetComponent<TutorialScript1> ().DisplayTutorial0 ();
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage2TriggerTutorial1")) {
			tutorialScript.GetComponent<TutorialScript1> ().DisplayTutorial1 ();
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage2TriggerTutorial2")) {
			tutorialScript.GetComponent<TutorialScript1> ().DisplayTutorial2 ();
			Destroy (other.gameObject);
		}

	}


	void PlayBossSpawnSound(){
		AudioSource.PlayClipAtPoint (bossSpawn, transform.position, 10f);
	}

	void PauseGame(){

		if (isPaused == false) {
			Time.timeScale = 0;
			isPaused = true;
			pauseMenu.GetComponent<PauseMenu3> ().pauseMenu.enabled = true;
			pauseMenu.GetComponent<PauseMenu3> ().isGamePaused = true;
		} else {
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
