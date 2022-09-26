using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static DayNightSystem;
using System.Linq;

public class EnemyTypeManager : MonoBehaviour
{
    //Use this to keep track of enemy SO's
    public static EnemyTypeManager Instance { get; private set; }
    public List<EnemyType> EnemyTypes = new List<EnemyType>();
    public List<EnemyType> UpdatedEnemyTypes { get; private set; } = new List<EnemyType>();


    private void Awake()
    {
        Instance = this;

    }
    private void OnEnable()
    {
        UpdatedEnemyTypes.Clear();
        EnemyTypes.ForEach(x => UpdatedEnemyTypes.Add(new EnemyType(x)));
    }
    public void DayTimeChanges(DayNightSystem.eTimeOfDay timeOfDay)
    {
        switch (timeOfDay)
        {
            case eTimeOfDay.Morning:
                //dayTimeIndicator.text = "Morning";
                UpdatedEnemyTypes.Where(x => x.enemyClass == EnemyType.eClass.Archer).ToList().ForEach(x => x.spawnRate += Random.Range(0.2f, 0.4f));
                UpdatedEnemyTypes.Where(x => x.eColorType == EnemyType.eColor.Brown).ToList().ForEach(x => x.spawnRate -= Random.Range(0.1f, 0.3f));
                break;
            case eTimeOfDay.Afternoon:
                //dayTimeIndicator.text = "Afternoon";
                UpdatedEnemyTypes.Where(x => x.enemyClass == EnemyType.eClass.Assassin).ToList().ForEach(x => x.spawnRate = 0);
                UpdatedEnemyTypes.Where(x => x.enemyClass == EnemyType.eClass.Grunt).ToList().ForEach(x => x.attackPower += 1);
                UpdatedEnemyTypes.Where(x => x.enemyClass == EnemyType.eClass.Archer).ToList().ForEach(x => x.spawnRate += Random.Range(-0.2f, 0.2f));
                break;
            case eTimeOfDay.Night:
                //dayTimeIndicator.text = "Night";
                UpdatedEnemyTypes.Where(x => x.enemyClass == EnemyType.eClass.Assassin).ToList().ForEach(x => x.speed += Random.Range(0f, 2f));
                break;
            default:
                break;
        }
    }
}
