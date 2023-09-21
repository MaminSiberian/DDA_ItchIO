

public class SoundController : SliderBase
{
    private void Start()
    {
        float value;
        AudioManager.mixer.audioMixer.GetFloat(AudioManager.soundsVolumeParam, out value);
        slider.value = value;
    }
    protected override void OnValueChanged(float value)
    {
        AudioManager.ChangeSoundsVolume(value);
    }
}
