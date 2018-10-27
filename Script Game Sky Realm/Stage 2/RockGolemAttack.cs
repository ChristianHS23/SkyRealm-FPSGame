using UnityEngine;
using System.Collections;

public class RockGolemAttack : MonoBehaviour {

	// Use this for initialization
	Animator myAnimator;
	public GameObject tornado;

	public GameObject castBullet;
	private GameObject BatuAjaib;
	Transform posBatu;
	float distanceToBatu;
	NavMeshAgent agent;
	private Vector3 batuAjaibPos;
	private Vector3 playerPosHeight;
	private bool enemyDeathStatus;
	private GameObject raycastSpawn;
	bool flagToAttack = false;

	float timer=0;

	void Start () {
		myAnimator = GetComponent<Animator> ();
		BatuAjaib = GameObject.FindGameObjectWithTag ("batuAjaib");
		agent = this.GetComponent<NavMeshAgent> ();
		raycastSpawn = gameObject.transform.GetChild(0).gameObject;

	}

	// Update is called once per frame
	void Update () {

		enemyDeathStatus = this.GetComponent<RockGolemHealth> ().enemyDeathStatus;
		batuAjaibPos = new Vector3 (BatuAjaib.transform.position.x, this.transform.position.y, BatuAjaib.transform.position.z);
		playerPosHeight = new Vector3 (BatuAjaib.transform.position.x, BatuAjaib.transform.position.y, BatuAjaib.transform.position.z);
		distanceToBatu = Vector3.Distance(BatuAjaib.transform.position, this.transform.position);
		//
		//WalkingToPlayer ();

		if (flagToAttack == true && enemyDeathStatus == false) {
			
		}

		timer += Time.deltaTime;
		if (timer > 5  && enemyDeathStatus == false ) {
			timer = 0;
			myAnimator.SetTrigger ("Cast Spell");

		}
		//
		//		myAnimator.SetTrigger ("Melee Attack");
		//		//print(distanceToPlayer);
		EnemyMovement ();
		//		//CastSpell ();
		//		//ProjectileAttack ();

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			myAnimator.SetTrigger ("Cast Spell");
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

	void SpawnTornado()
	{
		GameObject bullet2 = (GameObject)Instantiate (tornado, transform.position, Quaternion.identity);
		bullet2.GetComponent<Rigidbody>().AddForce (transform.forward * 10, ForceMode.Impulse);
	}

	void SpawnCastBullet()
	{
		GameObject castBullet2 = (GameObject)Instantiate (castBullet, BatuAjaib.transform.TransformPoint(0, 5f,0), transform.rotation);

	}

	void MeleeAttack()
	{
		RaycastHit hit;
		Debug.DrawRay(raycastSpawn.transform.position, transform.forward, Color.black);
		if (Physics.Raycast (raycastSpawn.transform.position , transform.forward, out hit, 3, 1 << 10)) {
			Debug.Log ("hit player");
			hit.transform.SendMessage ("TakeDamage", 200);
		} else {
			Debug.Log ("hit other");
		}

		Vector3 toOther = BatuAjaib.transform.position - transform.position;

		if (Vector3.Dot (toOther, transform.forward) > 0.1f) {
			Debug.Log ("hit player");
			BatuAjaib.transform.SendMessage ("TakeDamage", 20);
		} else {
			Debug.Log ("ga kena");
		}

	}

	void EnemyMovement()
	{


		if (distanceToBatu > 4 && enemyDeathStatus == false)
			transform.LookAt (playerPosHeight);
		else if(enemyDeathStatus == false)
			transform.LookAt (batuAjaibPos);
	}

	void WalkingToPlayer()
	{

		if (distanceToBatu > 30 && enemyDeathStatus == false && agent.enabled == true) {
			flagToAttack = false;
			myAnimator.SetTrigger ("Walk");
			agent.SetDestination (BatuAjaib.transform.position);
		} 
		else if(enemyDeathStatus == false  && agent.enabled == true ){
			flagToAttack = true;

			agent.SetDestination (transform.position);
			myAnimator.SetBool ("Walk", false);
		}

	}
}
