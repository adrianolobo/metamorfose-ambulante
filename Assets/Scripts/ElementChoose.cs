using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElementChoose : MonoBehaviour
{

	private Element playerElement;

	void Awake(){
	}
    // Use this for initialization  

    // Update is called once per frame
    void Update()
    {

		if (Input.anyKeyDown)
        {
			if(GameObject.FindGameObjectWithTag ("Player") != null){


				playerElement = GameObject.FindGameObjectWithTag ("Player").GetComponent<Element> ();

	            Debug.Log("Element Choose");
	            if (gameObject.transform.rotation.eulerAngles.z >= 0 && gameObject.transform.rotation.eulerAngles.z < 90.5)
	            {
					playerElement.setElementByNumber(1);
	                Debug.Log("WATER");
	                // 
	            }
	            if (gameObject.transform.rotation.eulerAngles.z >= 90.5 && gameObject.transform.rotation.eulerAngles.z < 180)
	            {
					playerElement.setElementByNumber(2);
	                Debug.Log("ELECTRICITY");


	            }
	            if (gameObject.transform.rotation.eulerAngles.z >= 180.1 && gameObject.transform.rotation.eulerAngles.z < 270)
	            {
					playerElement.setElementByNumber(3);
	                Debug.Log("FIRE");

	            }
	            if (gameObject.transform.rotation.eulerAngles.z >= 270 && gameObject.transform.rotation.eulerAngles.z < 360)
	            {
					playerElement.setElementByNumber(4);
	                Debug.Log("WOOD");

	            }
			}
		}

    }

    // void OnCollisionEnter2D(Collision2D coll)
    // {
    //     Debug.Log("colidiu");
    //
    //    if (coll.gameObject.tag == "SETA")
    //    {
    //         Debug.Log(gameObject.name);
    //         Debug.Log("TIPO");
    //     }
    // }

}