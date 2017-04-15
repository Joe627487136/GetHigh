using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
	Camera sceneCamera;
	// Use this for initialization
	public static int[] list = new int[] {1,2};
	public static int i = 0;

	void Start(){
		if (isLocalPlayer&&isServer) {
			this.gameObject.tag = "Player"+list[i];
			i++;
			if (i == 2) {
				i = 0;
			}
			print ("Index: "+i);
		}
		if (isLocalPlayer&&isClient) {
			this.gameObject.tag = "Player1";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
