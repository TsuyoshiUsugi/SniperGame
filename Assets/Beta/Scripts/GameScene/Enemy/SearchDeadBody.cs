using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchDeadBody : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<EnemyManager>()?.CurrentState.Value == EnemyInfo.EnemyState.Death)
        {
            Debug.Log("Ž‹ŠE‚É“ü‚Á‚½");
            Detect();
        }
    }

    void Detect()
    {
        FindObjectOfType<EnemyComManager>().Alert();
        Destroy(this.gameObject);
    }
}
