using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ScriptableText : ScriptableObject
{
    [System.Serializable]
    // Start is called before the first frame update
   public struct PageData
    {
        public string page;
    }
    public List<PageData> DataPage = new List<PageData>();
    public string LvlName;
}
