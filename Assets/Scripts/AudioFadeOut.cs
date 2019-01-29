using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour {

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            if(audioSource.volume < 0.09) { audioSource.enabled = !audioSource.enabled; break; }

            yield return null;
        }
        Debug.Log("Volume reached the end");
       
      //  audioSource.volume = startVolume;
    }
}
