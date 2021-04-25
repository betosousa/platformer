using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DinoPlat.Stats
{
    /// <summary>
    /// Component that calculates player points
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class PointsManager : MonoBehaviour
    {
        private int _totalPoints;
        private Text _pointsUI;

        private void OnEnable()
        {
            _totalPoints = 0;
            _pointsUI = GetComponent<Text>();
            UpdatePoints();
        }

        public void AddPoints(int value)
        {
            _totalPoints += value;
            UpdatePoints();
        }

        void UpdatePoints()
        {
            _pointsUI.text = _totalPoints.ToString();
        }
    }
}