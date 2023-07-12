using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Buttons
{
    [RequireComponent(typeof(Button))]
    public class StartGame : MonoBehaviour
    {
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClickStartGame);
        }

        public void OnClickStartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
