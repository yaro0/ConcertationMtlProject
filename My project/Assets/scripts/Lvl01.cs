using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl01 : MonoBehaviour
{
    public GameObject GameObject;
    public string code;
    private string s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Inputs input = new Inputs();
            input = GameObject.GetComponent<Inputs>();
            s = input.getString();
            if (s == code){
                Debug.Log("AAA");
            }
        }
    }
}
