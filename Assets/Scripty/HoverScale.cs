using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip hoverSoundClip; // Assign the hover audio clip in the Inspector
    private AudioSource audioSource;
    private Vector3 originalScale;
    private Vector3 hoveredScale;
    private float scaleDuration = 0.2f; // Adjust this to control the duration of the scaling animation

    public float scaleIncreaseFactor = 1.25f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hoverSoundClip;
        originalScale = transform.localScale;
        hoveredScale = originalScale * scaleIncreaseFactor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
        StopAllCoroutines(); // Stop any ongoing scaling animation
        StartCoroutine(ScaleOverTime(hoveredScale, scaleDuration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        audioSource.Stop();
        StopAllCoroutines(); // Stop any ongoing scaling animation
        StartCoroutine(ScaleOverTime(originalScale, scaleDuration));
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startScale = transform.localScale;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // Ensure it ends at the exact scale
    }
}
