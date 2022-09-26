using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "EnemyType")]
public class EnemyType : ScriptableObject
{
    public enum eClass
    {
        None, Grunt, Archer, Assassin
    }

    public enum eColor
    {
        Red, Brown, Green, Blue, Yellow
    }
    public eColor eColorType = EnemyType.eColor.Red;
    public Color color;
    public eClass enemyClass = eClass.None;
    public float attackPower = 0;
    public float health = 1;
    public float speed = 1;

    /// <summary>
    /// Probability of being chosen to spawn at a spawn point
    /// </summary>
    public float spawnRate = 1;

    public EnemyType(EnemyType eT)
    {
        eColorType = eT.eColorType;
        color = eT.color;
        enemyClass = eT.enemyClass;
        attackPower = eT.attackPower;
        health = eT.health;
        speed = eT.speed;
        spawnRate = eT.spawnRate;
    }

}
