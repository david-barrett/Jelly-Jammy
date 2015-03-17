using UnityEngine;
using System.Collections;

public class starfishController : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
		
		if (this.transform.position.y < -3) {
			Destroy(this.gameObject);
		}
	

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			Destroy(this.gameObject);
			PlayerPrefs.SetFloat("ReverseTimer", 5f);
		}
	}
}
