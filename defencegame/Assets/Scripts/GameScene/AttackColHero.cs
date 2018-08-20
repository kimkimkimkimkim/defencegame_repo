using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColHero : MonoBehaviour {

	//メンバ変数
	private GameObject imageHero;
	private GameObject heroManager;

	// Use this for initialization
	void Start () {
		imageHero = gameObject.transform.parent.gameObject;
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "EnemyDeffence") {
			imageHero.GetComponent<HeroManager>().isTouched = true;
		}
	}

}
