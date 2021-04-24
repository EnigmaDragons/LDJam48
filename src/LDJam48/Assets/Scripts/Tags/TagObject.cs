using UnityEngine;

namespace Tags
{
    [CreateAssetMenu(fileName = "new tag", menuName = "Dialogue/Tag")]
    public class TagObject : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private TagObject[] conflictingTags;


        /// <summary>
        /// Checks if other tag conflicts with this one
        /// </summary>
        /// <returns></returns>
        public bool Conflicts(TagObject otherTag)
        {
            if (otherTag == this) return false;

            foreach (var tag in conflictingTags)
            {
                if (tag == otherTag) return true;
            }

            return false;
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
