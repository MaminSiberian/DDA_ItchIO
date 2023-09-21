using UnityEngine;
using System.Collections.Generic;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _click;
    [SerializeField] private List<AudioSource> _crashSounds;
    [SerializeField] private List<AudioSource> _refuelSounds;
    [SerializeField] private AudioSource _hit;
    [SerializeField] private AudioSource _getHeart;

    private static AudioSource click;
    private static List<AudioSource> crashSounds;
    private static List<AudioSource> refuelSounds;
    private static AudioSource hit;
    private static AudioSource getHeart;

    private static float minPitch = 0.92f;
    private static float maxPitch = 1.08f;

    private void Start()
    {
        click = _click;
        crashSounds = _crashSounds;
        refuelSounds = _refuelSounds;
        hit = _hit;
        getHeart = _getHeart;
    }
    public static void PlayClickSound()
    {
        click.Play();
    }
    public static void PlayCrushSound()
    {
        AudioSource audioSource = crashSounds[Random.Range(0, crashSounds.Count)];
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }
    public static void PlayRefuelSound()
    {
        AudioSource audioSource = refuelSounds[Random.Range(0, refuelSounds.Count)];
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }
    public static void PlayHitSound()
    {
        hit.pitch = Random.Range(minPitch, maxPitch);
        hit.Play();
    }
    public static void PlayGetHeartSound()
    {
        getHeart.Play();
    }
}
