using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageProcessing : MonoBehaviour {

	//オブジェクト参照
	public GameObject smokePrefab;
	public GameObject textVoD; //勝敗テキスト

	//メンバ変数
	private int playerHP;
	private int enemyHP;
	private GameObject playerCastle;
	private GameObject enemyCastle;
	private GameObject playerHPslider;
	private GameObject enemyHPslider;
	private GameObject containerButton;
	private bool isFinished = false;
	private float time = 0;

	void Start(){
		containerButton = GameObject.Find ("ContainerButton");
		playerCastle = GameObject.Find ("PlayerCastle");
		enemyCastle = GameObject.Find ("EnemyCastle");
		playerHPslider = playerCastle.transform.Find ("Slider").gameObject;
		enemyHPslider = enemyCastle.transform.Find ("Slider").gameObject;
		playerHP = (int)playerHPslider.GetComponent<Slider> ().maxValue;
		enemyHP = (int)enemyHPslider.GetComponent<Slider> ().maxValue;
	}

	void Update(){

		if (isFinished) {
			time += Time.deltaTime;
		}

		if (time >= 0.2) {
			GameObject smoke = (GameObject)Instantiate (smokePrefab);
			smoke.transform.SetParent (enemyCastle.transform, false);
			smoke.transform.localPosition = new Vector3 (
				-126.5f + Random.Range (-100.0f, 100.0f), 50.0f + Random.Range (-50.0f, 80.0f), 0);
			time = 0;
		}

	}

	//敵への攻撃
	public void AttackToEnemy(int damage){
		enemyHP -= damage;
		enemyHPslider.GetComponent<Slider> ().value = enemyHP;

		if (enemyHP <= 0) {
			PlayerWin ();
		}
	}

	void PlayerWin(){
		//煙を出す
		isFinished = true;

		//勝敗テキスト
		textVoD.SetActive(true);
		iTween.MoveTo(textVoD, iTween.Hash("x", 30,"isLocal",true));

		//ボタンコンテナをしまう
		iTween.MoveTo (containerButton, iTween.Hash("y",-50));
	}

}
