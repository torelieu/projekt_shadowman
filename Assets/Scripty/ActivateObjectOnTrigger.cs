using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    [SerializeField] private Animator ourAnimator;
    [SerializeField] public Transform player;
    [SerializeField] public float activationDistance = 1f;

    private bool hasBeenActivated = false;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= activationDistance && !hasBeenActivated)
        {
            ourAnimator.SetTrigger("Show");
            hasBeenActivated = true;
        }
        else if (distanceToPlayer > activationDistance && hasBeenActivated)
        {
            ourAnimator.SetTrigger("Disable");
            hasBeenActivated = false;
        }
    }
}
