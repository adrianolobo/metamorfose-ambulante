using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MandiocaManager : MonoBehaviour {

    private int contMandioca = 0;

    void Start () {
    }


    public void AddMandioca() {
        contMandioca += 1;
        Debug.Log(contMandioca);
    }

    public void CleanMandioca() {
        contMandioca = 0;
        Debug.Log(contMandioca);
        Debug.Log("zerado");
    }

    public String GetCountMandioca() {
        return contMandioca.ToString(); 
    }
}   
