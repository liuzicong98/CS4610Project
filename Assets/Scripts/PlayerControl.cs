using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [RequireComponent(typeof(BoxCollider2D))]
public class PlayerControl : MonoBehaviour {
	private GameObject bg;
	private GameObject bulletPrefab;
	private Transform firePos;
	public AudioClip clips;
	public int hp;
	public int bulletNumber;
	public float angle;

	// Use this for initialization
	void Start () {
		bg = GameObject.Find ("BackGround");
		bulletPrefab = Resources.Load<GameObject>("Bullet");
		firePos = transform.GetChild (0);
		InvokeRepeating ("Attack", 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		bg.GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2 (0, Time.time / 5));
		if (Input.GetKeyDown (KeyCode.Space)) {
			RangeAttack ();
		}
	}

	void OnMouseDrag()
	{
		Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		targetPos.z = 1;
		targetPos.x = Mathf.Clamp(targetPos.x, -5.35f, 5.35f);
		targetPos.y = Mathf.Clamp (targetPos.y, -4.4f, 4.4f);
		transform.position = targetPos;
	}


	private void Attack()
	{
		GameObject tempBullet = Instantiate (bulletPrefab, firePos.position, firePos.rotation);
		tempBullet.AddComponent <BulletControl> ();
		tempBullet.name = "PlayerBullet";
		AudioSource.PlayClipAtPoint(clips, firePos.position, 0.5f);
	}

	//spcial attck
	private void RangeAttack()
	{
		for (int i = -bulletNumber / 2; i < bulletNumber / 2 + 1; i++) {
			GameObject tempBullet = Instantiate (bulletPrefab, firePos.position, firePos.rotation);
			tempBullet.transform.Rotate (0, 0, angle * i);
			tempBullet.AddComponent<BulletControl>();
			tempBullet.name = "PlayerBullet";
			AudioSource.PlayClipAtPoint(clips, firePos.position, 0.5f);
		}
			
	}

	private void Damage(int damage){
		if (hp > 0) {
			hp -= damage;
			if (hp <= 0) {
				hp = 0;
				UnityEditor.EditorApplication.isPlaying = false;
			} else {
				
			}
		}
	}
}
