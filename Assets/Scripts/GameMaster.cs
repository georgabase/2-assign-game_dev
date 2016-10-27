using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public Texture2D scoreIconTexture;
	public Texture2D lIconTexture;
	public int score;

	void OnGUI()
	{
		DisplayScoreCount();
		DisplayLCount ();
		DisplayRestartButton();
		}

	void DisplayLCount()
	{
		Rect coinIconRect = new Rect(10, 10, 32, 32);
		GUI.DrawTexture(coinIconRect, lIconTexture);                         

		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;

		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		var playerScript = GameObject.FindWithTag ("Player").GetComponent<PlayerHealth> ();
		GUI.Label(labelRect, playerScript.playerStats.Health.ToString(), style);
	}

	void DisplayScoreCount()
	{
		Rect coinIconRect = new Rect(10, 50, 32, 32);
		GUI.DrawTexture(coinIconRect, scoreIconTexture);                         

		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;

		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, score.ToString(), style);
	}

	void DisplayRestartButton()
	{
		var playerScript = GameObject.FindWithTag ("Player").GetComponent<PlatformerCharacter2D> ();
		if (playerScript.finish)
		{
			Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);
			if (GUI.Button(buttonRect, "YOU WON! Click to restart!"))
			{
				Application.LoadLevel (Application.loadedLevelName);
			};
		}
	}

	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public float spawnDelay = 2;
	public Transform spawnPrefab;

	public IEnumerator RespawnPlayer () {
		//audio.Play ();
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
		Destroy (clone, 3f);
	}

	public static void KillPlayer (PlayerHealth player) {
		Destroy (player.gameObject);
		gm.StartCoroutine (gm.RespawnPlayer());
	}

}