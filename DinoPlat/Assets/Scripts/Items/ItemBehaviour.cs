using System.Collections;
using System.Collections.Generic;
using DinoPlat.Events;
using UnityEngine;

namespace DinoPlat.Items
{
    /// <summary>
    /// Component that controls item behaviour, raising item collected events
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ItemBehaviour : GameEventRaiser
    {
        protected override void RaiseEvent()
        {
            base.RaiseEvent();
            gameObject.SetActive(false);
        }
    }
}