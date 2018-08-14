using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreMonButton : MonoBehaviour {

	//オブジェクト参照
	public GameObject heroPrefab;

	//メンバ変数
	private GameObject imageGrass;

	void Start(){
		imageGrass = GameObject.Find ("ImageGrass");
	}

	public void OnClick(){
		GameObject hero = (GameObject)Instantiate (heroPrefab);
		hero.transform.SetParent (imageGrass.transform, false);
		hero.GetComponent<RectTransform> ().offsetMin = new Vector2 (238, 0);
		//hero.transform.
	}
}
