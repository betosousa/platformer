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
        private Text _timerText;

        protected override void OnEnable()
        {
            _timerText = GetComponent<Text>();
            base.OnEnable();
            StartCoroutine(UpdateTimer());
        }

        IEnumerator UpdateTimer()
        {
            for (int i = Mathf.FloorToInt(TimeToRaiseEvent); i >= 0; i--)
            {
                _timerText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}