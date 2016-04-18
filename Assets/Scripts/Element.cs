using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Element : MonoBehaviour{


	public string element;
	public Text placarMandioca; 
	private MandiocaManager mandiocaManager;


	string[] ElementWeaknessList = {"electricity","wood","water","fire"};
	string[] ElementList = {"water","electricity","fire","wood"};
	string[] ElementStrengthList = {"fire","water","wood","electricity"};
	

	// Use this for initialization

	public Element(){
	}

	void Awake(){
		mandiocaManager = GameObject.Find("MandiocaManager").GetComponent<MandiocaManager>();
		placarMandioca = GameObject.Find("Placar Mandioca").GetComponent<Text>();
	}

	void Start () {
		if(gameObject.tag == "Player"){
			setRandomElement();

		}

	}

	public void setRandomElement(){
		int range = Random.Range (0, ElementList.Length);
		gameObject.GetComponent<Animator>().SetInteger("elementState",range+1);
		element = ElementList [range];
		Debug.Log("ELEMENT");
	}

	public void setElementByNumber(int elementIndex){
		gameObject.GetComponent<Animator>().SetInteger("elementState",elementIndex);
		element = ElementList [elementIndex-1];
	}
	
	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "MANDIOCA") {
			string element_mandioca = coll.gameObject.GetComponent<Element>().element;
			Debug.Log (element + " - "+ element_mandioca);
			
			int index = System.Array.IndexOf(ElementList,element);
			if(ElementStrengthList[index] == element_mandioca){
				Debug.Log ("FORTE!!!!!");

				GameObjectUtil.Destroy(coll.gameObject);
				mandiocaManager.AddMandioca();
				placarMandioca.text = mandiocaManager.GetCountMandioca();
				//float vol = volHighRange;
				//source.PlayOneShot(shootSound,vol);
				//mandiocaManager.AddMandioca();
				//placarMandioca.text = mandiocaManager.GetCountMandioca();
			}
		}
	}
	

	// Update is called once per frame
	void Update () {
	}
	
	public void Restart(){
		Debug.Log("RESTART");
	}
}