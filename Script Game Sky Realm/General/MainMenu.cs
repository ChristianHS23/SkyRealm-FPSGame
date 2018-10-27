using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Canvas title;
	public Canvas quitMenu;
	public Canvas settingMenu;
	public Canvas firstMenu;
	public Button startText;
	public Button settingText;
	public Button exitText;
	public GameObject mute;
	public GameObject unmute;
	public Button SbackButton;
	public GameObject bgMusic;
	public Toggle crosshair1;
	public Toggle crosshair2;
	public Canvas creditMenu;
	public Canvas creditMenu2;

	// Use this for initialization
	void Start () {

		Time.timeScale = 1;
		bgMusic = GameObject.FindGameObjectWithTag("Music");
		title = title.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		settingMenu = settingMenu.GetComponent<Canvas> ();
		firstMenu = firstMenu.GetComponent<Canvas> ();
		creditMenu = creditMenu.GetComponent<Canvas> ();
		creditMenu2 = creditMenu2.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		settingText = settingText.GetComponent<Button> ();
		SbackButton = SbackButton.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		title.enabled = true;
		firstMenu.enabled = true;
		quitMenu.enabled = false;
		settingMenu.enabled = false;
		creditMenu.enabled = false;
		creditMenu2.enabled = false;
	}
	public void creditPress(){
		title.enabled = false;
		firstMenu.enabled = false;
		creditMenu.enabled = true;
	}
	public void nextCPress(){
		creditMenu.enabled = false;
		creditMenu2.enabled = true;
	}
	public void backCPress(){
		creditMenu2.enabled = false;
		title.enabled = true;
		firstMenu.enabled = true;
	}
	public void exitPress(){
		firstMenu.enabled = false;
		quitMenu.enabled = true;
		settingMenu.enabled = false;
	}

	public void settingPress(){
		firstMenu.enabled = false;
		quitMenu.enabled = false;
		settingMenu.enabled = true;

	}
	public void backPress(){
		firstMenu.enabled = true;
		quitMenu.enabled = false;
		settingMenu.enabled = false;

	}
	public void noPress(){
		firstMenu.enabled = true;
		quitMenu.enabled = false;
		settingMenu.enabled = false;

	}

	public void StartLevel(){
		Application.LoadLevel (1);
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
		

		} else {
			crosshair2.isOn = true;
	
		}
	}
	public void Toggle2(){
		if (crosshair2.isOn == true) {
			crosshair1.isOn = false;
	
		}else {
			crosshair1.isOn = true;
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
