using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	public Text scoreText;
	public float timeScaleInterval = 10000f;
    public GameObject PausePanel;
    public Button StartButton;
    public Text placarMandioca;

    private float timeElapsed = 0f;
	private float bestTime = 0f;
	private bool blink;
	private bool gameStarted;
	private TimeManager timeManager;
	private GameObject player;
	private GameObject floor;
	private Spawner spawner;
	private bool beatBestTime;
    private MandiocaManager mandiocaManager;
    

    private float currentTime = 1f;
	private float timeScaleIntervalCount = 0f;


	void Awake(){
		floor = GameObject.Find("Foreground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		timeManager = GetComponent<TimeManager> ();
        PausePanel.SetActive (true);
      
    }

	// Use this for initialization
	void Start () {
		var floorHeight = floor.transform.localScale.y;

		var pos = floor.transform.position;
		pos.x = 0;
		pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		spawner.active = false;

		Time.timeScale = 0;
	

		bestTime = PlayerPrefs.GetFloat("BestTime");

        mandiocaManager = GameObject.Find("MandiocaManager").GetComponent<MandiocaManager>();

    }

	public void MuteGameButton(){

		if (AudioListener.pause) {
			AudioListener.pause = false;
			GameObject.Find ("Button Mute").GetComponent<Button> ().image.overrideSprite = null;
		} else {
			AudioListener.pause = true;
			Sprite btnOff = Resources.Load<Sprite> ("Sprites/BOTAO AUDIO OFF");
			GameObject.Find ("Button Mute").GetComponent<Button> ().image.overrideSprite = btnOff;
		}

	}

    public void ExitButton() {
        Application.Quit();
    }

    public void StartButtonPressed() {
            PausePanel.SetActive(false);
            currentTime = 1f;
            timeManager.ManipulateTime(1, 1f);
            ResetGame();
 
    }
    
    
    // Update is called once per frame
	void Update () {

		if (!gameStarted && Time.timeScale == 0) {
            PausePanel.SetActive(true);

		}

		if (!gameStarted) {

			var textColor = beatBestTime ? "#FF0":"#FFF";

			scoreText.text = "Score: " + FormatScore (timeElapsed) + "\n<color="+textColor+">RECORD: " + FormatScore (bestTime)+"</color>";

            placarMandioca.text = mandiocaManager.GetCountMandioca();                 

        } else {
			timeElapsed += Time.deltaTime;

			if(timeScaleIntervalCount > timeScaleInterval){
				timeScaleIntervalCount = 0f;
				currentTime+=0.25f;
				if(currentTime>3f){
					currentTime = 3f;
				}
				timeManager.ManipulateTime(currentTime,1f);

			}else{
				timeScaleIntervalCount += timeElapsed;
			}
			
			scoreText.text = "Score: " + FormatScore (timeElapsed);
		}


	}

	void OnPlayerKilled(){
		spawner.active = false;

		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		playerDestroyScript.DestroyCallback -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);
		gameStarted = false;
	

		if (timeElapsed > bestTime) {
			bestTime = timeElapsed;
			PlayerPrefs.SetFloat("BestTime", bestTime);
			beatBestTime = true;
		}
	}
	void ResetGame(){
		spawner.active = true;
	
		player = GameObjectUtil.Instantiate (playerPrefab, new Vector3 (0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2+100, -2));

		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		playerDestroyScript.DestroyCallback += OnPlayerKilled;

		gameStarted = true;

        mandiocaManager.CleanMandioca();
        placarMandioca.text = mandiocaManager.GetCountMandioca();

        timeElapsed = 0;
		beatBestTime = false;
	}

	string FormatScore(float value){
		return value.ToString("F1");
		//TimeSpan t = TimeSpan.FromSeconds (value);
		//return string.Format ("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}
}
