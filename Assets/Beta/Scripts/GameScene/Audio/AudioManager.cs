using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonMonobehavior<AudioManager>
{
    [Header("éQè∆")]
    [SerializeField] List<AudioSource> _BgmPrefab;
    [SerializeField] string _titleSceneName;
    [SerializeField] string _MenuSceneName;
    [SerializeField] string _MissionSelectSceneName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == _titleSceneName || scene.name == _MenuSceneName || scene.name == _MissionSelectSceneName)
        {
            _BgmPrefab[1].Stop();
            if (!_BgmPrefab[0].isPlaying) _BgmPrefab[0].Play();
        }
        else
        {
            _BgmPrefab[0].Stop();
            if (!_BgmPrefab[1].isPlaying) _BgmPrefab[1].Play();
        }
    }

}
