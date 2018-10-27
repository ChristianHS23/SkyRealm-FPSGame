using UnityEngine;
using System.Collections;

public class DragonBossAttack : MonoBehaviour {

	// Use this for initialization
	Animator myAnimator;
	public GameObject tornado;

	public GameObject castBullet;
	private GameObject player;
	Transform posPlayer;
	float distanceToPlayer;
	NavMeshAgent agent;
	private Vector3 playerPos;
	private Vector3 playerPosHeight;
	private bool enemyDeathStatus;
	private GameObject raycastSpawn;
	bool flagToAttack = false;

	public GameObject cubeBreath;

	public AudioClip punch;

	int numberAttack;

	float timer=0;

	float fireBreathTimer = 0;

	private bool fireBreathFlag = false;

	void Start () {
		myAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = this.GetComponent<NavMeshAgent> ();
		raycastSpawn = gameObject.transform.GetChild(0).gameObject;

	}

	// Update is called once per frame
	void Update () {

		//print (distanceToPlayer);
		enemyDeathStatus = this.GetComponent<DragonBossHealth> ().enemyDeathStatus;
		playerPos = new Vector3 (player.transform.position.x, this.transform.position.y, player.transform.position.z);
		playerPosHeight = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		distanceToPlayer = Vector3.Distance(player.transform.position, this.transform.position);
		//
		//WalkingToPlayer ();

		//print (fireBreathFlag);

		if (flagToAttack == true && enemyDeathStatus == false) {

		}

		EnemyMovement ();



		numberAttack = Random.Range (1, 3);

		//FireBreath ();	
		timer += Time.deltaTime;
		if (timer > 3  && enemyDeathStatus == false ) {
				if (distanceToPlayer < 10 && enemyDeathStatus == false && fireBreathFlag == false) {
				myAnimator.SetTrigger ("Bite Attack");
				timer = 0;
			} else if (distanceToPlayer > 10 && enemyDeathStatus == false && fireBreathFlag == false) {
				FireBreath ();
				fireBreathFlag = true;
			}

		}
		
	
		//
		//		myAnimator.SetTrigger ("Melee Attack");
		//		//print(distanceToPlayer);
		//EnemyMovement ();
		//		//CastSpell ();
		//		//ProjectileAttack ();

		if (Input.GetKeyDown (KeyCode.U)) 
		{
			print ("masuk fungsi breath");


			myAnimator.SetTrigger ("Fire Breath Attack");
			fireBreathFlag = true;

		}



		if (fireBreathFlag == true) {

			fireBreathTimer += Time.deltaTime;
		}

	

		if (fireBreathTimer >= 3) {
			print ("keluar fungsi breath");
			myAnimator.SetTrigger ("Fire Breath Attack");

			fireBreathTimer = 0;
			fireBreathFlag = false;
			timer = 0;
		}

		if (Input.GetKeyDown (KeyCode.I)) 
		{
			myAnimator.SetTrigger ("Bite Attack");
		}

	}

	void SpawnBreath(){

		cubeBreath.SetActive (true);
		//
	}

	void DestroyBreath(){
		cubeBreath.SetActive (false);
		cubeBreath.GetComponent<IceBreathScript> ().hitBarrier = false;
	}
	void FireBreath()
	{
		
		myAnimator.SetTrigger ("Fire Breath Attack");
	



	}
	void CastSpell()
	{
		//		if (Input.GetKeyDown (KeyCode.C)) 
		//		{
		//			myAnimator.SetTrigger ("Cast Spell");
		//		}
	}

	void ProjectileAttack()
	{

		myAnimator.SetTrigger ("Projectile Attack");


	}

	void SpawnTornado()
	{
		GameObject bullet2 = (GameObject)Instantiate (tornado, transform.position, Quaternion.identity);
		bullet2.GetComponent<Rigidbody>().AddForce (transform.forward * 10, ForceMode.Impulse);
	}

	void SpawnCastBullet()
	{
		GameObject castBullet2 = (GameObject)Instantiate (castBullet, player.transform.TransformPoint(0, 5f,0), transform.rotation);

	}

	void MeleeAttack()
	{

		/*print ("melee attack");
		RaycastHit hit;
		Debug.DrawRay(raycastSpawn.transform.position, transform.forward, Color.black);
		if (Physics.Raycast (transform.position , transform.forward, out hit, 3, 1 << 10)) {
			Debug.Log ("hit player");
			hit.transform.SendMessage ("TakeDamage", 20);
		} else {
			Debug.Log ("hit other");
		}
	*/

		Vector3 toOther = player.transform.position - transform.position;

	//	AudioSource.PlayClipAtPoint (punch, transform.position, 10f);

		player.GetComponentInChildren<CameraShake> ().shakeStat = true;
		if (Vector3.Dot (toOther, transform.forward) > 0.1f && distanceToPlayer <10f) {
			Debug.Log ("hit player");
			player.transform.SendMessage ("TakeDamage", 20);
		} else {
			Debug.Log ("ga kena");
		}


	}

	void EnemyMovement()
	{


		if (distanceToPlayer > 4 && enemyDeathStatus == false)
			transform.LookAt (playerPosHeight);
		else if(enemyDeathStatus == false)
			transform.LookAt (playerPos);
	}

	void WalkingToPlayer()
	{

		if (distanceToPlayer > 30 && enemyDeathStatus == false && agent.enabled == true) {
			flagToAttack = false;
			myAnimator.SetTrigger ("Walk");
			agent.SetDestination (player.transform.position);
		} 
		else if(enemyDeathStatus == false  && agent.enabled == true ){
			flagToAttack = true;

			agent.SetDestination (transform.position);
			myAnimator.SetBool ("Walk", false);
		}

	}
}
