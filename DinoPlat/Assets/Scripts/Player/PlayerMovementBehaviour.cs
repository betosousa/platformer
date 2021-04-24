using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoPlat.Player
{
	/// <summary>
    /// Component to control player movement, handling player input for walk and jump
    /// </summary>
	public class PlayerMovementBehaviour : MonoBehaviour
	{
		public void OnMovement(InputAction.CallbackContext context){
            Debug.Log("Input: " + context.ReadValue<Vector2>());
        }
	}
}