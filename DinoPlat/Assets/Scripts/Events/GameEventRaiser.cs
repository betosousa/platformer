using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Events
{
    /// <summary>
    /// Component that raises the event selected as the player enters the trigger collider
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class GameEventRaiser : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        protected void RaiseEvent()
        {
            if (_gameEvent != null)
                _gameEvent.RaiseEvent();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                RaiseEvent();
        }
    }
}