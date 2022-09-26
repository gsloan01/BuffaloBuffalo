using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    public static DayNightSystem Instance { get; private set; }

    public enum eTimeOfDay
    {
        Morning, Afternoon, Night, None
    }

    public eTimeOfDay TimeOfDay;

    public TMP_Text dayTimeIndicator;

    public eTimeOfDay forceTime = eTimeOfDay.None;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (forceTime == eTimeOfDay.None)
        {
            TimeOfDay = (eTimeOfDay)Random.Range(0, 2);
        }
        else
        {
            TimeOfDay = forceTime;
        }
        EnemyTypeManager.Instance.DayTimeChanges(TimeOfDay);

        switch (TimeOfDay)
        {
            case eTimeOfDay.Morning:
                dayTimeIndicator.text = "Morning";
                break;
            case eTimeOfDay.Afternoon:
                dayTimeIndicator.text = "Afternoon";
                break;
            case eTimeOfDay.Night:
                dayTimeIndicator.text = "Night";
                break;
            default:
                break;
        }
    }




    public void PassTime()
    {
        switch (TimeOfDay)
        {
            case eTimeOfDay.Morning:
                TimeOfDay = eTimeOfDay.Afternoon;
                break;
            case eTimeOfDay.Afternoon:
                TimeOfDay = eTimeOfDay.Night;
                break;
            case eTimeOfDay.Night:
                TimeOfDay = eTimeOfDay.Morning;
                break;
            default:
                break;
        }
    }
}
