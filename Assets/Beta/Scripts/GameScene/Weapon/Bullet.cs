using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�ۂ̋����p�̃R���|�[�l���g
/// �����邩���Ԃŏ��ł���
/// 
/// </summary>
public class Bullet : MonoBehaviour
{
    [Header("�ݒ�l")]
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
    /// ���ł���܂ł̎��Ԃ��v������
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

        //�G�ɏՓ˂����Ƃ��̏���
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dir.magnitude))
        {
            hit.collider.GetComponentInParent<EnemyManager>()?.Hit(_damage);
            Destroy(this.gameObject);
        }
    }
}
