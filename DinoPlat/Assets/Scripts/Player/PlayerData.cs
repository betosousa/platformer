using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Player
{
    /// <summary>
    /// Scriptable Object to hold player data
    /// </summary>
    [CreateAssetMenu(menuName="Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move")]
        [SerializeField] private float _walkSpeed;

        public float WalkSpeed { get { return _walkSpeed; } }
    }
}