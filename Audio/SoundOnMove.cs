using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnMove : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public float minMoveDistance = 0.01f;

    private Vector3 previousPosition;
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = Vector3.Distance(previousPosition, transform.position);

        if (moveDistance >= minMoveDistance)
            {
               if (!audioSource.isPlaying)
                {
                audioSource.Play();
                }
            } 
        else
            {
            audioSource.Stop();
            }
        previousPosition = transform.position;
    }
}
