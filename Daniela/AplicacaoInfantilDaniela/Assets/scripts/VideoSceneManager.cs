using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = FindFirstObjectByType<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer não encontrado!");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        string cenaAtual = SceneManager.GetActiveScene().name;

        switch (cenaAtual)
        {
            case "v1":
                SceneManager.LoadScene("lvl2");
                break;
            case "v2":
                SceneManager.LoadScene("lvl3");
                break;
            case "v3":
                SceneManager.LoadScene("FinalScene");
                break;
        }
    }
}
