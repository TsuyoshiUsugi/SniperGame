using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �V�[���ڍs���Ƀt�F�[�h�C���ƃA�E�g���s��
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
        //�t�F�[�h�A�E�g
        _blackScreen.DOFade(1, _fadeTime).OnComplete(() => _blackScreen.DOFade(0, _fadeTime));
    }
}
