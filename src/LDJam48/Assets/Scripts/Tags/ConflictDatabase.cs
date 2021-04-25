using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tags
{
    [CreateAssetMenu(menuName = "Only Once/Conflict Database")]
    public class ConflictDatabase : ScriptableObject
    {
        [Serializable]
        private class ConflictEntry
        {
            [SerializeField] private string name;
            [SerializeField] private int penalty;
            [SerializeField] private TagObject[] tags;

            private HashSet<TagObject> _hashed = new HashSet<TagObject>();

            public bool TagConflicts(TagObject tg1, TagObject tg2)
            {
                if (_hashed.None())
                    _hashed = new HashSet<TagObject>(tags);
                return tg1 != tg2 && _hashed.Contains(tg1) && _hashed.Contains(tg2);
            }

            public int GetPenalty()
            {
                return penalty;
            }
        }

        [SerializeField] private ConflictEntry[] conflicts;

        public bool Conflicts(TagObject tag1, TagObject tag2)
        {
            foreach (var conflict in conflicts)
            {
                if (conflict.TagConflicts(tag1, tag2)) return true;
            }

            return false;
        }

        public int GetPenalty(TagObject tag1, TagObject tag2)
        {
            foreach (var conflict in conflicts)
            {
                if (conflict.TagConflicts(tag1,tag2)) return conflict.GetPenalty();
            }

            return 0;
        }
    }
}
