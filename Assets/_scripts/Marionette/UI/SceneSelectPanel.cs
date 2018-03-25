using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace Marionette.UI
{
    public class SceneSelectPanel : MonoBehaviour
    {
        [SerializeField]
        string[] sceneNames = null;

        [SerializeField]
        Button buttonPrefab = null;

        public void ToggleEnabled()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        void Start()
        {
            foreach (string scene_name in sceneNames) {
                var button = Instantiate(buttonPrefab, gameObject.transform);
                button.GetComponentInChildren<Text>().text = scene_name;
                AddHandler(button, scene_name);
            }
        }

        void AddHandler(Button button, string scene_name)
        {
            button.onClick.AddListener(() => SceneManager.LoadScene(scene_name));
        }
    }
}
