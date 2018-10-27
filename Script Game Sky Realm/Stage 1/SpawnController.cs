using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	//for enemy type
	public GameObject enemyMelee;
	public GameObject enemyRange;

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
	//connect to stage script
	public GameObject stage1Manager;




	//flag for solo spawned enemy
	bool isSpawned = false;
	private int counter2;
	private int counter;
	private int counter3;
	private int counter4;

	float timer=0;
	// Use this for initialization
	void Start () {
		stage1Manager  = GameObject.FindGameObjectWithTag("Stage1Manager");

		counter = 0;
		counter2 = 0;
		counter3 = 0;
		counter4 = 0;
		isSpawned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (stage1Manager.GetComponent<Stage1Manager> ().wave1Clear == false && stage1Manager.GetComponent<Stage1Manager> ().wave2Clear == false) {
			SpawnWave1 ();
		}
		if (stage1Manager.GetComponent<Stage1Manager> ().wave1Clear == true && stage1Manager.GetComponent<Stage1Manager> ().wave2Trigger == true && stage1Manager.GetComponent<Stage1Manager> ().wave2Clear == false) 
		{
			SpawnWave2 ();
		}
		if (stage1Manager.GetComponent<Stage1Manager> ().wave2Clear == true && stage1Manager.GetComponent<Stage1Manager> ().wave3Trigger == true && stage1Manager.GetComponent<Stage1Manager> ().wave3Clear == false) {
			SpawnWave3 ();
		}
		if(stage1Manager.GetComponent<Stage1Manager>().wave3Clear==true && stage1Manager.GetComponent<Stage1Manager>().wave4Trigger==true && stage1Manager.GetComponent<Stage1Manager>().wave4Clear==false){
			SpawnWave4();
		}
	}

	void SpawnWave1()
	{
		//Spawn Enemy Range
		timer += Time.deltaTime;
		if (timer > 5 && counter <=3) {
			timer = 0;
			Instantiate (spawnEffect, spawnPoint1.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint1.position, spawnPoint1.rotation);

			Instantiate (spawnEffect2, spawnPoint2.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint2.position, spawnPoint2.rotation);

			Instantiate (spawnEffect, spawnPoint3.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint3.position, spawnPoint3.rotation);

			counter++;

		}
	}

	void SpawnWave2()
	{
			timer += Time.deltaTime;
		if (isSpawned == false) {
			
			Instantiate (spawnEffect, spawnPoint4.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint4.position, spawnPoint4.rotation);

			Instantiate (spawnEffect, spawnPoint5.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint5.position, spawnPoint5.rotation);
			isSpawned = true;
		}

			if (timer > 5 && counter2 <=3) {
				timer = 0;
				Instantiate (spawnEffect, spawnPoint6.position, Quaternion.Euler(-90,0,0));
				Instantiate (enemyRange, spawnPoint6.position, spawnPoint6.rotation);

				Instantiate (spawnEffect2, spawnPoint7.position, Quaternion.Euler(-90,0,0));
				Instantiate (enemyMelee, spawnPoint7.position, spawnPoint7.rotation);
				
				counter2++;

			}
	}
	void SpawnWave3(){
		timer += Time.deltaTime;
		if (timer > 10 && counter3 <= 1) {
			timer = 0;
			Instantiate (spawnEffect, spawnPoint8.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint8.position, spawnPoint8.rotation);

			Instantiate (spawnEffect, spawnPoint9.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint9.position, spawnPoint9.rotation);

			Instantiate (spawnEffect2, spawnPoint10.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint10.position, spawnPoint10.rotation);

			Instantiate (spawnEffect2, spawnPoint11.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint11.position, spawnPoint11.rotation);

			Instantiate (spawnEffect2, spawnPoint12.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint12.position, spawnPoint12.rotation);
			counter3++;
		}
	}
	void SpawnWave4(){
		timer += Time.deltaTime;
		if (timer > 5 && counter4 <= 2) {
			timer = 0;
			Instantiate (spawnEffect2, spawnPoint13.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint13.position, spawnPoint13.rotation);

			Instantiate (spawnEffect2, spawnPoint14.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint14.position, spawnPoint14.rotation);

			Instantiate (spawnEffect2, spawnPoint15.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyMelee, spawnPoint15.position, spawnPoint15.rotation);

			Instantiate (spawnEffect, spawnPoint16.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint16.position, spawnPoint16.rotation);

			Instantiate (spawnEffect, spawnPoint17.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint17.position, spawnPoint17.rotation);

			Instantiate (spawnEffect, spawnPoint18.position, Quaternion.Euler(-90,0,0));
			Instantiate (enemyRange, spawnPoint18.position, spawnPoint18.rotation);
			counter4++;
		}
	}
}
