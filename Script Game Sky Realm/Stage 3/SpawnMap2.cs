using UnityEngine;
using System.Collections;

public class SpawnMap2 : MonoBehaviour {

	// Use this for initialization
	//for enemy type
	public GameObject Bat;
	public GameObject Cactus;
	public GameObject ER;
	public GameObject DragonBoss;

	public GameObject spawnEffect;
	public GameObject spawnEffect2;
	public GameObject spawnEffect3;
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
	public Transform spawnPoint21;
	//connect to stage script
	public GameObject stage2Manager;



	//flag for solo spawned enemy
	bool isSpawned = false;
	bool isDragonSpawned;


	private int counter;
	private int counter2;
	private int counter3;
	private int counter4;

	float timer=0;
	// Use this for initialization
	void Start () {
		stage2Manager  = GameObject.FindGameObjectWithTag("Stage2Manager");
		counter = 0;
		counter2 = 0;
		counter3 = 0;
		counter4 = 0;
		isSpawned = false;
		isDragonSpawned = false;
	}

	// Update is called once per frame
	void Update () {
		if (stage2Manager.GetComponent<Stage2Manager> ().wave1Clear == false) {
			SpawnWave1 ();
		}
		if (stage2Manager.GetComponent<Stage2Manager> ().wave2Clear == false && stage2Manager.GetComponent<Stage2Manager> ().wave2Trigger == true) {
			SpawnWave2 ();
		}
		if (stage2Manager.GetComponent<Stage2Manager> ().wave3Trigger == true && stage2Manager.GetComponent<Stage2Manager> ().wave3Clear == false) {
			SpawnWave3 ();
		}
		if (stage2Manager.GetComponent<Stage2Manager> ().isDragonBossSpawned == true) {
			SpawnDragonBoss ();
		}
			

	}

	void SpawnWave1()
	{

		timer += Time.deltaTime;
		if (timer >5 && counter <=1) {
			timer = 0;
			Instantiate (spawnEffect, spawnPoint1.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint1.position, spawnPoint1.rotation);

			Instantiate (spawnEffect2, spawnPoint2.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint2.position, spawnPoint2.rotation);

			Instantiate (spawnEffect, spawnPoint3.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint3.position, spawnPoint3.rotation);

			Instantiate (spawnEffect2, spawnPoint4.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint4.position, spawnPoint4.rotation);

			Instantiate (spawnEffect2, spawnPoint5.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint5.position, spawnPoint5.rotation);

			Instantiate (spawnEffect, spawnPoint6.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint6.position, spawnPoint6.rotation);

			Instantiate (spawnEffect2, spawnPoint7.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint7.position, spawnPoint7.rotation);
			counter++;

		}
	}
	void SpawnWave2(){
		timer += Time.deltaTime;
		if (timer > 3 && counter2 <= 1) {
			timer = 0;

			Instantiate (spawnEffect, spawnPoint8.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint8.position, spawnPoint8.rotation);

			Instantiate (spawnEffect, spawnPoint9.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint9.position, spawnPoint9.rotation);

			Instantiate (spawnEffect2, spawnPoint10.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint10.position, spawnPoint10.rotation);

			Instantiate (spawnEffect2, spawnPoint11.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint11.position, spawnPoint11.rotation);
			counter2++;
		}
		if (timer > 5 && counter3 < 1) {
			timer = 0;

			Instantiate (spawnEffect, spawnPoint12.position, Quaternion.Euler(-90,0,0));
			Instantiate (ER, spawnPoint12.position, spawnPoint12.rotation);

			Instantiate (spawnEffect, spawnPoint13.position, Quaternion.Euler(-90,0,0));
			Instantiate (ER, spawnPoint13.position, spawnPoint13.rotation);
			counter3++;
		}
	}
	void SpawnWave3()
	{

		timer += Time.deltaTime;
		if (timer >5 && counter4 <=1) {
			timer = 0;
			Instantiate (spawnEffect, spawnPoint1.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint14.position, spawnPoint14.rotation);

			Instantiate (spawnEffect2, spawnPoint15.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint15.position, spawnPoint15.rotation);

			Instantiate (spawnEffect, spawnPoint16.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint16.position, spawnPoint16.rotation);

			Instantiate (spawnEffect2, spawnPoint17.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint17.position, spawnPoint17.rotation);

			Instantiate (spawnEffect2, spawnPoint18.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint18.position, spawnPoint18.rotation);

			Instantiate (spawnEffect, spawnPoint19.position, Quaternion.Euler(-90,0,0));
			Instantiate (Bat, spawnPoint19.position, spawnPoint19.rotation);

			Instantiate (spawnEffect2, spawnPoint20.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint20.position, spawnPoint20.rotation);

			Instantiate (spawnEffect2, spawnPoint21.position, Quaternion.Euler(-90,0,0));
			Instantiate (Cactus, spawnPoint21.position, spawnPoint21.rotation);
			counter4++;

		}
	}

	void SpawnDragonBoss()
	{
		if (isDragonSpawned == false) {
			DragonBoss.SetActive (true);
			stage2Manager.GetComponent<Stage2Manager> ().bgMusic.enabled = false;
			stage2Manager.GetComponent<Stage2Manager> ().bossMusic.enabled = true;
			isDragonSpawned = true;
		}
		
	}

}
