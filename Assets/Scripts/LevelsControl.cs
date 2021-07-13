using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization;

[DataContract]
public class LevelsControl
{
    [DataMember]
    public List<string> OpenedLevels;
    [DataMember]
    public string CurrentLevel;

    public LevelsControl()
    {
        OpenedLevels = new List<string>(5);
        CurrentLevel = SceneManager.GetActiveScene().name;
    }

    public bool OpenLevel(string level)
    {
        if (OpenedLevels.Contains(level))
        {
            return false;
        }
        else
        {
            OpenedLevels.Add(level);
            return true;
        }
    }
}
