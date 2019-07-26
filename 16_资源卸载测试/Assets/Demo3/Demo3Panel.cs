using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Demo3Panel : MonoBehaviour
{
    public AudioSource _audioSource;
    private ResLoader mResLoader = new ResLoader();

    void Start()
    {
        _audioSource = GameObject.FindWithTag("AudioManager").GetComponent<AudioSource>();
       var a1 =  mResLoader.LoadAsset<AudioClip>("Voice/voice_01");
       var a2 = mResLoader.LoadAsset<AudioClip>("Voice/voice_02");
       var a3 = mResLoader.LoadAsset<AudioClip>("Voice/voice_03");

       var a4 = mResLoader.LoadAsset<AudioClip>("Voice/voice_01");
       
       
       Debug.Log("<color=green>" + mResLoader.Count + "</color>");
       _audioSource.clip = a3;
       _audioSource.Play();
       StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return  new WaitForSeconds(10.0f);
        mResLoader.ReleaseAll();
        Debug.Log(mResLoader.Count);
    }
    
}
