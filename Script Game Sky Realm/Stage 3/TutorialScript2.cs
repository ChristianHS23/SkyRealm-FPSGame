using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TutorialScript2 : MonoBehaviour {

	// Use this for initialization

	public GameObject tutorial0Canvas;
	public GameObject pauseMenu;
	private GameObject weapon;

	public bool tutorial0Canvas3;


	public bool isTutorialOn;

	public FirstPersonController fpscontroller;


	public bool isPaused;
	void Start () {
		//for all tutorial
		isTutorialOn = true;

		//fpscontroller.enabled = false;
		isPaused = false;
		pauseMenu = GameObject.FindGameObjectWithTag ("UserCanvasS3");
		weapon = GameObject.FindGameObjectWithTag("Weapon");

		//tutor 1 
		tutorial0Canvas3 = false;

		//fpscontroller = GetComponent<FirstPersonController> ();

	}

	// Update is called once per frame
	void Update () {

		if (isPaused == true && Input.GetKeyDown (KeyCode.Return)) {
			print ("game resumed");
			ResumeGame ();
		}
	}
	public void DisplayTutorial0(){

		tutorial0Canvas.SetActive (true);
		PauseGame ();
	}


	public void PauseGame(){

		weapon.GetComponent<Crosshair> ().isCrossHairOn = false;
		Time.timeScale = 0;
		isPaused = true;
		Cursor.visible = true;
		SetCursorState (CursorLockMode.None);
		fpscontroller.enabled = false;



	}

	public void ResumeGame(){
		weapon.GetComponent<Crosshair> ().isCrossHairOn = true;
		pauseMenu.GetComponent<PauseMenu3> ().pauseMenu.enabled = false;
		pauseMenu.GetComponent<PauseMenu3> ().isGamePaused = false;
		tutorial0Canvas.SetActive (false);

		Time.timeScale = 1;
		isPaused = false;
		fpscontroller.enabled = true;
		Cursor.visible = false;
	}

	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}

}
