using TMPro;
using UnityEngine;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class Stopwatch : MonoBehaviour
    {
        [SerializeField] private TMP_Text _stopwatchT;

        private float _time;
        private bool _stop;

        private void Awake()
        {
            _time = 0.7f;
            Stop();
        }
        
        private void Update()
        {
            if (_stop) return;
            
            _time += Time.deltaTime;
            WriteDownTime(_time);
        }
        
        public void Stop() => _stop = true;
        
        public void Play() => _stop = false;

        private void WriteDownTime(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            _stopwatchT.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
