using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Minijuegos.Scripts
{
    public class Scene : MonoBehaviour
    {
        public static Scene Instance { get; private set; }

        [SerializeField]
        public GameObject[] disableObjects;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoadScene(string sceneName)
        {
            foreach (GameObject obj in disableObjects)
            {
                obj.SetActive(false);
            }

            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void UnloadScene(string sceneName)
        {
            foreach (GameObject obj in disableObjects)
            {
                obj.SetActive(true);
            }

            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}