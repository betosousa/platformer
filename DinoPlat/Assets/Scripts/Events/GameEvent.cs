using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DinoPlat.Events
{
	/// <summary>
    /// Scriptable object representing a game event to be raised
    /// </summary>
    [CreateAssetMenu(menuName="Game Event")]
	public class GameEvent : ScriptableObject
	{
        public UnityAction OnEvent;
        public void RaiseEvent() => OnEvent?.Invoke();
    }
}