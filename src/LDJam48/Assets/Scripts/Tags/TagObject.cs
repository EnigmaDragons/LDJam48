using UnityEngine;

namespace Tags
{
    [CreateAssetMenu(fileName = "new tag", menuName = "Dialogue/Tag")]
    public class TagObject : ScriptableObject
    {
        public string GetName() => name;

        public override bool Equals(object other)
        {
            if (!(other is TagObject)) return false;
            var tag = other as TagObject;
            return tag.GetName() == name;
        }
    }
}
