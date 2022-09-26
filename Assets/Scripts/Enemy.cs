using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;

    [SerializeField] MeshRenderer skin;

    public void Init(EnemyType type)
    {
        this.type = type;
        skin.material.color = type.color;
    }
}
