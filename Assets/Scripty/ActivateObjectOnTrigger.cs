using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateObjectOnTrigger : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Animator ourAnimator;
    [SerializeField] public Transform player;
    [SerializeField] public float activationDistance = 1f;
=======
    [SerializeField] private Transform player;
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private float activationDistance = 1f;
    [SerializeField] private bool hasBeenActivated = false;
>>>>>>> 77b9a5795366c5f54885d1a91709df55c603db2c

    private void Update()
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
