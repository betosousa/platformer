using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DinoPlat.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerHealth : MonoBehaviour
    {
		private void OnEnable() {
			GetComponent<Animator>().SetBool("IsDead", false);
		}
        public void Die()
        {
            GetComponent<Animator>().SetBool("IsDead", true);
        }
    }
}