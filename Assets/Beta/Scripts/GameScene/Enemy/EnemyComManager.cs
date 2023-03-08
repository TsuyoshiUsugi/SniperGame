using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyComManager : MonoBehaviour
{
    List<EnemyManager> _enemyList = new();

    [SerializeField] bool _debg;
    [SerializeField] ReactiveProperty<bool> _alert;
    public ReactiveProperty<bool> TuneOnAlert { get => _alert; set => _alert = value; }
    // Start is called before the first frame update
    void Start()
    {
        _enemyList.AddRange(FindObjectsOfType<EnemyManager>());
        _alert.Where(x => x == true).Subscribe(_ => Alert()).AddTo(this);
    }

    private void Update()
    {
        if(_debg)
        {
            Alert();
        }
    }

    public void Alert()
    {
        Debug.Log("Œx•ñ”­—ß");
        _enemyList.ForEach(enemy => enemy.CurrentState.Value = EnemyInfo.EnemyState.HighAlert);
    }
}
