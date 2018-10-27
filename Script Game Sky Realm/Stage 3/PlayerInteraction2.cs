using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteraction2 : MonoBehaviour {
	public int S2EnemyKillCount;
	public GameObject stage2Manager;

	public bool currentStage2;
	public bool isPaused;
	public GameObject pauseMenu;
	public bool isBossDead;
	public GameObject resultCanvas;
	private GameObject tutorialScript;
	FirstPersonController fpscontroller;

	float timer;


	private GameObject weapon;
	void Start () {
		stage2Manager  = GameObject.FindGameObjectWithTag("Stage2Manager");
		S2EnemyKillCount = 0;
		fpscontroller = GetComponent<FirstPersonController> ();
		tutorialScript = GameObject.FindGameObjectWithTag ("TutorialScript");
		weapon = GameObject.FindGameObjectWithTag("Weapon");
		pauseMenu = GameObject.FindGameObjectWithTag ("UserCanvasS3");
		isPaused = false;
		isBossDead = false;

		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		print (timer);

		if (Input.GetKeyDown (KeyCode.Escape) && this.GetComponent<PlayerHealth>().playerDeathStatus == false) {


			Cursor.visible = true;
			SetCursorState (CursorLockMode.None);
			fpscontroller.enabled = false;
			PauseGame ();

		}
		isBossDead = stage2Manager.GetComponent<Stage2Manager> ().isBossDead;

		stage2Manager.GetComponent<Stage2Manager> ().deathCount = S2EnemyKillCount;

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Stage2TriggerWave2")) 
		{
			stage2Manager.GetComponent<Stage2Manager> ().wave2Trigger = true;
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage2TriggerWave3")) 
		{
			stage2Manager.GetComponent<Stage2Manager> ().wave3Trigger = true;
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("DeathStage2Trigger")) {
			stage2Manager.GetComponent<Stage2Manager> ().DeathStage2Trigger = true;
			this.GetComponent<PlayerHealth> ().hp = 0;
		}
		if (other.gameObject.CompareTag ("DragonBossTrigger")) {
			stage2Manager.GetComponent<Stage2Manager> ().isDragonBossSpawned = true;
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Stage3TriggerTutorial0")) {
			tutorialScript.GetComponent<TutorialScript2> ().DisplayTutorial0 ();
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
		else if (isPaused == true && isBossDead == true) {

			timer += Time.deltaTime;

			if (timer >= 4) {

				Time.timeScale = 0;
				Cursor.visible = true;
				SetCursorState (CursorLockMode.None);
				fpscontroller.enabled = false;
				resultCanvas.SetActive (true);

			}
		}
		else {
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
