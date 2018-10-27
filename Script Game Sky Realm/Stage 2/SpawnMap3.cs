using UnityEngine;
using System.Collections;

public class SpawnMap3 : MonoBehaviour {

	// Use this for initialization
	//for enemy type
	public GameObject Ghost;
	public GameObject Batu;
	public GameObject Boss;

	public AudioClip bossSpawn;
	private GameObject player;

	public GameObject spawnEffect;
	public GameObject spawnEffect2;
	//spawn point location
	public Transform spawnPoint1;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	public Transform spawnPoint4;
	public Transform spawnPoint5;
	public Transform spawnPoint6;
	public Transform spawnPoint7;
	public Transform spawnPoint8;
	public Transform spawnPoint9;
	public Transform spawnPoint10;
	public Transform spawnPoint11;
	public Transform spawnPoint12;
	public Transform spawnPoint13;
	public Transform spawnPoint14;
	public Transform spawnPoint15;
	public Transform spawnPoint16;
	public Transform spawnPoint17;
	public Transform spawnPoint18;
	public Transform spawnPoint19;
	public Transform spawnPoint20;
	public Transform spawnBoss;
	//connect to stage script
	public GameObject stage3Manager;

	public bool isWave0Spawned;
	public bool isWave1Spawned;
	public bool isWave2Spawned;
	public bool isWave3Spawned;
	public bool isWave4Spawned;




	//flag for solo spawned enemy
	bool isSpawned = false;
	private int counter2;
	private int counter;
	private int counter3;
	private int counter4;



