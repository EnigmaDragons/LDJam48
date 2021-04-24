using UnityEngine;

namespace Tags
{
    [CreateAssetMenu(fileName = "new tag", menuName = "Dialogue/Tag")]
    public class TagObject : ScriptableObject
    {
        [SerializeField] private string name;

        /// <summary>
        /// Checks if other tag conflicts with this one
        /// </summary>
        /// <returns></returns>
        public bool Conflicts(TagObject otherTag)
        {
            return ConflictDatabase.Conflicts(this, otherTag);
        }

        public int GetConflictPenalty(TagObject otherTag)
        {
            return ConflictDatabase.GetPenalty(this, otherTag);
        }
        
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
