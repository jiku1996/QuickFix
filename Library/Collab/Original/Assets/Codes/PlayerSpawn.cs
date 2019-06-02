using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	[SerializeField]
	GameObject[] Characters;

	[SerializeField]
	GameObject[] PlayerSpawners;

	// Use this for initialization
	void Start () {

        //for (int i = 0; i < 4; i++) {
        //PlayerSpawners[i] = Instantiate (Characters[i], PlayerSpawners[i].transform.position, PlayerSpawners[i].transform.rotation);
        //}

        for(int i = 0; i < PlayerSpawners.Length; i++)
        {
            PlayerSpawners[i] = Instantiate(Characters[i], PlayerSpawners[i].transform.position, PlayerSpawners[i].transform.rotation);
        }

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
