using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private float activationDistance = 1f;
    [SerializeField] private bool hasBeenActivated = false;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= activationDistance && !hasBeenActivated)
        {
            objectToActivate.SetActive(true);
            hasBeenActivated = true;
        }
        else if (distanceToPlayer > activationDistance && hasBeenActivated)
        {
            objectToActivate.SetActive(false);
            hasBeenActivated = false;
        }
    }
}
