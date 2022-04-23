using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(deSpawn());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator deSpawn(){

        yield return new WaitForSeconds(5);

         Destroy(gameObject);
    }
}
