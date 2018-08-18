using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmokeAnimation : MonoBehaviour {

	void Start(){
		//フェードアウト
		iTween.ValueTo (gameObject, iTween.Hash("from",1,"to",0,
			"onupdate","UpdateColor","onupdatetarget",gameObject));
		//拡大
		iTween.ScaleTo(gameObject, iTween.Hash("x",1.2,"y",1.2));
	}

	void UpdateColor(float alfa){
		gameObject.GetComponent<Image> ().color = 
			new Color (206f/255,206f/255,206f/255,alfa);
	}

}
