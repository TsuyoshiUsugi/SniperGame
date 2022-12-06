using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] TitleView _titleView;
    [SerializeField] TitleManager _titleManager;
    // Start is called before the first frame update
    void Start()
    {
        _titleView.OnStartButtonClicked += () =>_titleManager.LoadMenuScene();
    }

}
