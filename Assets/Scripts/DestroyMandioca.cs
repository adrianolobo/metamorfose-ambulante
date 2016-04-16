using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyMandioca : MonoBehaviour {
    public AudioClip shootSound;
    public Text placarMandioca; 



    private AudioSource source;
    private float volHighRange = 1.0f;
    private MandiocaManager mandiocaManager;

   

    void Awake()
    {
        mandiocaManager = GameObject.Find("MandiocaManager").GetComponent<MandiocaManager>();
        source = GetComponent<AudioSource>();
        placarMandioca = GameObject.Find("Placar Mandioca").GetComponent<Text>();
        Debug.Log(placarMandioca.text);

    }
        


    void Update() {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag  == "MANDIOCA") {
            GameObjectUtil.Destroy(col.gameObject);
            float vol = volHighRange;
            source.PlayOneShot(shootSound,vol);
            mandiocaManager.AddMandioca();
            placarMandioca.text = mandiocaManager.GetCountMandioca();

        }
        
    }

    }
   
