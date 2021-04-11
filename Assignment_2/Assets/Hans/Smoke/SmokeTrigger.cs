using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTrigger : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem part;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            part.Play();
        }
    }
}
