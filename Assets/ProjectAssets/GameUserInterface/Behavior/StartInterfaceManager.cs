using ProjectAssets.Saves.Behavior;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class StartInterfaceManager : MonoBehaviour
    {
        [SerializeField] private Button _buttonExitGame;
        [SerializeField] private List _startList;
        [SerializeField] private ParamsSaves _saves;
        [SerializeField] private TMP_Text _stats;
        [SerializeField] private Transform _scrollView;
        [SerializeField] private LevelButton _levelButtonPrefab;

        private Button _buttonLoadLevel;
        
        private void OnEnable()
        {
            _buttonExitGame.onClick.AddListener(ExitGame);
            _startList.Open();
            _stats.text = (_saves.GetCurrentLevel() - 1).ToString();

            if (_saves.GetCurrentLevel() < 20)
            {
                for (int i = 0; i < 20; i++)
                {
                    var levelB = Instantiate(_levelButtonPrefab, _scrollView);
                    levelB.SetNumber(i+1);

                    if (i + 1 == _saves.GetCurrentLevel())
                    {
                        levelB.NotCompleted();
                        levelB.ButtonLevel.enabled = true;
                        levelB.Enable();
                        _buttonLoadLevel = levelB.ButtonLevel;
                    }
                    else if(i +1 < _saves.GetCurrentLevel())
                    {
                        levelB.Completed();
                        levelB.ButtonLevel.enabled = false;
                        levelB.Disable();
                    }
                    else
                    {
                        levelB.NotCompleted();
                        levelB.ButtonLevel.enabled = false;
                        levelB.Disable();
                    }
                }
            }
            else
            {
                for (int i = 0; i < _saves.GetCurrentLevel(); i++)
                {
                    var levelB = Instantiate(_levelButtonPrefab, _scrollView);
                    levelB.SetNumber(i+1);

                    if (i + 1 == _saves.GetCurrentLevel())
                    {
                        levelB.NotCompleted();
                        levelB.ButtonLevel.enabled = true;
                        levelB.Enable();
                        _buttonLoadLevel = levelB.ButtonLevel;
                        
                        var levelBmore = Instantiate(_levelButtonPrefab, _scrollView);
                        levelBmore.SetNumber(i+2);
                        levelBmore.NotCompleted();
                        levelBmore.ButtonLevel.enabled = false;
                        levelBmore.Disable();
                    }
                    else if(i +1 < _saves.GetCurrentLevel())
                    {
                        levelB.Completed();
                        levelB.ButtonLevel.enabled = false;
                        levelB.Disable();
                    }
                }
            }
            
            _buttonLoadLevel.onClick.AddListener(LoadLevel);
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
