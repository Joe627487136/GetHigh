using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace UnityStandardAssets.Characters.ThirdPerson{


public class localCheck : NetworkBehaviour {

	// Use this for initialization
	void Start () {

			
			if (isLocalPlayer) {

				GetComponentInChildren<ThirdPersonCharacter> ().enabled = true;
				GetComponentInChildren<ThirdPersonUserControl> ().enabled = true;
			}
			print ("False");
		}
	
	}
}