using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    public static AudioMixerGroup mixer { get; private set; }
    public static string musicVolumeParam { get; private set; }
    public static string soundsVolumeParam { get; private set; }

    private static string _musicVolumeParam = "MusicVolume";
    private static string _soundsVolumeParam = "SoundsVolume";
    public static AudioManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        mixer = _mixer;
        musicVolumeParam = _musicVolumeParam;
        soundsVolumeParam = _soundsVolumeParam;
    }
    public static void ChangeMusicVolume(float volume)
    {
        mixer.audioMixer.SetFloat(musicVolumeParam, volume);
    }
    public static void ChangeSoundsVolume(float volume)
    {
        mixer.audioMixer.SetFloat(soundsVolumeParam, volume);
    }
}
