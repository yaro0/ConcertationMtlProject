using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUi : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox1;
    [SerializeField] private GameObject bunnyDialogueBox;
    [SerializeField] private TMP_Text textLabel1;
    [SerializeField] private TMP_Text textLapin;
    [SerializeField] private DialogueObject shortDialogue;
    [SerializeField] private DialogueObject longDialogue1;
    [SerializeField] private DialogueObject dialogueLapin;
    [SerializeField] private GameObject door;

    [SerializeField] private GameObject aliceImage;

    [SerializeField] private GameObject bunnyImage;

    [SerializeField] private Movement playerMovement;

    public bool etape1 = false;
    public bool etape2 = false;
    public bool etape3 = false;

    private bool oneShowed = false;
    private bool twoShowed = false; 
    private TypeWriterEffect typeWriterEffect;

    // Start is called before the first frame update
    void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        closeDialogueBox();
        closeBunnyDialoque();


        //ShowDialogue(shortDialogue);
        ShowDialogue(textLabel1, dialogueBox1 ,longDialogue1);
        StartCoroutine(wait(etape1));
    } 

    // Update is called once per frame
    void Update()
    { 
               
        if(door.transform.localScale.y > 4 && door.transform.localScale.x >= 1.5 && !oneShowed){           
            ShowDialogue(textLabel1, dialogueBox1, shortDialogue, 0);
            oneShowed = true;
            twoShowed = false;
        } else if(door.transform.localScale.y < 1 && door.transform.localScale.x <= 1 && door.transform.localScale.x != 0 && 
        door.transform.localScale.y != 0 && !twoShowed) {
            ShowDialogue(textLabel1, dialogueBox1, shortDialogue, 1);
            oneShowed = false;
            twoShowed = true;
        } 

        if(etape1){
            ShowDialogue(textLapin, bunnyDialogueBox, dialogueLapin, 0);
            etape1 = false;
        }if(etape2 && !dialogueBox1.active){
            ShowDialogue(textLapin, bunnyDialogueBox, dialogueLapin, 1);
            etape2 = false;
        }
    }

    public void ShowDialogue(TMP_Text text, GameObject dialogueBox, DialogueObject dialogueObject, int num){

        playerMovement.enabled = false;
        dialogueBox.SetActive(true);
        StartCoroutine(readDialogue(text, dialogueObject, num));
    }

    public void ShowDialogue(TMP_Text textLabel, GameObject dialogueBox, DialogueObject dialogueObject){

        playerMovement.enabled = false;

        dialogueBox.SetActive(true);
        StartCoroutine(readLongDialogue(textLabel, dialogueObject));
    }

    private IEnumerator readDialogue(TMP_Text textLabel, DialogueObject dialogueObject, int num){
        /*
        foreach (string dialogue in dialogueObject.Dialogue)
        {
              yield return typeWriterEffect.Run(dialogue, textLabel);
        }
        */

        yield return typeWriterEffect.Run(dialogueObject.Dialogue[num], textLabel);

        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //closeDialogueBox();

        playerMovement.enabled = true;
    }

    private IEnumerator readLongDialogue(TMP_Text textLabel, DialogueObject dialogueObject)
    {

        for (int i = 1; i < dialogueObject.Dialogue.Length; i++)
        {

            if (dialogueObject.Dialogue[0] == "Alice et lapin")
            {
                
                if (i % 2 != 0)
                {
                    aliceImage.SetActive(true);
                    bunnyImage.SetActive(false);
                }
                else
                {
                    bunnyImage.SetActive(true);
                    aliceImage.SetActive(false);
                }

            } else if (dialogueObject.Dialogue[0] == "Alice"){
                Debug.Log("ALice");
                aliceImage.SetActive(true);
            } else{
                aliceImage.SetActive(true);
            }
            
            yield return typeWriterEffect.Run(dialogueObject.Dialogue[i], textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }


        closeDialogueBox();
        playerMovement.enabled = true;
    }

private IEnumerator wait(bool etape){

    yield return new WaitUntil(() => !dialogueBox1.activeSelf);
    etape1 = true;
    Debug.Log("OUI");
}
    

    private void closeDialogueBox()
    {     
        dialogueBox1.SetActive(false);
        textLabel1.text = string.Empty;
        bunnyImage.SetActive(false);
        aliceImage.SetActive(false);
    }

    private void closeBunnyDialoque(){
        bunnyDialogueBox.SetActive(false);
        textLapin.text = string.Empty;
    }
    
   
}
