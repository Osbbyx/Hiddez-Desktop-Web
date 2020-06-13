
using UnityEngine;
using TMPro;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public TMP_Text topScoreText;

    public Sound menuSound;
    public Sound buttonSound;
    void Start()
    {
        topScoreText.text = PlayerPrefs.GetInt("TopScore").ToString()+"s";
        AudioManager.Instance.PlaySound(menuSound);
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
