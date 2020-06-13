using UnityEngine;

[CreateAssetMenu(menuName = "Hiddenz/Sound", fileName = "Sound.asset")]
public class Sound : ScriptableObject
{
    [System.Serializable]
    public enum SoundType
    {
        MUSIC, FX
    }
    public SoundType soundType;
    public AudioClip clip;
    [Range(0,1f)]
    public float volume;
    public bool loop;

}
