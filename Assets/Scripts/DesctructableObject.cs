using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesctructableObject : MonoBehaviour, IDamageble
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().CheckDrop();
    }
}
