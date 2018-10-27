using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Stage3Manager : MonoBehaviour {
	

	//flag for wave enemy
	public bool rockGolemWave0Clear;
	public bool rockGolemWave1Clear;
	public bool rockGolemWave2Clear;
	public bool rockGolemWave3Clear;
	public bool rockGolemWave4Clear;

	public AudioSource bossMusic;
	public AudioSource map3Music;

	private GameObject weapon;

	public int golemDeathCount; 
	public int bossGolemDeath;

	public GameObject batuAjaib;
	public GameObject miniBoss;

	public bool death3Trigger;
	//trigger for wave
	public bool wave0Trigger;
	public bool wave1Trigger;

	public bool bossTransition;
	public int ghostDeathCount;

	//for timer  and score related content
	public Text timerUI;
	public float timer;
	public float timerResult;
	public bool timerOn;
	public Text timerResultUI;
	public int totalDamageTaken;
	public Text totalDamageTakenUI;
	public float totalStage3Result;
	public Text totalStage3ResultUI;
	public GameObject resultCanvas;

	public FirstPersonController fpscontroller;

	public bool isStage3Finished;
	public GameObject triggertutorial3;
	public GameObject portal2;
	void Start () {
		//wave1Clear = false;
		//wave2Trigger = false;
		Time.timeScale = 1;

		weapon = GameObject.FindGameObjectWithTag("Weapon");
		//map3Music = GetComponent<AudioSource> ();

		bossMusic.enabled = false;

		bossTransition = false;
		ghostDeathCount = 0;
		bossGolemDeath = 0;
		golemDeathCount = 0;
		death3Trigger = false;
		wave0Trigger = false;
		wave1Trigger = false;

		//score and timer related content
		timerResult = 0;
		timer = 0;
		triggertutorial3.SetActive (false);
		timerOn = true;
	}

	// Update is called once per frame
	void Update () {

		if (timerOn == true) {
			timer = timer + Time.deltaTime;
		}

		timerResultUI.text = Mathf.Round(timer).ToString();
		totalDamageTakenUI.text = totalDamageTaken.ToString ();
		totalStage3Result = 3400f - Mathf.Round (timer)  - totalDamageTaken;
		totalStage3ResultUI.text = totalStage3Result.ToString ();

		var realTimer = string.Format ("{0:0}:{1:00}", Mathf.Floor (timer / 60), timer % 60);
		timerUI.text = realTimer;

		if (isStage3Finished == true) {
			ShowResult ();
		}



		if (ghostDeathCount == 6) {
			rockGolemWave0Clear = true;
		}
		if (golemDeathCount == 4 && ghostDeathCount == 16){
			rockGolemWave1Clear = true;
		}
		if (golemDeathCount == 8 && ghostDeathCount == 26) {
			rockGolemWave2Clear = true;
		}

		if (golemDeathCount == 8 && bossTransition == false) {
			batuAjaib.SetActive (false);
			rockGolemWave3Clear = true;
			bossTransition = true;
		}
		if (ghostDeathCount == 36) {
			rockGolemWave4Clear = true;
		}
		if (bossGolemDeath == 1 && rockGolemWave4Clear ==true) {
			triggertutorial3.SetActive (true);
			portal2.SetActive (true);
		}

		/*if (deathCount == 12) {
			wave1Clear = true;
			barrier1.gameObject.SetActive (false);
		}*/

	}

	void ShowResult(){
		PauseGame ();
		Time.timeScale = 0;
		resultCanvas.SetActive (true);

	}
	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}
	public void PauseGame(){
		Time.timeScale = 0;
		weapon.GetComponent<Crosshair> ().isCrossHairOn = false;
		Cursor.visible = true;
		SetCursorState (CursorLockMode.None);
		fpscontroller.enabled = false;

	}

}
