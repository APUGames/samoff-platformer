using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawFunctionality : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float maxRotationSpeed = 1000f;
    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float proximityX = 10f;
    [SerializeField] private float proximityY = 10f;
    [SerializeField] private AudioClip spinSound;

    private AudioSource audioSource;
    private bool isPlaying = false;
    private float currentRotationSpeed = 0f;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = spinSound;
        audioSource.loop = true;
    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= maxDistance)
            {
                if (distance <= minDistance)
                {
                    currentRotationSpeed = maxRotationSpeed;
                }
                else
                {
                    float proximityX = Mathf.Clamp01(1f - (Mathf.Abs(player.position.x - transform.position.x) / this.proximityX));
                    float proximityY = Mathf.Clamp01(1f - (Mathf.Abs(player.position.y - transform.position.y) / this.proximityY));
                    currentRotationSpeed = proximityX * proximityY * maxRotationSpeed;
                }

                transform.Rotate(0f, 0f, currentRotationSpeed * Time.deltaTime);

                if (spinSound != null)
                {
                    float volume = Mathf.Clamp01(currentRotationSpeed / maxRotationSpeed);
                    if (!isPlaying && volume > 0)
                    {
                        isPlaying = true;
                        audioSource.Play();
                    }
                    else if (isPlaying && volume <= 0)
                    {
                        isPlaying = false;
                        audioSource.Stop();
                    }
                    else if (isPlaying && volume > 0)
                    {
                        audioSource.volume = volume;
                    }
                }
            }
            else if (isPlaying)
            {
                isPlaying = false;
                audioSource.Stop();
            }
        }
    }
}
