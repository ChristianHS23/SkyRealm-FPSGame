﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


	// Health related
	public float health = 0;
	public float maxHealth = 100;

	//healthBar related
	public GameObject healthBar;

	//sound related
	public float soundVolume = 5f;
	public AudioClip deadEnemySound;

	//animation and navmesh
	private Animator myAnimator;
	public bool enemyDeathStatus = false;
	private GameObject player;
	NavMeshAgent agent;


	//item spawn related
	public GameObject healthPack;

	//communication with the manager
	public GameObject stage1Manager;

	void Start () {
		health = maxHealth;
		myAnimator = this.GetComponent<Animator> ();
		player = GameObject.FindWithTag ("Player");
		agent = this.GetComponent<NavMeshAgent> ();
		stage1Manager  = GameObject.FindGameObjectWithTag("Stage1Manager");
	}

	// Update is called once per frame
	void Update () {


		if (health <= 0&&enemyDeathStatus==false) {
			EnemyDeath ();
			agent.enabled = false;
			PlayDeathSound ();
			SpawnItem ();
			player.GetComponent<PlayerScore> ().score += 10;
			//stage1Manager.GetComponent<Stage1Manager> ().deathCount += 1;
			player.GetComponent<PlayerInteraction> ().S1EnemyKillCount += 1;//ini flag buat itung death count
			Destroy (gameObject, 2);
		}
	}


	void PlayDeathSound()
	{
		AudioSource.PlayClipAtPoint (deadEnemySound, transform.position, soundVolume);
	}

	void TakeDamage(int dmg)
	{
		
		health = health - dmg;
		float healthBarHealth = health/maxHealth;
		manageHealthBar (healthBarHealth);


	}

	void SpawnItem()
	{
		int spawnChance = Random.Range (1, 10);

		if (spawnChance <= 3) 
		{
			Instantiate (healthPack, transform.position, transform.rotation);
		}
	}


	public void manageHealthBar(float myHealthBar)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealthBar,0f,1f), healthBar.transform.localScale.y ,healthBar.transform.localScale.z);
	}

	void EnemyDeath()
	{

		//myAnimator.SetBool ("Projectile Attack", false);
		//myAnimator.SetBool ("Walk", false);

		myAnimator.SetTrigger("Die");
		enemyDeathStatus = true;


	}


}
