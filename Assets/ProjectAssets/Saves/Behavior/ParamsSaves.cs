using UnityEngine;

namespace ProjectAssets.Saves.Behavior
{
    public class ParamsSaves : MonoBehaviour
    {
        private string Level = nameof(Level);
        private string LastLevelIndex = nameof(LastLevelIndex);
        private string General = nameof(General);
        private string Music = nameof(Music);
        private string Tutorial = nameof(Tutorial);

        private const int FirstLevel = 1;
        private const float StartGenVolume = 1;
        private const float StartMusicVolume = 0.5f;
        private const string CheckMark = "V";

        public int GetCurrentLevel()
        {
            return PlayerPrefs.HasKey(Level) ? PlayerPrefs.GetInt(Level) : FirstLevel;
        }

        public void SetCurrentLevel(int curLvl) => PlayerPrefs.SetInt(Level, curLvl);

        public bool HasLastLevel()
        {
            return PlayerPrefs.HasKey(LastLevelIndex);
        }

        public void ClearLastLevel()
        {
            PlayerPrefs.DeleteKey(LastLevelIndex);
        }
        
        public int GetLastLevel()
        {
            return PlayerPrefs.GetInt(LastLevelIndex);
        }

        public void SetLastLevel(int lastLvl) => PlayerPrefs.SetInt(LastLevelIndex, lastLvl);

        public float GetGeneralVolume()
        {
            return PlayerPrefs.HasKey(General) ? PlayerPrefs.GetFloat(General) : StartGenVolume;
        }

        public void SetGeneralVolume(float volume) => PlayerPrefs.SetFloat(General, volume);


        public float GetMusicVolume()
        {
            return PlayerPrefs.HasKey(Music) ? PlayerPrefs.GetFloat(Music) : StartMusicVolume;
        }

        public void SetMusicVolume(float volume) => PlayerPrefs.SetFloat(Music, volume);

        public bool GetTutorialStatus()
        {
            return PlayerPrefs.HasKey(Tutorial);
        }

        public void SetTutorialStatus() => PlayerPrefs.SetString(Tutorial, CheckMark);
        
    }
}
