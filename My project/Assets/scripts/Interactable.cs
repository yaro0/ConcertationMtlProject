using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public abstract void Interact();

    private void OnTriggerEnter2d(Collider2D collision){
        if(collision.CompareTag("Player"))
        collision.GetComponent<Movement>().OpenInterctableIcon();
    }

    private void OnTriggerExit2d(Collider2D collision){
        if(collision.CompareTag("Player"))
        collision.GetComponent<Movement>().CloseInterctableIcon();
    }
}
