using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BotaoMaca : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Vector3 escalaOriginal;
    private bool mouseEmCima = false;
    private float tempo = 0f;

    [SerializeField] private float escalaMaxima = 1.1f;
    [SerializeField] private float velocidade = 5f;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        tempo += Time.deltaTime * velocidade;

        if (mouseEmCima)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal * escalaMaxima, Time.deltaTime * velocidade);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal, Time.deltaTime * velocidade);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEmCima = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEmCima = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("lvl1");
    }
}
