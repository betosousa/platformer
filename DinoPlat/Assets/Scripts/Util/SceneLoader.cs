using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DinoPlat.Util
{
    /// <summary>
    /// ScriptableObject to load scenes
    /// </summary>
    [CreateAssetMenu(menuName = "SceneLoader", fileName = "SceneLoader")]
    public class SceneLoader : ScriptableObject
    {
        /// <summary>
        /// Loads a scene based on build index 
        /// </summary>
        /// <param name="scene"></param>
        public void LoadScene(Scenes scene) => SceneManager.LoadScene((int)scene);

        public void LoadMenu() => LoadScene(Scenes.MENU);
        public void LoadGame() => LoadScene(Scenes.GAME);

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }

    }

    /// <summary>
    /// Enum to map build indexes to game scenes
    /// </summary>
    public enum Scenes
    {
        MENU = 0,
        GAME = 1,
    }
}