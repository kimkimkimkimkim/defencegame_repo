using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour {

	//グローバル変数
	public float speed;

	//メンバ変数
	private Vector2 heroPos;

	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		//ヒーローの移動
		heroPos = this.GetComponent<RectTransform> ().offsetMin;
		this.GetComponent<RectTransform> ().offsetMin = new Vector2 (heroPos.x + speed, heroPos.y);
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (70, 70);
	}
}
