using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Player
{
    /// <summary>
    /// Scriptable Object to hold player data
    /// </summary>
    [CreateAssetMenu(menuName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move")]
        [SerializeField] private float _walkSpeed;
		[SerializeField] private float _runSpeed;

        [Header("Jump")]
        [SerializeField] private LayerMask _groundLayers;
        [SerializeField] private float _jumpForce;


        public float WalkSpeed { get { return _walkSpeed; } }
		public float RunSpeed { get { return _runSpeed; } }
        public LayerMask GroundLayers { get { return _groundLayers; } }
        public float JumpForce { get { return _jumpForce; } }
    }
}