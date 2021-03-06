﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PistolScript : MonoBehaviour {

	// Use this for initialization

	//animation
	private Animator myAnimator;
	public ParticleSystem flash;


	//sound
	public float shootVolume = 5f;
	public AudioClip[] shootSound;
	public AudioClip shootEnemySound;
	public AudioClip outOfAmmoSound;
	public AudioClip reloadSound;


	//fire rate
	private float lastShot;
	public float fireRate = 1f;

	//ammo related
	public int maxAmmo = 15;
	public int ammo;

	//flag related
	private bool isAllowedToShot;


	//UI Related
	public Text ammoUI;
	public Text maxAmmoUI;

	void Start () {
		ammo = 15;

		myAnimator = GetComponent<Animator> ();
		isAllowedToShot = true;


	}


	// Update is called once per frame
	void Update () {

		ammoUI.text = ammo.ToString ();
		maxAmmoUI.text = maxAmmo.ToString ();

		tryShooting ();
		Reload ();
	}

	void tryShooting()
	{

		RaycastHit hit;
		if (Input.GetMouseButton (0)  && Time.time >= lastShot + fireRate && isAllowedToShot == true) 
		{
			if (ammo > 0) {
				lastShot = Time.time;
				myAnimator.SetTrigger ("Shoot");
				flash.Play ();
				ammo--;
				//ammo--;
				if (Physics.Raycast (transform.parent.position, transform.forward, out hit, 100)) {
					//Debug.Log ("hit enemy");

					if (hit.collider.tag == "Enemy") {
						playShootingEnemySound ();
						hit.transform.SendMessage ("TakeDamage", 50);
					} else if (hit.collider.tag != "Enemy") {
						playShootingSound ();
					}
				} else {
					playShootingSound ();
					lastShot = Time.time;
					//Debug.Log ("hit other");
				}
			} 
			else 
			{
				lastShot = Time.time;
				myAnimator.SetTrigger ("Shoot");
				playOutOfAmmoSound ();
			}

		}

	}

	void playShootingSound()
	{
		if (shootSound.Length > 0) 
		{
			int index = Random.Range (0, shootSound.Length);
			AudioSource.PlayClipAtPoint (shootSound [index], transform.position, shootVolume);
		}
	}

	void playOutOfAmmoSound()
	{
		AudioSource.PlayClipAtPoint (outOfAmmoSound, transform.position, shootVolume);
	}

	void playShootingEnemySound()
	{
		AudioSource.PlayClipAtPoint (shootEnemySound, transform.position, shootVolume);
	}

	void playReloadSound()
	{
		AudioSource.PlayClipAtPoint (reloadSound, transform.position, shootVolume);
	}
	void Reload()
	{
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			if (ammo < 15) {
				myAnimator.SetTrigger ("Reload");
				isAllowedToShot = false; //cannot shoot while reloading

			}
		}

	}

	void RefillAmmo()
	{
		ammo = maxAmmo;
		isAllowedToShot = true;
	}
}
