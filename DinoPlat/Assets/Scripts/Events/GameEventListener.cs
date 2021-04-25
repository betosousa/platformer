using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DinoPlat.Events
{
	/// <summary>
    /// Component that listens to a event and reacts to it
    /// </summary>
	public class GameEventListener : MonoBehaviour
	{
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _unityEvent;

		void Awake() => _gameEvent.OnEvent += OnEventRaised;
        void OnEventRaised() => _unityEvent?.Invoke();
		void OnDestroy() => _gameEvent.OnEvent -= OnEventRaised;
    }
}