using UnityEngine;
using System.Collections;

public class EnemyAttackRange : MonoBehaviour {

	// Use this for initialization
	Animator myAnimator;
	public GameObject bullet;
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

	public GameObject spawnFire;

	void Start () {
		myAnimator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = this.GetComponent<NavMeshAgent> ();
		raycastSpawn = gameObject.transform.GetChild(0).gameObject;

	}

	// Update is called once per frame
	void Update () {

		enemyDeathStatus = this.GetComponent<EnemyHealth> ().enemyDeathStatus;
		playerPos = new Vector3 (player.transform.position.x, this.transform.position.y, player.transform.position.z);
		playerPosHeight = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		distanceToPlayer = Vector3.Distance(player.transform.position, this.transform.position);
		//
		WalkingToPlayer ();

		if (flagToAttack == true && enemyDeathStatus == false) {
			myAnimator.SetTrigger ("Projectile Attack");
		}
		//
		//		myAnimator.SetTrigger ("Melee Attack");
		//		//print(distanceToPlayer);
			EnemyMovement ();
		//		//CastSpell ();
		//		//ProjectileAttack ();

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			myAnimator.SetTrigger ("Projectile Attack");
		}

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

	void SpawnBullet()
	{
		GameObject bullet2 = (GameObject)Instantiate (bullet, spawnFire.transform.position, transform.rotation);
		bullet2.GetComponent<Rigidbody>().AddForce (transform.forward * 50, ForceMode.Impulse);
	}

	void SpawnCastBullet()
	{
		GameObject castBullet2 = (GameObject)Instantiate (castBullet, player.transform.TransformPoint(0, 5f,0), transform.rotation);

	}

	void MeleeAttack()
	{
		RaycastHit hit;
		Debug.DrawRay(raycastSpawn.transform.position, transform.forward, Color.black);
		if (Physics.Raycast (raycastSpawn.transform.position , transform.forward, out hit, 3, 1 << 10)) {
			Debug.Log ("hit player");
			hit.transform.SendMessage ("TakeDamage", 20);
		} else {
			Debug.Log ("hit other");
		}

		Vector3 toOther = player.transform.position - transform.position;

		if (Vector3.Dot (toOther, transform.forward) > 0.1f) {
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
