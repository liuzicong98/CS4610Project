using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

	private GameObject[] enemies;
	void Start () {
		enemies = Resources.LoadAll<GameObject> ("Enemies");
		InvokeRepeating ("CreateEnemies", 0, 1); 
	}

	void Update () {
		
	}

	//create method
	private void CreateEnemies(){
		int num = Random.Range (0, enemies.Length);
		GameObject enemy = Instantiate (enemies [num],
			                   new Vector3 (Random.Range (-5.3f, 5.3f), 6, 1),
			                   Quaternion.identity);
		enemy.AddComponent<EnemyAI> ();
		int speeds = Random.Range (3, 8);
		enemy.GetComponent<EnemyAI> ().speed = speeds;
		enemy.tag = "Enemy";

	}

}
