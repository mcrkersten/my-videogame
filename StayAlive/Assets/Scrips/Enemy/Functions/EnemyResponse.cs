using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResponse : MonoBehaviour {
    private LineOfSight _lineOfSight;
    public bool moveAss;
    public bool suspicius;

    private void Start()
    {
        moveAss = false;
        suspicius = false;
        _lineOfSight = GetComponentInChildren<LineOfSight>();
    }


    void Update()
    {
        if (_lineOfSight.SeeByTag("Player"))
        {
            moveAss = true;
            suspicius = true;
            _lineOfSight.SetStatus(LineOfSight.Status.Alerted);
        }
        else
        {
            moveAss = false;
            if(suspicius == true)
            {
                _lineOfSight.SetStatus(LineOfSight.Status.Suspicious);
            }
            else
            {
                _lineOfSight.SetStatus(LineOfSight.Status.Idle);
            }         
        }
    }
}
