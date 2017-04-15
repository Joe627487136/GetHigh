using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class respawn : NetworkBehaviour  {

	public Canvas mCanvas;
	public Text life_count;
	private Vector3 startPos;
	private Vector3 TelePos;
	private respawn anotherrp;
	private Quaternion startRot;
	public int lifecount = 0;

	// Use this for initialization
	void Start () 
	{
		if (isLocalPlayer) {
			life_count = GameObject.FindGameObjectWithTag ("LifeCount").GetComponent<Text> ();
		}
		startPos = transform.position;
		startRot = transform.rotation;
	}

	//detect collision with trigger//
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "death")
		{
			lifecount++;
			transform.position = startPos;
			transform.rotation = startRot;
			GetComponent<Animator>().Play("LOSE00",-1,0f);
			GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
		}
		else if(col.tag == "checkpoint")
		{
			startPos = col.transform.position;
			startRot = col.transform.rotation;
		}
		else if(col.tag == "Teleport")
		{
			TelePos = new Vector3 (-44, 2, 15);
			transform.position = TelePos;
		}
		else if(col.tag == "goal")
		{
			StartCoroutine (Final ());
		}
	}
	void Update(){
		if (isLocalPlayer) {
			life_count.text = "Death x" + lifecount;
		}
	}

	IEnumerator Final(){
		GetComponent<Animator>().Play("WIN00",-1,0f);
		yield return new WaitForSeconds (2);

		if (isLocalPlayer) {
			SceneManager.LoadScene ("YouWin");
		}
		if (isClient&&!isServer) {
			Cmddisplaywow ();
			CmdCtoSisWon ();
			print (1);
			SceneManager.LoadScene ("YouWin");
		}
		if (isServer) {
			Rpcdisplaywow();
			RpcStoCisWon ();
			print (2);
			SceneManager.LoadScene ("YouWin");
		}
	}
	IEnumerator StartStCCall(){
		yield return new WaitForSeconds(2);
		RpcStoCisWon ();
	}

	IEnumerator StartCtSCall(){
		yield return new WaitForSeconds (2);
		CmdCtoSisWon ();
	}

	[Command]
	void CmdCtoSisWon () {
		SceneManager.LoadScene ("YouLose");
	}
	void Cmddisplaywow () {
		print("Wow");
	}

	[ClientRpc]
	void RpcStoCisWon () {
		if (isServer) {
			return;
		}
		SceneManager.LoadScene ("YouLose");
	}
	void Rpcdisplaywow () {
		print("Wew");
	}
}
