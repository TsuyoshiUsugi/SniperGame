using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// シーン移行時にフェードインとアウトを行う
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image _blackScreen;
    float _fadeTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    void OnActiveSceneChanged(Scene preScene, Scene nextScene)
    {
        //フェードアウト
        _blackScreen.DOFade(1, _fadeTime).OnComplete(() => _blackScreen.DOFade(0, _fadeTime));
    }
}
