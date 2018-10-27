using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu3 : MonoBehaviour {
	
	public Canvas pauseMenu;
	public Canvas settingNextCanvas;
	public Button menuButton;
	public Button settingButton;
	public Button exitButton;
	public Button helpButton;
	public Canvas HelpCanvas;
	public Button backButton;
	public GameObject mute;
	public GameObject unmute;
	public Button SbackButton;
	public Toggle crosshair1;
	public Toggle crosshair2;

	public bool isGamePaused;

	private GameObject weapon;


	//audio related
	public GameObject bgMusic;




	// Use this for initialization
	void Start () {
		weapon = GameObject.FindGameObjectWithTag("Weapon");
		isGamePaused = false;
		//music
		bgMusic = GameObject.FindGameObjectWithTag("Music");

		pauseMenu=pauseMenu.GetComponent<Canvas>();
		settingNextCanvas=settingNextCanvas.GetComponent<Canvas>();
		menuButton = menuButton.GetComponent<Button> ();
		SbackButton = SbackButton.GetComponent<Button> ();
		settingButton = settingButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		helpButton = helpButton.GetComponent<Button> ();
		HelpCanvas = HelpCanvas.GetComponent<Canvas> ();
		backButton = backButton.GetComponent<Button> ();
		mute.SetActive (false); 
		settingNextCanvas.enabled = false;
		HelpCanvas.enabled = false;
		pauseMenu.enabled = false;

	}
	public void showTutorial(){
		HelpCanvas.enabled = true;
		pauseMenu.enabled = false;
	}
	public void hideTutorial(){
		HelpCanvas.enabled = false;
		pauseMenu.enabled = true;
	}
	public void settingMenu(){
		settingNextCanvas.enabled = true;
		pauseMenu.enabled = false;
//		print (pauseMenu.enabled);
	}
	public void BSettingMenu(){
		settingNextCanvas.enabled = false;
		pauseMenu.enabled=true;
	}
	public void Mute(){
		//koding music disini
		bgMusic.GetComponent<AudioSource>().enabled = true;
		mute.SetActive (false); 
		unmute.SetActive (true); 
	}
	public void unMute(){
		bgMusic.GetComponent<AudioSource>().enabled = false;
		mute.SetActive (true); 
		unmute.SetActive (false); 
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void Toggle1(){
		if (crosshair1.isOn == true) {
			crosshair2.isOn = false;
			weapon.GetComponent<Crosshair> ().isCrosshair1On = true;
			weapon.GetComponent<Crosshair> ().isCrosshair2On = false;

		} else {
			crosshair2.isOn = true;
			weapon.GetComponent<Crosshair> ().isCrosshair2On = true;
		}
	}

	public void Toggle2(){
		if (crosshair2.isOn == true) {
			crosshair1.isOn = false;
			weapon.GetComponent<Crosshair> ().isCrosshair2On = true;
			weapon.GetComponent<Crosshair> ().isCrosshair1On = false;
		}else {
			crosshair1.isOn = true;
			weapon.GetComponent<Crosshair> ().isCrosshair1On = true;
		}

	}


	// Update is called once per frame
	void Update () {
		

		/*if (crosshair1.onValueChanged.AddListener(CrossHair1On)) {
			if (crosshair1.isOn == true) {
				crosshair1.isOn = true;
				crosshair2.isOn = false;

			}
		}
	
	*/


	if (isGamePaused == false) {
			HelpCanvas.enabled = false;
			settingNextCanvas.enabled = false;
			//weapon.GetComponent<Crosshair> ().isCrossHairOn = true;
		} else if (isGamePaused == true) {
			weapon.GetComponent<Crosshair> ().isCrossHairOn = false;
		}

	
	}

	public void CrossHair1On(bool value){

	}


}
