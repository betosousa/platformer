using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Events
{
    /// <summary>
    /// Component to raise an event after a given time
    /// </summary>
    public class RaiseEventOverTime : EventRaiserBehaviour
    {
        [SerializeField] private float _timeToRaise;

        protected float TimeToRaiseEvent { get { return _timeToRaise; } }

        protected virtual void OnEnable() => StartCoroutine(WaitToRaise());
        IEnumerator WaitToRaise()
        {
            yield return new WaitForSeconds(_timeToRaise);
            RaiseEvent();
        }
    }
}