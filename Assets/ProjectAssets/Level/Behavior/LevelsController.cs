using System.Collections;
using ProjectAssets.Car.Behavior;
using ProjectAssets.GameUserInterface.Behavior;
using ProjectAssets.Saves.Behavior;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.Level.Behavior
{
    public class LevelsController : MonoBehaviour
    {
        [SerializeField] private CarMover[] _prefabs;
        [SerializeField] private LevelData[] _startLevelsPrefabs;
        [SerializeField] private LevelData[] _mainLevelsPrefabs;
        [SerializeField] private InputController _inputController;
        [SerializeField] private ParamsSaves _saves;
        [SerializeField] private Stopwatch _stopwatch;
        [SerializeField] private LevelInterfaceManager _interface;
        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonStopPlay;
        [SerializeField] private Button _buttonTutorial;

        private CarMover _car;
        private LevelData _currentLevel;
        private int _levelNumber;

        private bool _isLevelComplete;
        
        private void OnEnable()
        {
            //PlayerPrefs.DeleteAll();
            
            _isLevelComplete = false;
            _levelNumber = _saves.GetCurrentLevel();
            int levelIndex = _levelNumber - 1;

            _car = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);

            if (levelIndex < _startLevelsPrefabs.Length)
                LoadStartLevel();
            else
                LoadMainLevel();

            _buttonPlay.onClick.AddListener(Play);
            _buttonStopPlay.onClick.AddListener(StopPlay);
            _buttonTutorial.onClick.AddListener(Tutorial1Complete);
        }

        private void OnDisable()
        {
            _currentLevel.Complete -= OnComplete;
            _buttonPlay.onClick.RemoveListener(Play);
            _buttonStopPlay.onClick.RemoveListener(StopPlay);
            _buttonTutorial.onClick.RemoveListener(Tutorial1Complete);
        }
        
         private void LoadStartLevel()
        {
            int levelIndex = _levelNumber - 1;
            _currentLevel = Instantiate(_startLevelsPrefabs[levelIndex], transform.position, Quaternion.identity);
            _currentLevel.SetData(_inputController, _car);
            _currentLevel.Complete += OnComplete;

            switch (_levelNumber)
            {
                case 1:
                    if (_saves.GetTutorialStatus() == false)
                        _interface.OpenTutorial();
                    else
                    {
                        _interface.OpenGameList();
                        _stopwatch.Play();
                    }
                    break;

                default:
                    _interface.OpenGameList();
                    _stopwatch.Play();
                    break;
            }
        }

        private void LoadMainLevel()
        {
            if (_saves.HasLastLevel())
            {
                int levelIndex = _saves.GetLastLevel();
                _currentLevel = Instantiate(_mainLevelsPrefabs[levelIndex], transform.position, Quaternion.identity);
                _currentLevel.SetData(_inputController, _car);
                _interface.OpenGameList();
                _stopwatch.Play();
                _currentLevel.Complete += OnComplete;
            }
            else
            {
                int levelIndex = Random.Range(0, _mainLevelsPrefabs.Length);
                _saves.SetLastLevel(levelIndex);
                _currentLevel = Instantiate(_mainLevelsPrefabs[levelIndex], transform.position, Quaternion.identity);
                _currentLevel.SetData(_inputController, _car);
                _interface.OpenGameList();
                _stopwatch.Play();
                _currentLevel.Complete += OnComplete;
            }
        }

        private void OnComplete()
        {
            if (_isLevelComplete == false)
            {
                _isLevelComplete = true;
                _stopwatch.Stop();
                
                if (_saves.HasLastLevel())
                    _saves.ClearLastLevel();
                
                _interface.CloseGameList();
                _levelNumber++;
                _saves.SetCurrentLevel(_levelNumber);
                StartCoroutine(ShowResult());
            }
        }

        private IEnumerator ShowResult()
        {
            yield return new WaitForSeconds(0.5f);
            _interface.OpenLevelCompleteList(_levelNumber - 1);
        }

        private void Play()
        {
            _inputController.CanPlay = true;
            _stopwatch.Play();
        }
        
        private void StopPlay()
        {
            _inputController.CanPlay = false;
            _stopwatch.Stop();
        }
        
        private void Tutorial1Complete()
        {
            _saves.SetTutorialStatus();
            _interface.OpenGameList();
            _stopwatch.Play();
        }
    }
}
