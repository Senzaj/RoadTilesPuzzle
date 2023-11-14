using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class LevelInterfaceManager : MonoBehaviour
    {
        [SerializeField] private Button[] _buttonsLoadLevel;
        [SerializeField] private Button[] _buttonsExitLevel;
        [SerializeField] private List _gameList;
        [SerializeField] private List _levelCompleteList;
        [SerializeField] private TMP_Text _levelNumber;
        [SerializeField] private List _tutorial;

        private void OnEnable()
        {
            foreach (var b in _buttonsLoadLevel)
                b.onClick.AddListener(LoadLevel);
            
            foreach (var b in _buttonsExitLevel)
                b.onClick.AddListener(ExitLevel);
        }

        private void OnDisable()
        {
            foreach (var b in _buttonsLoadLevel)
                b.onClick.RemoveListener(LoadLevel);
            
            foreach (var b in _buttonsExitLevel)
                b.onClick.RemoveListener(ExitLevel);
        }

        public void OpenTutorial()
        {
            _tutorial.Open();
        }

        public void OpenLevelCompleteList(int lvlNum)
        {
            _levelNumber.text = lvlNum.ToString();
            _levelCompleteList.Open();
        }
        
        public void CloseGameList()
        {
            _gameList.Close();
        }

        public void OpenGameList()
        {
            _gameList.Open();
        }
        
        private void LoadLevel() => SceneManager.LoadScene("Level");
        
        private void ExitLevel() => SceneManager.LoadScene("Start");
    }
}
