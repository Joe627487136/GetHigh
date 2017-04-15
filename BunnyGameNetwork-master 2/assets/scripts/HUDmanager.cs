using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour {

	// Use this for initialization
	public Text life_count;

	private int count;
	private respawn resc;

	void Start () {
		GameObject thePlayer = GameObject.Find("Player1");
		resc = thePlayer.GetComponent<respawn>();
		count = resc.lifecount;
		life_count.text = "Life x" + count;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject thePlayer = GameObject.Find("Player1");
		resc = thePlayer.GetComponent<respawn>();
		count = resc.lifecount;
		life_count.text = "Life x" + count;
	}
}
