using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudioPlayer : MonoBehaviour
{
   
    public Sound gameplayMusicSounds;
    public Sound buttonSound;
    void Start()
    {
        AudioManager.Instance.PlaySound(gameplayMusicSounds);
    }

    public void ChangeScenceAfterButtonSound(string sceneToLoad)
    {
        AudioManager.Instance.PlaySound(buttonSound);
        StartCoroutine(ChangeScenceAfterButtonSoundCoroutine(sceneToLoad));
        /*GameSceneManager.Instance.ChangeScene(sceneToLoad);*/
    }
    private IEnumerator ChangeScenceAfterButtonSoundCoroutine(string sceneToLoad)
    {
        yield return new WaitForSeconds(buttonSound.clip.length);
        GameSceneManager.Instance.ChangeScene(sceneToLoad);
    }


}
