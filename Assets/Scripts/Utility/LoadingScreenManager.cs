using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EAE.Race.Utility
{
    /// <summary>
    /// Manages the loading screen
    /// </summary>
    public class LoadingScreenManager : MonoBehaviour
    {
        private bool isLoading = false;

        private Animator loadingScreenAnimator;

        private const string LOAD_START = "LoadStart";
        private const string LOAD_END = "LoadEnd";

        private void Awake()
        {
            //Make sure we don't have any extra loading screens; if we already have one, we need to destroy this one
            if (GameObject.FindObjectsOfType<LoadingScreenManager>() != null && GameObject.FindObjectsOfType<LoadingScreenManager>().Length > 1)
                Destroy(this.gameObject);

            //Make sure we don't destroy our loading screen
            DontDestroyOnLoad(this.gameObject);

            loadingScreenAnimator = this.GetComponent<Animator>();
        }

        /// <summary>
        /// Loads a specified level
        /// </summary>
        public void LoadLevel(string levelName)
        {
            if (isLoading)
                return;

            isLoading = true;
            loadingScreenAnimator.SetTrigger(LOAD_START);

            StartCoroutine(LoadLevelAsync(levelName));
        }

        IEnumerator LoadLevelAsync(string levelName)
        {
            //Wait for the screen to turn black before starting load
            yield return new WaitForSeconds(0.5f);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);


            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            //Gets rid of the black screen to end the loading
            loadingScreenAnimator.SetTrigger(LOAD_END);
            isLoading = false;
        }

    }
}