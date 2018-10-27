using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public Texture2D crosshair;
	public Texture2D crosshair2;


	public bool isCrosshair1On;
	public bool isCrosshair2On;


	public bool isCrossHairOn;

	void Start(){
		isCrossHairOn = true;


		isCrosshair1On = true;
		isCrosshair2On = false;
	}

	void OnGUI()
	{
		var w = crosshair.width / 3;
		var h = crosshair.height / 3;

		Rect position = new Rect((Screen.width /2 - w/2), (Screen.height/2 - h/2), w,h); 

		if (isCrossHairOn == true && isCrosshair1On == true) {
			GUI.DrawTexture (position, crosshair);
		}
		else if(isCrossHairOn == true && isCrosshair2On == true){
			GUI.DrawTexture (position, crosshair2);
		}

	}

	void Update(){

	}
}
