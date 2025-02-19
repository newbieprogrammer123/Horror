using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Screamer : Singletone<Screamer>
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject image;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Show()
    {
        source.clip = clip; 
        source.Play();
        image.gameObject.SetActive(true);
        Invoke("DisableImage", 2f);
    }

    private void DisableImage()
    {
        image.gameObject.SetActive(false);
    }
}
