using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using EnemyInfo;

[System.Serializable]
public class EnemyStateReactiveProperty : ReactiveProperty<EnemyState>
{
    public EnemyStateReactiveProperty() { }
    public EnemyStateReactiveProperty(EnemyState enemyState) : base(enemyState) { }

}
