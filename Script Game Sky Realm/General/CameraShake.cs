using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public float ShakePower = 2f;
	public float shake = 0;
	public bool shakeStat = false;

	Vector3 originPosition;

	void Start()
	{
		originPosition = transform.localPosition;
	}

	void LateUpdate()
	{
		if(shakeStat == true)
		{
			shake = ShakePower;
			shakeStat = false;
		}

		Camera.main.transform.localPosition = originPosition + (Random.insideUnitSphere * shake);

		shake = Mathf.MoveTowards(shake, 0, Time.deltaTime * ShakePower);

		if(shake == 0)
		{
			Camera.main.transform.localPosition = originPosition;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "shake")
		{
			shake = ShakePower;
		}
	}
}