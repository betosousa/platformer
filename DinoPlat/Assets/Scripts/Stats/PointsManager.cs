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
        [SerializeField] private Text _finalScoreUI;

        private void OnEnable()
        {
            _totalPoints = 0;
            _pointsUI = GetComponent<Text>();
            UpdatePoints();
        }

        /// <summary>
        /// Adds the informed value to the players score
        /// </summary>
        /// <param name="value"></param>
        public void AddPoints(int value)
        {
            _totalPoints += value;
            UpdatePoints();
        }

        /// <summary>
        /// Shows the final score
        /// </summary>
        public void FinalScore()
        {
            _finalScoreUI.text = "Score: " + _totalPoints;
        }

        void UpdatePoints()
        {
            _pointsUI.text = _totalPoints.ToString();
        }


    }
}