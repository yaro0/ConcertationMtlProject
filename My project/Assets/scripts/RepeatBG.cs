using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{

    public float speed;

    public float endY;

    public float startY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
      transform.Translate(Vector2.up * speed * Time.deltaTime);

      if(transform.position.y >= endY){
          Vector2 pos = new Vector2(transform.position.x, startY);
          transform.position = pos;
      }

    }
}
