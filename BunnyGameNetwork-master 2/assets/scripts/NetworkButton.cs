using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class NetworkButton : MonoBehaviour {

	public GameObject main;
	public GameObject slct;
	public GameObject staffinfo;
	public AudioSource buttonSound;
	public AudioClip audioClip;

	bool loadSceneInitiated = false;

	void Awake(){
	
	}

	// Use this for initialization
	void Start () {
		main.SetActive (true);
		slct.SetActive (false);
		staffinfo.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NetworkGame(){
		StartCoroutine (selectbutton ());
	}

	public void Staffbtn(){
		StartCoroutine (staffbutton());
	}

	public void mainbackbtn(){
		StartCoroutine (backbutton());
	}

	public void LevelOne(){
		
		StartCoroutine (LoadLevelOne());


	}

	public void LevelTwo(){
		StartCoroutine (LoadLevelTwo());
	
	}

	public void LevelThree(){
		StartCoroutine (LoadLevelThree());
	}

	public void LoadMainMenu(){
		StartCoroutine (LoadMainmenu());
	}
	public void LoadRealMenu(){
		StartCoroutine (Loadthatmenu());
	}
	IEnumerator Loadthatmenu(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);
		SceneManager.LoadScene("MainMenu2");
		Destroy(GameObject.FindGameObjectWithTag("Lobby"));
	}
	IEnumerator LoadMainmenu(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length); 
		NetworkLobbyManager.singleton.StopClient ();
		NetworkLobbyManager.singleton.StopServer ();
		NetworkLobbyManager.singleton.StopHost ();
		NetworkServer.DisconnectAll ();
		Destroy(GameObject.FindGameObjectWithTag("Lobby"));
	}

	IEnumerator LoadLevelOne(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);    

		SceneManager.LoadScene ("Lobby1");
	}

	IEnumerator LoadLevelTwo(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);    

		SceneManager.LoadScene ("Lobby2");
	}

	IEnumerator LoadLevelThree(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);    

		SceneManager.LoadScene ("Lobby3");
	}
	IEnumerator selectbutton(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);    

		main.SetActive (false);
		slct.SetActive (true);
		staffinfo.SetActive (false);
	}
	IEnumerator staffbutton(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);    

		main.SetActive (false);
		slct.SetActive (false);
		staffinfo.SetActive (true);
	}
	IEnumerator backbutton(){
		buttonSound.clip = audioClip;
		buttonSound.Play();

		yield return new WaitForSeconds (audioClip.length);    

		main.SetActive (true);
		slct.SetActive (false);
		staffinfo.SetActive (false);
	}
}
