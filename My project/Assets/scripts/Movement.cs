using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public GameObject InteractIcon;

    private Vector2 boxsize = new Vector2(0.1f,1f);

    void Start()
    {

    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        Debug.Log(Input.GetAxisRaw("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetKeyDown(KeyCode.E))
        checkIntercation();

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

    }

    void FixedUpdate()
    {
        //controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

    }

    /*    
    private float horizontalInput;
    private Rigidbody2D rigidbodyComponent;

    private Vector2 boxsize = new Vector2(0.1f,1f);
    // Start is called before the first frame update
    void Start()
    {
         rigidbodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        checkIntercation();

        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput *2, GetComponent<Rigidbody2D>().velocity.y, 0); // x, y, z
    }
*/
    public void OpenInterctableIcon(){
        InteractIcon.SetActive(true);
    }
    public void CloseInterctableIcon(){
        InteractIcon.SetActive(false);
    }

    private void checkIntercation(){

        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxsize, 0, Vector2.zero);

        if(hits.Length > 0){

            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<Interactable>())
                {
                 rc.transform.GetComponent<Interactable>().Interact(); 
                 //return;  
                }
            }

        }
    }
    

}
