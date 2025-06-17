using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] private int pecasNecessarias = 0; 

    private int pecasCorretas = 0;
    private int pecasErradas = 0;

    public static GameManager1 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void IncrementRightAnswer()
    {
        if (Instance == null) return;

        Instance.pecasCorretas++;
        Debug.Log("Peças corretas: " + Instance.pecasCorretas);

        if (Instance.pecasCorretas >= Instance.pecasNecessarias)
        {
            Instance.Invoke(nameof(Instance.ProximaCena), 1.5f);
        }
    }

    public static void IncrementWrongAnswer()
    {
        if (Instance == null) return;

        Instance.pecasErradas++;
        Debug.Log("Peças erradas: " + Instance.pecasErradas);
    }

    private void ProximaCena()
    {
        string cenaAtual = SceneManager.GetActiveScene().name;

        switch (cenaAtual)
        {
            case "lvl1":
                SceneManager.LoadScene("v1");
                break;
            case "lvl2":
                SceneManager.LoadScene("v2");
                break;
            case "lvl3":
                SceneManager.LoadScene("v3");
                break;
            default:
                Debug.LogWarning("Cena inesperada ou final já atingido.");
                break;
        }
    }
}
