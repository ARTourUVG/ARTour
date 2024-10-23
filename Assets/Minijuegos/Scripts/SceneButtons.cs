using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Minijuegos.Scripts
{
    public class SceneButtons : MonoBehaviour
    {
        [SerializeField]
        private UIDocument uxml;
        [SerializeField]
        private Scene scene;
        [SerializeField]
        private string menuName;

        [SerializeField]
        private string[] sceneNames;
        [SerializeField]
        private string[] buttonNames;

        //void Start()
        //{
        //    scene = Scene.Instance;
        //    VisualElement mainMenu = uxml.rootVisualElement.Q<VisualElement>(menuName);

        //    for (int i = 0; i < sceneNames.Length; i++)
        //    {
        //        Button button = mainMenu.Q<Button>(buttonNames[i]);
        //        int index = i;
        //        button.clicked += () => LoadScene(sceneNames[index]);
        //    }
        //}

        public void LoadScene(string sceneName)
        {
            Scene.Instance.LoadScene(sceneName);
        }

        void OnEnable()
        {
            VisualElement mainMenu = uxml.rootVisualElement.Q<VisualElement>(menuName);

            for (int i = 0; i < sceneNames.Length; i++)
            {
                Button button = mainMenu.Q<Button>(buttonNames[i]);
                int index = i;

                // Asegurarse de eliminar cualquier suscripción anterior para evitar duplicados
                button.clicked -= null;
                button.clicked += () => LoadScene(sceneNames[index]);
            }
        }
    }
}