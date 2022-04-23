using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleMovement : MonoBehaviour
{
	private Vector2 targetPos;
	public float Yincrement;

	public float speed;
	public float maxWidth;
	public float minWidth;


	private void Update(){
		transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < maxWidth){
			targetPos = new Vector2(transform.position.x + Yincrement, transform.position.y);
			transform.position = targetPos;

		}else if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > minWidth){
			targetPos = new Vector2(transform.position.x - Yincrement, transform.position.y);
			transform.position = targetPos;
		}
	}
}
