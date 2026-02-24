using System.Collections;
using UnityEngine;

public class ThunderLoop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip thunderClip;
    [SerializeField] private Light directionalLight;

    [Header("Timing")]
    [SerializeField] private float intervalSeconds = 30f;
    [SerializeField] private bool randomize = true;
    [SerializeField] private float randomJitterSeconds = 5f; // +/- jitter

    [Header("Lightning Flash")]
    [SerializeField] private float flashIntensity = 3f;
    [SerializeField] private float flashDuration = 0.1f;

    private Coroutine routine;

    void Awake()
    {
        if (!audioSource) audioSource = GetComponent<AudioSource>();
        StopThunder();
    }

    public void StartThunder()
    {
        if (routine != null) return;
        routine = StartCoroutine(ThunderRoutine());
    }

    public void StopThunder()
    {
        if (routine != null) StopCoroutine(routine);
        routine = null;
    }

    private IEnumerator ThunderRoutine()
    {
        while (true)
        {
            float wait = intervalSeconds;
            if (randomize)
                wait += Random.Range(-randomJitterSeconds, randomJitterSeconds);

            if (wait < 1f) wait = 1f;

            yield return new WaitForSeconds(wait);

            if (thunderClip && audioSource)
                audioSource.PlayOneShot(thunderClip);

            if (directionalLight)
                StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        float original = directionalLight.intensity;
        directionalLight.intensity = flashIntensity;
        yield return new WaitForSeconds(flashDuration);
        directionalLight.intensity = original;
    }
}
