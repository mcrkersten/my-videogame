using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [HideInInspector]
    public string levelName = "StartLayer";

    public string dungeonName;
    public int GateNumber;
    public int levelLength;
}
