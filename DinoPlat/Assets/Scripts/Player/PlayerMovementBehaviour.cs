using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoPlat.Player
{
    /// <summary>
    /// Component to control player movement, handling player input for walk and jump
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        private const string SPEED_ANIM_PARAM = "Speed";
        private Vector2 movementInput;
        private Rigidbody2D _body;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            _body = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Stores player input to be used on fixed update
        /// </summary>
        /// <param name="context"></param>
        public void OnMovement(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _body.velocity = new Vector2(movementInput.x, 0f);
        }

        private void Update()
        {
            _spriteRenderer.flipX = _body.velocity.x < 0;
            _animator.SetFloat(SPEED_ANIM_PARAM, Mathf.Abs(_body.velocity.x));
        }
    }
}