using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Events
{
	/// <summary>
    /// Component that raises the event selected
    /// </summary>
	public class EventRaiserBehaviour : MonoBehaviour
	{
	    [SerializeField] private GameEvent _gameEvent;
        protected virtual void RaiseEvent()
        {
            if (_gameEvent != null)
                _gameEvent.RaiseEvent();
        }
	}
}