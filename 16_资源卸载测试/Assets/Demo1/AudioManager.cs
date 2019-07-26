using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource _audioSource;
    private AudioClip _audioClip;
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioClip = Resources.Load<AudioClip>("voice_01");
        _audioSource.clip = _audioClip;
        _audioSource.Play();
        StartCoroutine(Unload());
    }

    IEnumerator Unload()
    {
        yield return  new WaitForSeconds(5.0f);
        Resources.UnloadAsset(_audioClip);
    }
}
