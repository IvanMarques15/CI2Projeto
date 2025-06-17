using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPieces : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private AudioSource correctSound;

    [SerializeField]
    private AudioSource wrongSound;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        var collisionElement = eventData.pointerDrag.GetComponent<PuzzlePiece>();
        if (collisionElement == null) return;

        if (collisionElement.targetImage.name == this.gameObject.name)
        {
            var currentColor = this.GetComponent<Image>().color;
            currentColor.a = 1;
            GetComponent<Image>().color = currentColor;

            correctSound?.Play(); 
            Destroy(collisionElement.gameObject, 0);
            GameManager1.IncrementRightAnswer();
        }
        else
        {
            wrongSound?.Play(); 
            collisionElement.ResetImage();
            GameManager1.IncrementWrongAnswer();
        }
    }
}
