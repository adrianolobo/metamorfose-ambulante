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
    }

    public void CleanMandioca() {
        contMandioca = 0;
    }

    public String GetCountMandioca() {
        return contMandioca.ToString(); 
    }
}   
