using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider2D> ().isTrigger = true;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * 10);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.tag) 
		{
		case "Player":
			if (this.name == "EnemyBullet") {
				other.SendMessage ("Damage", Random.Range(5, 21), SendMessageOptions.DontRequireReceiver);
				Destroy (gameObject);
			}

			break;
		case "Enemy":
			if (this.name == "PlayerBullet") {
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
			break;
		case "Wall":
			Destroy (gameObject);
			break;
		default:
			if (this.name != other.name)
				Destroy (gameObject);
			break;

		}
	}
}
