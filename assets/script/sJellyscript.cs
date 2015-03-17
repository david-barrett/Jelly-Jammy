using UnityEngine;
using System.Collections;

public class sJellyscript : MonoBehaviour {

	public GameObject explosion;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;

		if (this.transform.position.y < -3) {
			Destroy(this.gameObject);
			Instantiate(explosion, new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z), this.transform.rotation);
			int _tempLives = PlayerPrefs.GetInt("Lives");
			_tempLives--;
			PlayerPrefs.SetInt("Lives", _tempLives);
			if (_tempLives<=0)
			{
				//gameover;
				Application.LoadLevel(2);
			}
				}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			Destroy(this.gameObject);
			int _tempScore = PlayerPrefs.GetInt("CurrentScore");
			_tempScore += 10;
			PlayerPrefs.SetInt("CurrentScore", _tempScore);
		}
	}
}
