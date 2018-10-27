using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage1Manager : MonoBehaviour {

	public int deathCount;



	//flag for wave enemy
	public bool wave1Clear;
	public bool wave2Clear;
	public bool wave3Clear;
	public bool wave4Clear;

	public bool death1Trigger;
	public bool deathTrigger;
	//trigger for wave
	public bool wave2Trigger;
	public bool wave3Trigger;
	public bool wave4Trigger;

	//barrier
	public GameObject barrier1;
	public GameObject barrier2;
	public GameObject barrier3;

	//for timer  and score related content
	public Text timerUI;
	public float timer;
	public float timerResult;
	public bool timerOn;
	public Text timerResultUI;
	public int totalDamageTaken;
	public Text totalDamageTakenUI;
	public float totalStage1Result;
	public Text totalStage1ResultUI;
	public GameObject resultCanvas;
	public Text switchCounterUI;


	//tutorial
	private GameObject tutorialScript;
	public int switchCounter;

	public GameObject portal1;
	public GameObject playerHealth;


	public bool isStage1Finished;

	public bool isSwitchFunctionFinished;

	void Start () {
		Time.timeScale = 1;
		tutorialScript = GameObject.FindGameObjectWithTag ("TutorialScript");
		playerHealth = GameObject.FindWithTag ("Player");
		death1Trigger = false;
		wave1Clear = false;
		wave2Trigger = false;
		wave3Trigger = false;
		wave4Trigger = false;
		isStage1Finished = false;
		totalDamageTaken = 0;
		timerResult = 0;
		timer = 0;
		isSwitchFunctionFinished = false;
		timerOn = true;
		deathTrigger = false;



		switchCounter = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (timerOn == true) {
			timer = timer + Time.deltaTime;
		}

		switchCounterUI.text = switchCounter.ToString ();

		timerResultUI.text = Mathf.Round(timer).ToString();
		totalDamageTakenUI.text = totalDamageTaken.ToString ();
		totalStage1Result = 2700f - Mathf.Round (timer) - totalDamageTaken;
		totalStage1ResultUI.text = totalStage1Result.ToString ();

		if (isStage1Finished == true) {
			ShowResult ();
		}

		var realTimer = string.Format ("{0:0}:{1:00}", Mathf.Floor (timer / 60), timer % 60);
		timerUI.text = realTimer;

	
		if (deathTrigger == true) {
			playerHealth.GetComponent<PlayerHealth> ().hp=0;
		}

		if (switchCounter >= 3 && isSwitchFunctionFinished == false) {


			portal1.SetActive (true);

			tutorialScript.GetComponent<TutorialScript> ().DisplayTutorial2 ();
			isSwitchFunctionFinished = true;

		}

		if (deathCount == 12) {
			wave1Clear = true;
			barrier1.gameObject.SetActive (false);
		}
		if (deathCount == 22) {
			wave2Clear = true;
			barrier2.gameObject.SetActive (false);
		}
		if (deathCount == 27) {
			wave3Clear = true;
			barrier3.gameObject.SetActive (false);
		}
	
	}

	void ShowResult(){
		tutorialScript.GetComponent<TutorialScript> ().PauseGame ();
		Time.timeScale = 0;
		resultCanvas.SetActive (true);

	}
}
