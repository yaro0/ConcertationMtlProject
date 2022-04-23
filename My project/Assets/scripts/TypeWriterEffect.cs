using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] 
    private float typeWriterSpeed = 1f;

    public Coroutine Run(string textTotype,TMP_Text textLabel){

        return StartCoroutine(TypeText(textTotype, textLabel));
        
    }
    
    private IEnumerator TypeText(string textTotype,TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

       float t = 0;// elapsed time since we bagan writing 
       int charIndex = 0;

       while(charIndex < textTotype.Length)
       {
           t+= Time.deltaTime * typeWriterSpeed;
           charIndex = Mathf.FloorToInt(t);
           charIndex = Mathf.Clamp(charIndex, 0, textTotype.Length);

           textLabel.text = textTotype.Substring(0, charIndex);
           yield return null;
       }   

       textLabel.text = textTotype;
    }

}
