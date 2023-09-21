
public class MusicController : SliderBase
{
    private void Start()
    {
        float value;
        AudioManager.mixer.audioMixer.GetFloat(AudioManager.musicVolumeParam, out value);
        slider.value = value;
    }
    protected override void OnValueChanged(float value)
    {
        AudioManager.ChangeMusicVolume(value);
    }
}
