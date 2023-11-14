using ProjectAssets.Saves.Behavior;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class StartInterfaceManager : MonoBehaviour
    {
        [SerializeField] private Button _buttonLoadLevel;
        [SerializeField] private Button _buttonExitGame;
        [SerializeField] private List _startList;
        [SerializeField] private ParamsSaves _saves;
        [SerializeField] private TMP_Text _stats;

        private void OnEnable()
        {
            _buttonLoadLevel.onClick.AddListener(LoadLevel);
            _buttonExitGame.onClick.AddListener(ExitGame);
            _startList.Open();
            _stats.text = (_saves.GetCurrentLevel() - 1).ToString();
        }

        private void OnDisable()
        {
            _buttonLoadLevel.onClick.RemoveListener(LoadLevel);
            _buttonExitGame.onClick.RemoveListener(ExitGame);
        }

        private void LoadLevel() => SceneManager.LoadScene("Level");
        
        private void ExitGame() => Application.Quit();
    }
}
