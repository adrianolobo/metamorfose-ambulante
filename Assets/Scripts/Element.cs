using UnityEngine;
using System.Collections;



public class Element : MonoBehaviour{


	public string element;

	string[] ElementList = {"water","electricity","fire","wood"};
	string[] ElementWeaknessList = {"electricity","wood","water","fire"};
	

	// Use this for initialization

	public Element(){
	}

	void Start () {
		if(gameObject.tag == "Player"){
			int range = Random.Range (0, ElementList.Length);
			element = ElementList [range];
			//Debug.Log("RANDOM: "+element+" RANGE: "+range);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "MANDIOCA") {
			string element_mandioca = coll.gameObject.GetComponent<Element>().element;
			Debug.Log (element + " - "+ element_mandioca);
			
			int index = System.Array.IndexOf(ElementList,element);
			if(ElementWeaknessList[index] == element_mandioca){
				Debug.Log ("BOOOOOMMMMM!!!!!");
			}
		}
	}

	void setRandomElement(){
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Restart(){
		Debug.Log("RESTART");
	}
}
