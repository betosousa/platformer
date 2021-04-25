using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Player
{
    /// <summary>
    /// Component that controls if the player is dead
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class PlayerHealth : MonoBehaviour
    {
        private const string IS_DEAD_ANIM_PARAM = "IsDead";
        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool(IS_DEAD_ANIM_PARAM, false);
        }

        /// <summary>
        /// Triggers the death animation state
        /// </summary>
        public void Die() => _animator.SetBool(IS_DEAD_ANIM_PARAM, true);

    }
}