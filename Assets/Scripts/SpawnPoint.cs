using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;

    [SerializeField] EnemyType typeRestriction = null;
    [SerializeField] EnemyType.eClass classRestriction = EnemyType.eClass.None;

    GameObject enemySpawned;
    // Start is called before the first frame update

    void Start()
    {
        enemySpawned = SpawnEnemy();
    }

    EnemyType GetRandomEnemyType()
    {
        EnemyType type = null;
        float ratioTotal = 0;
        if(classRestriction == EnemyType.eClass.None)
        {
            EnemyTypeManager.Instance.UpdatedEnemyTypes.Where(x => x.enemyClass != classRestriction).ToList().ForEach(x => ratioTotal += x.spawnRate);
            float roll = Random.Range(0, ratioTotal);

            foreach (var enemyType in EnemyTypeManager.Instance.UpdatedEnemyTypes.Where(x => x.enemyClass != classRestriction))
            {
                if (roll <= enemyType.spawnRate)
                {
                    type = enemyType;
                    break;
                }
                else roll -= enemyType.spawnRate;
            }
        }
        else
        {
            EnemyTypeManager.Instance.UpdatedEnemyTypes.Where(x => x.enemyClass == classRestriction).ToList().ForEach(x => ratioTotal += x.spawnRate);
            float roll = Random.Range(0, ratioTotal);

            foreach (var enemyType in EnemyTypeManager.Instance.UpdatedEnemyTypes.Where(x => x.enemyClass == classRestriction))
            {
                if (roll <= enemyType.spawnRate)
                {
                    type = enemyType;
                    break;
                }
                else roll -= enemyType.spawnRate;
            }
        }

        

        return type;
    }
    GameObject SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab, this.transform);
        if (typeRestriction != null) enemy.Init(typeRestriction);
        else
        {
            enemy.Init(GetRandomEnemyType());
        }

        Debug.Log($"{name} just spawned a {enemy.type.eColorType} {enemy.type.enemyClass}");
        return enemy.gameObject;
    }
    public void Reset()
    {
        Destroy(enemySpawned);
        enemySpawned = SpawnEnemy();
    }



}
