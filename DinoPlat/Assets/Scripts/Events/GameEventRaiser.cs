using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Events
{
    /// <summary>
    /// Component that raises the event selected as the player enters the trigger collider
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class GameEventRaiser : EventRaiserBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                RaiseEvent();
        }
    }
}