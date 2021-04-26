using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DinoPlat.Items;
using UnityEngine;
using UnityEngine.UI;

namespace DinoPlat.Stats
{
    /// <summary>
    /// Component that counts and displays the total items collected
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class ItemsCount : MonoBehaviour
    {

        private int _totalItems;
        private int _collectedItems;
        private void OnEnable()
        {
            var items = FindObjectsOfType<ItemBehaviour>();
            _totalItems = items == null ? 0 : items.Length;
            _collectedItems = 0;
        }

        public void OnItemCollected() => _collectedItems++;
        public void OnGameEnd() => GetComponent<Text>().text = _collectedItems + "/" + _totalItems + " Items";
    }
}