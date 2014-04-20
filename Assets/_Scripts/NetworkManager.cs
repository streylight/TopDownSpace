//using UnityEngine;
//using System.Collections;

//public class NetworkManager : Photon.MonoBehaviour {
	
//    static public string userName;
//    static public bool connecting = false;
//    static public bool connected = false;
	
//    // Use this for initialization
//    void Start () {
//        connecting = false;
//        connected = false;
//        userName = PlayerPrefs.GetString("userName", "RedShirt");
//    }

//    void OnDestroy() {
//        PlayerPrefs.SetString("userName", userName);
//    }
	
//    void OnGUI() {
//        if(!connecting) {
//            GUILayout.BeginArea( new Rect(Screen.width/2 - 100, 0, 200, Screen.height) );
//            GUILayout.BeginVertical();
//            GUILayout.FlexibleSpace();
			
//            GUILayout.Label("Your Name: ");
//            userName = GUILayout.TextField(userName, 24);
			
//            GUILayout.Space(20);
//            if(userName.Length > 0 && GUILayout.Button("Multi-Player")) {
//                connecting = true;
//                PhotonNetwork.ConnectUsingSettings("alpha 0.1");
//            }
			
//            GUILayout.Space(20);
//            if(userName.Length > 0 && GUILayout.Button("Single-Player")) {
//                connecting = true;
//                PhotonNetwork.offlineMode = true; 
//                PhotonNetwork.CreateRoom(null);

//            }
			
//            GUILayout.FlexibleSpace();
//            GUILayout.EndVertical();
//            GUILayout.EndArea();
//        }
//        else if(!connected) {
//            GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
//        }
//    }

//    void OnJoinedLobby() {
//        PhotonNetwork.JoinRandomRoom();
//    }
	
//    void OnPhotonRandomJoinFailed() {
//        PhotonNetwork.CreateRoom(null);
//    }
	
//    void OnJoinedRoom() {
//        connected = true;
//        SpawnPlayer();
//        //SpawnEnemy();
//    }
	
//    void SpawnPlayer() {
//        GameObject myShip = PhotonNetwork.Instantiate("SpaceCraft", Random.onUnitSphere * 2f, Quaternion.identity, 0);
//    //    myShip.GetComponent<Targetable>().enabled=false;	// We can't target ourselves.
//    //    Camera.main.GetComponent<CameraScript>().target = myShip.transform;
//    //    GameObject.Find("GUI").GetComponent<NavConsole>().shipMovement = myShip.GetComponent<ShipMovement>();
//    //    GameObject.Find("GUI").GetComponent<TacConsole>().SetupWeaponMounts(myShip.transform);
//    //    myShip.AddComponent<NavMouse>();
//    }
	
//    //void SpawnEnemy() {
//    //    PhotonNetwork.Instantiate( "Enemy1", Vector3.forward * 10f, Quaternion.identity, 0 );
//    //}
//}
