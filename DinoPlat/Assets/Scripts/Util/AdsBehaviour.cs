using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

namespace DinoPlat.Util
{
	/// <summary>
    /// Component to show unity ads
    /// </summary>
    public class AdsBehaviour : MonoBehaviour, IUnityAdsListener
    {
        private const string GAME_ID = "4108913";
        private const string PLACEMENT = "video";

#if UNITY_EDITOR
        private const bool TEST_MODE = true;
#else
    	private const bool TEST_MODE = false;
#endif

        [SerializeField] private UnityEvent OnAdFinished;

        IEnumerator Start()
        {
            Advertisement.Initialize(GAME_ID, TEST_MODE);
            Advertisement.AddListener(this);
            yield return null;
            while (!Advertisement.IsReady(PLACEMENT))
                yield return null;
        }

		/// <summary>
        /// Shows the ad if it is ready, otherwise raises the OnAdFinished event
        /// </summary>
        public void ShowAd()
		{
			if(Advertisement.IsReady(PLACEMENT))
 				Advertisement.Show();
			else
				OnAdFinished?.Invoke();
		}
        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) => OnAdFinished?.Invoke();
        public void OnUnityAdsDidStart(string placementId) => Debug.Log("Ad " + placementId + " started");
        public void OnUnityAdsReady(string placementId) => Debug.Log("Ad " + placementId + " ready");
        public void OnUnityAdsDidError(string message) => Debug.Log("ERROR On ad:" + message);
    }
}