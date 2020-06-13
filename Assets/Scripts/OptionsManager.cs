
using System.Collections;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{

    public Sound buttonSound;

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

    public void ResetTopScore()
    {
        AudioManager.Instance.PlaySound(buttonSound);
        PlayerPrefs.SetInt("TopScore", 0);
    }
}
