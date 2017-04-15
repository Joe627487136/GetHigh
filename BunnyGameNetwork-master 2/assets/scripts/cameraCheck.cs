using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityStandardAssets.Cameras
{

	public class cameraCheck : NetworkBehaviour {

		// Use this for initialization
		void Start () {
			if (isLocalPlayer) {
//				GetComponentInChildren<AutoCam>().enabled = true;
				print ("true");
			}
			print ("false");
		}



	}
}
