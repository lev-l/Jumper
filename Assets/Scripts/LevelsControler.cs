using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelsControler : MonoBehaviour
{
    public string SaveFileName;
    public LoadingPosition StartPosition;
    private LevelsControl _levels;
    private string _path;

    private void Start()
    {
        _path = "./Assets/Resourses/" + SaveFileName + ".json";

        _levels = (LevelsControl)JsonUtility.FromJson
                                                (
                                                File.ReadAllText(_path),
                                                typeof(LevelsControl)
                                                );
        _levels.OpenedLevels.Add(SceneManager.GetActiveScene().name);
        File.WriteAllText(_path, JsonUtility.ToJson(_levels));

        GameObject.FindGameObjectWithTag("Player").transform.position = StartPosition.LoadPosition;
    }
}
