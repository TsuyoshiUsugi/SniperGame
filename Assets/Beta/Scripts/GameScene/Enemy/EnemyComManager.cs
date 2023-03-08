using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComManager : MonoBehaviour
{
    List<EnemyManager> _enemyList = new();

    [SerializeField] bool _debg;
    // Start is called before the first frame update
    void Start()
    {
        _enemyList.AddRange(FindObjectsOfType<EnemyManager>());
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
        _enemyList.ForEach(enemy => enemy.CurrentState.Value = EnemyInfo.EnemyState.HighAlert);
    }
}
