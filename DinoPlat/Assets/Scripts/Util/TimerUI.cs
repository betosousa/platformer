using System.Collections;
using System.Collections.Generic;
using DinoPlat.Events;
using UnityEngine;
using UnityEngine.UI;

namespace DinoPlat.Util
{
    /// <summary>
    /// Component that displays the remaining gameplay time
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TimerUI : RaiseEventOverTime
    {
        [SerializeField] private Text _finalTimerText;
        private Text _timerText;
        private int _currentTime;

        protected override void OnEnable()
        {
            _timerText = GetComponent<Text>();
            base.OnEnable();
            StartCoroutine(UpdateTimer());
        }

        IEnumerator UpdateTimer()
        {
            for (_currentTime = Mathf.FloorToInt(TimeToRaiseEvent) - 1; _currentTime >= 0; _currentTime--)
            {
                _timerText.text = _currentTime.ToString();
                yield return new WaitForSeconds(1f);
            }
        }

        /// <summary>
        /// Shows the final gameplay time
        /// </summary>
        public void FinalScore()
        {
            _finalTimerText.text = "Game Time: " +  (TimeToRaiseEvent - _currentTime) + "s";
        }
    }
}