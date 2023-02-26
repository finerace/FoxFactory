using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsQualityService : MonoBehaviour
{


    public void SetSettingsQuality(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }
    
    
}
