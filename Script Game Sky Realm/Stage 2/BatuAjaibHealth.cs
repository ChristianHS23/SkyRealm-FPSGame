using UnityEngine;
using System.Collections;

public class BatuAjaibHealth : MonoBehaviour {


	// Health related
	public int health=5000 ;
	public float maxHealth = 5000;

	//healthBar related
	public GameObject healthBar;


	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			player.GetComponent<PlayerHealth> ().hp = 0;
		}
	}

	void TakeDamage(int dmg)
	{
		
		health = health - dmg;
		float healthBarHealth = health/maxHealth;
		manageHealthBar (healthBarHealth);


		//print (healthBarHealth);
	}
	public void manageHealthBar(float myHealthBar)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealthBar,0f,1f), healthBar.transform.localScale.y ,healthBar.transform.localScale.z);
	}
	void OnTriggerEnter(Collider other)
	{
		//take damage from Bullet
		//Debug.Log (other.gameObject.name);
	
		if (other.gameObject.CompareTag ("Tornado")) {
			TakeDamage (100);
			Destroy (other.gameObject);
		}
	}
}