	float timer=0;
	float bossTimer = 0;
	// Use this for initialization
	void Start () {
		stage3Manager  = GameObject.FindGameObjectWithTag("Stage3Manager");
		counter = 0;

		player = GameObject.FindGameObjectWithTag ("Player");

		isWave4Spawned = false;
		isWave3Spawned = false;
		isWave2Spawned = false;
		isWave1Spawned = false;
		isWave0Spawned = false;

		isSpawned = false;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.K)) {
			Instantiate (Boss, spawnBoss.position, spawnBoss.rotation);
		}
		/*if (stage3Manager.GetComponent<Stage3Manager> ().wave1Clear == false&& stage3Manager.GetComponent<Stage3Manager> ().wave1Trigger == true) {
			SpawnWave1 ();
		}*/
		if (stage3Manager.GetComponent<Stage3Manager> ().wave0Trigger == true && stage3Manager.GetComponent<Stage3Manager> ().rockGolemWave0Clear == false) {
			SpawnWave0 ();
		}
		if (stage3Manager.GetComponent<Stage3Manager> ().rockGolemWave1Clear == false && stage3Manager.GetComponent<Stage3Manager>().wave1Trigger==true ) {
			SpawnWave1 ();
		}

		if (stage3Manager.GetComponent<Stage3Manager> ().rockGolemWave1Clear == true) {
			SpawnWave2 ();
		}
		if (stage3Manager.GetComponent<Stage3Manager> ().rockGolemWave2Clear == true) {
			SpawnWave3 ();
		}
		if (stage3Manager.GetComponent<Stage3Manager> ().rockGolemWave3Clear == true) {
			SpawnBoss ();
		}
	}
	void SpawnWave0()
	{
		if (isWave0Spawned == false) {
			
				
			Instantiate (spawnEffect, spawnPoint15.position, Quaternion.Euler(-90,0,0));
				Instantiate (Ghost, spawnPoint15.position, spawnPoint15.rotation);

			Instantiate (spawnEffect, spawnPoint16.position, Quaternion.Euler(-90,0,0));
				Instantiate (Ghost, spawnPoint16.position, spawnPoint16.rotation);

			Instantiate (spawnEffect, spawnPoint17.position, Quaternion.Euler(-90,0,0));
				Instantiate (Ghost, spawnPoint17.position, spawnPoint17.rotation);

			Instantiate (spawnEffect, spawnPoint18.position, Quaternion.Euler(-90,0,0));
				Instantiate (Ghost, spawnPoint18.position, spawnPoint18.rotation);

			Instantiate (spawnEffect, spawnPoint19.position, Quaternion.Euler(-90,0,0));
				Instantiate (Ghost, spawnPoint19.position, spawnPoint19.rotation);

			Instantiate (spawnEffect, spawnPoint20.position, Quaternion.Euler(-90,0,0));
				Instantiate (Ghost, spawnPoint20.position, spawnPoint20.rotation);

		
			isWave0Spawned = true;

		}


	}
	void SpawnWave1()
	{
		if (isWave1Spawned == false) {
			Instantiate (spawnEffect, spawnPoint1.position,Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint1.position, spawnPoint1.rotation);

			Instantiate (spawnEffect, spawnPoint2.position, Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint2.position, spawnPoint2.rotation);

			Instantiate (spawnEffect, spawnPoint3.position, Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint3.position, spawnPoint3.rotation);

			Instantiate (spawnEffect, spawnPoint4.position, Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint4.position, spawnPoint4.rotation);

			Instantiate (spawnEffect, spawnPoint5.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint5.position, spawnPoint5.rotation);

			Instantiate (spawnEffect, spawnPoint6.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint6.position, spawnPoint6.rotation);

			Instantiate (spawnEffect, spawnPoint7.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint7.position, spawnPoint7.rotation);

			Instantiate (spawnEffect, spawnPoint8.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint8.position, spawnPoint8.rotation);

			Instantiate (spawnEffect, spawnPoint9.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint9.position, spawnPoint9.rotation);

			Instantiate (spawnEffect, spawnPoint10.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint10.position, spawnPoint10.rotation);

			Instantiate (spawnEffect, spawnPoint11.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint11.position, spawnPoint11.rotation);

			Instantiate (spawnEffect, spawnPoint12.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint12.position, spawnPoint12.rotation);

			Instantiate (spawnEffect, spawnPoint13.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint13.position, spawnPoint13.rotation);

			Instantiate (spawnEffect, spawnPoint14.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint14.position, spawnPoint14.rotation);

			isWave1Spawned = true;

		}
			

	}

	void SpawnWave2()
	{
		if (isWave2Spawned == false) {
			Instantiate (spawnEffect, spawnPoint1.position,Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint1.position, spawnPoint1.rotation);

			Instantiate (spawnEffect, spawnPoint2.position, Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint2.position, spawnPoint2.rotation);

			Instantiate (spawnEffect, spawnPoint3.position, Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint3.position, spawnPoint3.rotation);

			Instantiate (spawnEffect, spawnPoint4.position, Quaternion.Euler(-90,0,0));
			Instantiate (Batu, spawnPoint4.position, spawnPoint4.rotation);

			Instantiate (spawnEffect, spawnPoint5.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint5.position, spawnPoint5.rotation);

			Instantiate (spawnEffect, spawnPoint6.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint6.position, spawnPoint6.rotation);

			Instantiate (spawnEffect, spawnPoint7.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint7.position, spawnPoint7.rotation);

			Instantiate (spawnEffect, spawnPoint8.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint8.position, spawnPoint8.rotation);

			Instantiate (spawnEffect, spawnPoint9.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint9.position, spawnPoint9.rotation);

			Instantiate (spawnEffect, spawnPoint10.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint10.position, spawnPoint10.rotation);

			Instantiate (spawnEffect, spawnPoint11.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint11.position, spawnPoint11.rotation);

			Instantiate (spawnEffect, spawnPoint12.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint12.position, spawnPoint12.rotation);

			Instantiate (spawnEffect, spawnPoint13.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint13.position, spawnPoint13.rotation);

			Instantiate (spawnEffect, spawnPoint14.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint14.position, spawnPoint14.rotation);;
			isWave2Spawned = true;
		}
	}
	void SpawnWave3()
	{
		if (isWave3Spawned == false) {


			Instantiate (spawnEffect, spawnPoint5.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint5.position, spawnPoint5.rotation);

			Instantiate (spawnEffect, spawnPoint6.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint6.position, spawnPoint6.rotation);

			Instantiate (spawnEffect, spawnPoint7.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint7.position, spawnPoint7.rotation);

			Instantiate (spawnEffect, spawnPoint8.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint8.position, spawnPoint8.rotation);

			Instantiate (spawnEffect, spawnPoint9.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint9.position, spawnPoint9.rotation);

			Instantiate (spawnEffect, spawnPoint10.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint10.position, spawnPoint10.rotation);

			Instantiate (spawnEffect, spawnPoint11.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint11.position, spawnPoint11.rotation);

			Instantiate (spawnEffect, spawnPoint12.position, Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint12.position, spawnPoint12.rotation);

			Instantiate (spawnEffect, spawnPoint13.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint13.position, spawnPoint13.rotation);

			Instantiate (spawnEffect, spawnPoint14.position,Quaternion.Euler(-90,0,0));
			Instantiate (Ghost, spawnPoint14.position, spawnPoint14.rotation);
			isWave3Spawned = true;
		}
	}
	void SpawnBoss(){
		if (isWave4Spawned == false) {

			player.GetComponent<PlayerInteraction3> ().isBossSpawned = true;
			player.GetComponentInChildren<CameraShake> ().shakeStat = true;

			bossTimer += Time.deltaTime;

			if (bossTimer > 3) {
				stage3Manager.GetComponent<Stage3Manager> ().map3Music.enabled = false;
				stage3Manager.GetComponent<Stage3Manager> ().bossMusic.enabled = true;
				Instantiate (spawnEffect2, spawnBoss.position,Quaternion.Euler(-90,0,0));
				Instantiate (Boss, spawnBoss.position, spawnBoss.rotation);
				isWave4Spawned = true;
			}


		
		}
	}
}
