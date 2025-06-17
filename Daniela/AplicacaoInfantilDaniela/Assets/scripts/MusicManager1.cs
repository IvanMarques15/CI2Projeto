using UnityEngine;


public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicaFundo; 

    void Start()
    {
        
        if (musicaFundo != null && !musicaFundo.isPlaying)
        {
            musicaFundo.Play();
        }
    }

   
    public void PararMusica()
    {
        if (musicaFundo != null && musicaFundo.isPlaying)
        {
            musicaFundo.Stop();
        }
    }

    void CompletarNivel()
    {
      
        FindFirstObjectByType<MusicManager>()?.PararMusica();

        
        GetComponent<AudioSource>().Play();

        
        Invoke("ProximoVideo", 2f);
    }

    public void SetMute(bool muted)
    {
        if (musicaFundo != null)
        {
            musicaFundo.mute = muted;
        }
    }


}
