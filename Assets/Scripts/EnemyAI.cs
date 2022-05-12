using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour {

	public int speed;
	private GameObject bulletPrefab;
	private Transform firePos;
	void Start () {
		bulletPrefab = Resources.Load("Bullet") as GameObject;
		firePos = transform.GetChild (0);
		InvokeRepeating ("Attack", 0, 1);
		GetComponent<BoxCollider2D> ().isTrigger = true;
		GetComponent<Rigidbody2D>().gravityScale = 0;
	}
	

	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime * speed);
	}

	private void Attack(){
		GameObject bullet = Instantiate (bulletPrefab, firePos.position, firePos.rotation);
		bullet.AddComponent<BulletControl> ();
		bullet.name = "EnemyBullet";
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Wall") {
			Destroy (gameObject);
		}
			else if (other.tag == "Player"){
				other.SendMessage("Damage", 30, SendMessageOptions.DontRequireReceiver);
				Destroy (gameObject);
		}
	}

}
