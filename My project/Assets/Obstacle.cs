using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(gameObject.transform.position.y > 8){
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
           // other.GetComponent<Player>.
           Debug.Log("Tigger");
            Destroy(gameObject);
        }
    }
}
