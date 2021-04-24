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
        private const string IS_GROUNDED_ANIM_PARAM = "IsGrounded";
        private const float FEET_RADIUS = .05f;
        private Vector2 _movementInput;
        private bool _isGrounded;
        public bool _jump;
        private Rigidbody2D _body;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform _feet;

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
            _movementInput = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            // Set velocity
            float ySpeed = (_isGrounded && _jump) ? _playerData.JumpForce : _body.velocity.y;
            _body.velocity = new Vector2(_movementInput.x * _playerData.WalkSpeed, ySpeed);
            
            // Reset variables
            _isGrounded = Physics2D.OverlapCircle(_feet.position, FEET_RADIUS, _playerData.GroundLayers);
            _jump = false;
        }

        private void Update()
        {
            _spriteRenderer.flipX = _body.velocity.x < 0;
            _animator.SetFloat(SPEED_ANIM_PARAM, Mathf.Abs(_body.velocity.x));
            _animator.SetBool(IS_GROUNDED_ANIM_PARAM, _isGrounded);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_feet.position, FEET_RADIUS);
        }
#endif
    }
}