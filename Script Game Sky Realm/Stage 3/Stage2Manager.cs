using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Stage2Manager : MonoBehaviour {
	public int deathCount;
	public bool isBossDead;

	//flag for wave enemy
	public bool wave1Clear;
	public bool wave2Clear;
	public bool wave3Clear;

	public bool DeathStage2Trigger;
	//trigger for wave
	public bool wave2Trigger;
	public bool wave3Trigger;

	//trigger for boss
	public bool isDragonBossSpawned;

	//for timer  and score related content
	public Text timerUI;
	public float timer;
	public float timerResult;
	public bool timerOn;
	public Text timerResultUI;
	public int totalDamageTaken;
	public Text totalDamageTakenUI;
	public float totalStage2Result;
	public Text totalStage2ResultUI;



	//barrier
	public GameObject barrier1;
	public GameObject barrier2;
	public GameObject barrier3;

	//audio
	public AudioSource bgMusic;
	public AudioSource bossMusic;
	public GameObject Player;

	public bool isStage2Finished;

	void Start () {
		Time.timeScale = 1;

		Player = GameObject.FindGameObjectWithTag ("Player");
		//bgMusic = GetComponent<AudioSource> ();
		DeathStage2Trigger = false;
		wave1Clear = false;
		wave2Clear = false;
		wave3Clear = false;
		totalDamageTaken = 0;
		timerResult = 0;
		timer = 0;
		isDragonBossSpawned = false;
		isStage2Finished = false;
		wave2Trigger = false;
		wave3Trigger = false;

		timerOn = true;

	}

	// Update is called once per frame
	void Update () {

		if (isDragonBossSpawned == true) {
			
		}
		if (timerOn == true) {
			timer = timer + Time.deltaTime;
		}

		timerResultUI.text = Mathf.Round(timer).ToString();
		totalDamageTakenUI.text = totalDamageTaken.ToString ();
		totalStage2Result = 3400f - Mathf.Round (timer)  - totalDamageTaken;
		totalStage2ResultUI.text = totalStage2Result.ToString ();

		var realTimer = string.Format ("{0:0}:{1:00}", Mathf.Floor (timer / 60), timer % 60);
		timerUI.text = realTimer;




		if (deathCount == 14) {
			wave1Clear = true;
			barrier1.gameObject.SetActive (false);
		}
		if (deathCount == 24) {
			wave2Clear = true;
			barrier2.gameObject.SetActive (false);
		}
		if (deathCount == 40) {
			wave3Clear = true;
			barrier3.gameObject.SetActive (false);
		}

		if (isBossDead==true) {
			isStage2Finished = true;

		}
		if (isStage2Finished == true) {
			ShowResult ();
		}
	}
	void ShowResult(){
		Player.GetComponent<PlayerInteraction2> ().isPaused = true;
		Player.GetComponent<PlayerInteraction2> ().PauseGame();


	}
	void SetCursorState (CursorLockMode wantedMode)
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}

}
