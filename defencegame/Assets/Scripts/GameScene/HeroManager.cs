using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour {

	//グローバル変数
	public float speed;

	//メンバ変数
	private Vector2 heroPos;
	private Animator animator;
	private bool isTouched = false;
	private bool didAttack = false;
	private float time = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update(){
		
		if (!isTouched) { //攻撃範囲に敵がいない
			time = 0;
			//ヒーローの移動
			heroPos = this.GetComponent<RectTransform> ().offsetMin;
			this.GetComponent<RectTransform> ().offsetMin = new Vector2 (heroPos.x + speed, heroPos.y);
			this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (70, 70);
			animator.speed = 1; //歩きアニメーション開始
		} else { //攻撃範囲に敵がいる
			animator.speed = 0; //歩きアニメーション停止

			if (!didAttack) {
				Attack01 (); //攻撃
				didAttack = true;
			}

			time += Time.deltaTime; //timer開始

			if (time >= 1.2) {
				didAttack = false;
				time = 0;
			}
		}
	}


	void OnTriggerEnter2D (Collider2D other){
		isTouched = true;
	}

	void OnTriggerExit2D(Collider2D other){
		isTouched = false;
	}

	void Attack01(){
		iTween.MoveBy (gameObject, iTween.Hash("x",0.7,"isLocal",true,"oncomplete","Attack02","oncompletetarget",gameObject,"time",0.05f));
	}

	void Attack02(){
		iTween.MoveBy (gameObject, iTween.Hash ("x", -0.7,"isLocal",true,"time",0.05f));
	}

}
