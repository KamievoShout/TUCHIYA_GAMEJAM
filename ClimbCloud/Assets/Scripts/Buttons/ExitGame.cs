using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class ExitGame : MonoBehaviour
    {
        private bool _isButton;

        private void Start()
        {
            if(TryGetComponent(out Button button))
            {
                button = GetComponent<Button>();

                button.onClick.AddListener(OnClickExitButton);

                _isButton = true;
            }
        }

        // ÉQÅ[ÉÄèIóπèàóù
        public void OnClickExitButton()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        private void Update()
        {
            if (_isButton) { return; }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif

            }
        }
    }
}
