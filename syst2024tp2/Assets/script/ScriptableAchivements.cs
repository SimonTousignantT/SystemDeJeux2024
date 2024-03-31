using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableAchivements : ScriptableObject
{
    [System.Serializable]
    // Start is called before the first frame update
    public struct archivements
    {
        public string Name;
        public string Description;
    }
    public List<archivements> m_archivements = new List<archivements>();

  


}
