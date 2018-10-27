using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverS3 : MonoBehaviour {


	public Canvas GameOverMenu;
	public Button restartButton;
	public Button menuButton;



	// Use this for initialization
	void Start () {
		GameOverMenu = GameOverMenu.GetComponent<Canvas> ();
		restartButton = restartButton.GetComponent<Button> ();
		menuButton = menuButton.GetComponent<Button> ();

		GameOverMenu.enabled = false;

	}
	public void Restart1(){
		Application.LoadLevel (1);
	}

	public void Restart2(){
		Application.LoadLevel (2);
	}
	public void Restart3(){
		Application.LoadLevel (3);
	}
	public void MainMenu(){
		print ("exit");
		Application.LoadLevel (0);
	}


	// Update is called once per frame
	void Update () {
	
	}

}
