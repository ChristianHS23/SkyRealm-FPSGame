using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TutorialScript : MonoBehaviour {

	// Use this for initialization
	public GameObject tutorial00Canvas;
	public GameObject tutorial0Canvas;
	public GameObject tutorial1Canvas; //tutorial batu
	public GameObject tutorial2Canvas; //tutorial portal
	public GameObject pauseMenu;


	private GameObject weapon;
	public bool tutorial00Canvasl;
	public bool tutorial0Canvasl;
	public bool tutorial1Canvasl;

	public bool isTutorialOn;

	public FirstPersonController fpscontroller;


	public bool isPaused;
	void Start () {
		//for all tutorial
		isTutorialOn = true;

		//fpscontroller.enabled = false;
		isPaused = false;

		weapon = GameObject.FindGameObjectWithTag("Weapon");
		pauseMenu = GameObject.FindGameObjectWithTag ("UserCanvasS3");
		//tutor 1 
		tutorial1Canvasl = false;

		//fpscontroller = GetComponent<FirstPersonController> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (isPaused == true && Input.GetKeyDown (KeyCode.Return)) {
			print ("game resumed");
			ResumeGame ();
		}
	}
	public void DisplayTutorial00(){

		tutorial00Canvas.SetActive (true);
		PauseGame ();
	}
	public void DisplayTutorial0(){

		tutorial0Canvas.SetActive (true);
		PauseGame ();
	}


	public void DisplayTutorial1(){
		
		tutorial1Canvas.SetActive (true);
		PauseGame ();
	}

	public void DisplayTutorial2(){

		tutorial2Canvas.SetActive (true);
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
		Time.timeScale = 1;
		isPaused = false;
		fpscontroller.enabled = true;
		Cursor.visible = false;
		tutorial00Canvas.SetActive (false);
		tutorial0Canvas.SetActive (false);
		tutorial1Canvas.SetActive (false);
		tutorial2Canvas.SetActive(false);
	}

	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}

}
