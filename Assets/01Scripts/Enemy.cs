using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHP;
    int curHP;

    private void Start()
    {
        curHP = MaxHP;
    }

    public void GetDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
