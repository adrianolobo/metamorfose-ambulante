using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElementChoose : MonoBehaviour
{

    private InputState inputState;


    // Use this for initialization  
    void Start()
    {
        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Element Choose");
            if (gameObject.transform.rotation.eulerAngles.z >= 0 && gameObject.transform.rotation.eulerAngles.z < 90.5)
            {
                Debug.Log("WATER");
                // Debug.Log(GameObject.FindGameObjectWithTag("Player"));
            }
            if (gameObject.transform.rotation.eulerAngles.z >= 90.5 && gameObject.transform.rotation.eulerAngles.z < 180)
            {
                Debug.Log("ELECTRICITY");


            }
            if (gameObject.transform.rotation.eulerAngles.z >= 180.1 && gameObject.transform.rotation.eulerAngles.z < 270)
            {
                Debug.Log("FIRE");

            }
            if (gameObject.transform.rotation.eulerAngles.z >= 270 && gameObject.transform.rotation.eulerAngles.z < 360)
            {
                Debug.Log("WOOD");

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