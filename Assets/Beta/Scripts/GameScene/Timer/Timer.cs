using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// ŽžŠÔ‚ðŒv‚è•\Ž¦‚·‚é
/// </summary>
public class Timer : MonoBehaviour
{
    [Header("ŽQÆ")]
    [SerializeField] Text _timerText;

    float _time = 0;
    public float CurrentTime => _time;

    // Start is called before the first frame update
    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1))
            .Subscribe(_ => ShowTime())
            .AddTo(this.gameObject);
    }

    public (int min, int sec) CountTime()
    {
        _time++;
        var min = (int)_time / 60;
        var sec = (int)_time - min * 60;
        (int min, int sec) time = (min, sec);
        return time;
    }  

    void ShowTime()
    {
        var time = CountTime();
        _timerText.text = $"TIME {time.min:00}:{time.sec:00}";
    }
}
