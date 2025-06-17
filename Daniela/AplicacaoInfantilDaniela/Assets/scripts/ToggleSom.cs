using UnityEngine;
using UnityEngine.UI;

public class ToggleSom : MonoBehaviour
{
    [SerializeField] private Sprite iconeSomLigado;
    [SerializeField] private Sprite iconeSomDesligado;

    private Image imagemBotao;
    private MusicManager musicManager;
    private bool somLigado = true;

    void Start()
    {
        imagemBotao = GetComponent<Image>();
        musicManager = FindFirstObjectByType<MusicManager>();

        AtualizarIcone();
    }

    public void AlternarSom()
    {
        if (musicManager == null) return;

        somLigado = !somLigado;
        musicManager.SetMute(!somLigado);

        AtualizarIcone();
    }

    private void AtualizarIcone()
    {
        if (imagemBotao == null) return;

        imagemBotao.sprite = somLigado ? iconeSomLigado : iconeSomDesligado;
    }
}
