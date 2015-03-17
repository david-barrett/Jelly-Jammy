using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public GameObject bucket;
	public GameObject avoid;
	public GUIText scoreText;
	public GUIText livesText;
	
	float spawnTimer;
	float starSpawnTimer;
	private GameObject bucketObj;
	// Use this for initialization
	void Start () {
		spawnTimer = 1.0f;
		starSpawnTimer = 0.0f;

		PlayerPrefs.SetInt("CurrentScore", 0);
		scoreText.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();

		PlayerPrefs.SetInt("Lives", 3);
		livesText.text = PlayerPrefs.GetInt("Lives", 0).ToString();

		PlayerPrefs.SetFloat("ReverseTimer", 0);

		bucketObj = (GameObject)Instantiate(bucket, 
		                                              new Vector3(0f,-2.8f,-2.0f), 
		                                              transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
				spawnTimer -= Time.deltaTime;
				if (spawnTimer <= 0.0f) {
						GameObject instance = (GameObject)Instantiate (enemy, 
			                                              new Vector3 (Random.Range (-4.0f, 4.0f), 5f, -2.0f), 
			                                              transform.rotation);
						spawnTimer = 1.0f;
				}
		scoreText.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
		livesText.text = PlayerPrefs.GetInt("Lives", 0).ToString();
		//livesText.text = PlayerPrefs.GetFloat ("ReverseTimer", 0).ToString ();
		var reverseTimer = PlayerPrefs.GetFloat("ReverseTimer", 0);
		if (reverseTimer > 0) {
						reverseTimer -= Time.deltaTime;
			PlayerPrefs.SetFloat("ReverseTimer", reverseTimer);

				}

		if (PlayerPrefs.GetInt ("CurrentScore", 0) > 100) {
			starSpawnTimer -= Time.deltaTime;
			if (starSpawnTimer <= 0.0f)
			{
				GameObject instance = (GameObject)Instantiate (avoid, 
				                                               new Vector3 (Random.Range (-4.0f, 4.0f), 5f, -2.0f), 
				                                               transform.rotation);
				starSpawnTimer = 2.5f;
			}
				}
	}
	void FixedUpdate()
	{

				var moveHorizontal = Input.GetAxis ("Horizontal");
				if ((moveHorizontal > 0 && bucketObj.transform.position.x > -9) || (moveHorizontal < 0 && bucketObj.transform.position.x < 10)) {
			var reverseTimer = PlayerPrefs.GetFloat("ReverseTimer", 0);
			if (reverseTimer > 0)
			{
				moveHorizontal *= -1;
			}
			moveHorizontal = moveHorizontal / 2;
						bucketObj.transform.position -= new Vector3 (moveHorizontal, 0, 0);				
				}
		}
	/*
		if (Input.GetButton("Left"))
		{
			bucketObj.transform.position = new Vector3(-5 * Time.deltaTime, 0,0);
		}
		if (Input.GetButton("Right"))
		{
			bucketObj.transform.position = new Vector3(5 * Time.deltaTime, 0,0);
		}*/

}
