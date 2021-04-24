using UnityEngine;

namespace Tags
{
    [CreateAssetMenu(fileName = "new tag", menuName = "Dialogue/Tag")]
    public class TagObject : ScriptableObject
    {
        [SerializeField] private string name;

        public string GetName()
        {
            return name;
        }
        
        public override bool Equals(object other)
        {
            if (!(other is TagObject)) return false;
            var tag = other as TagObject;
            return tag.GetName() == name;
        }
    }
}
