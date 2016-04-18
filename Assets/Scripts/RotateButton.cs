using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateButton : MonoBehaviour
{

    private float cont = 3.0f;


    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        cont += Time.fixedDeltaTime;
        //Debug.Log(cont);
		if (Input.anyKeyDown)
		{
            {
                //Debug.Log(gameObject.transform.rotation.eulerAngles.z);
                cont = 0.0f;
                //Debug.Log(cont);
            }
        }
        if (cont > 0.2f)
        {
            transform.Rotate(Vector3.forward * -220 * Time.fixedDeltaTime);
            //Debug.Log(cont);
        }


    }

}