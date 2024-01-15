using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    public Transform player;
    public GameObject objectToActivate;
    public float activationDistance = 1f;

    private bool hasBeenActivated = false;

    void Update()
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
