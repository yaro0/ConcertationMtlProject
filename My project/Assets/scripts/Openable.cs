using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interactable
{

    [SerializeField] private DialogueObject shortDialogue;
    [SerializeField] private TMP_Text textLabel1;
    [SerializeField] private GameObject dialogueBox1;
    [SerializeField] private Canvas canvas;
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;

    private bool wasIntercated = false;

    public override void Interact()
    {
        Debug.Log("interacted");
        if(!isOpen){
            sr.sprite = open;
            isOpen = !isOpen;
        }

        if(!wasIntercated){
            canvas.GetComponent<DialogueUi>().ShowDialogue(textLabel1,dialogueBox1, shortDialogue);
            canvas.GetComponent<DialogueUi>().etape2 = true;
            wasIntercated = true;
        }
    
    }
    private void Start(){
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }
}
