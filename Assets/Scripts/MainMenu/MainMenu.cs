using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	[SerializeField] private Button startButton;
	
	// Use this for initialization
	void Start() {
		startButton.onClick.AddListener(RunGameScene);
	}

	void RunGameScene() {
		SceneManager.LoadScene("EmmaScene");
	}
}
