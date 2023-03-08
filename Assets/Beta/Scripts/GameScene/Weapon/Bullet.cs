using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾丸の挙動用のコンポーネント
/// 当たるか時間で消滅する
/// 
/// </summary>
public class Bullet : MonoBehaviour
{
    [Header("設定値")]
    [SerializeField] protected float _damage;
    [SerializeField] protected float _deleteTime = 5;
    protected Vector3 _current;
    protected Vector3 _previous;

    void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        _current = transform.position;
        _previous = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _current = transform.position;
        Hit();
        _previous = _current;

        DeleteTimer();
    }

    /// <summary>
    /// 消滅するまでの時間を計測する
    /// </summary>
    protected void DeleteTimer()
    {
        _deleteTime -= Time.deltaTime;

        if (_deleteTime < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Hit()
    {
        Vector3 rayPosition = _previous;
        var dir = _current - _previous;
        Ray ray = new Ray(rayPosition, dir.normalized);
        Debug.DrawRay(ray.origin, dir.normalized, Color.red, 10, false);

        //敵に衝突したときの処理
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dir.magnitude))
        {
            hit.collider.GetComponentInParent<EnemyManager>()?.Hit(_damage);
            Destroy(this.gameObject);
        }
    }
}
