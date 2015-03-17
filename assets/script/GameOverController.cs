using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	float gameOverTimer;
	public GUIText scoreText;
	// Use this for initialization
	void Start () {
		gameOverTimer = 2.0f;
		scoreText.text = "Your Score:" + PlayerPrefs.GetInt("CurrentScore");
	}
	
	// Update is called once per frame
	void Update () {
		gameOverTimer -= Time.deltaTime;
		if(gameOverTimer <= 0.0f)
			Application.LoadLevel(0);
		
	}
}
