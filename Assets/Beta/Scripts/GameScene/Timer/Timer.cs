using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 時間を計り表示する
/// </summary>
public class Timer : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] Text _timerText;

    float _time = 0;
    public float CurrentTime => _time;

    // Start is called before the first frame update
    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1))
            .Subscribe(_ => CountTime())
            .AddTo(this.gameObject);
    }

    void CountTime()
    {
        _time++;
        var min = (int)_time / 60;
        var sec = _time - min * 60;
        _timerText.text = $"TIME {min:00}:{sec:00}";
    }  
}
