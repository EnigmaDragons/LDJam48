using System;
using UnityEditor;
using UnityEngine;

namespace Tags
{
    public class ConflictDatabase : ScriptableSingleton<ConflictDatabase>
    {
        [Serializable]
        private class ConflictEntry
        {
            [SerializeField] private string name;
            [SerializeField] private TagObject tag1;
            [SerializeField] private TagObject tag2;
            [SerializeField] private int penalty;

            public bool TagConflicts(TagObject tag)
            {
                if (tag1 == tag || tag2 == tag) return true;
                return false;
            }

            public int GetPenalty()
            {
                return penalty;
            }
        }

        [SerializeField] private ConflictEntry[] conflicts;

        public static bool Conflicts(TagObject tag1, TagObject tag2)
        {
            var confs = instance.conflicts;
            foreach (var conflict in confs)
            {
                if (conflict.TagConflicts(tag1) || conflict.TagConflicts(tag2)) return true;
            }

            return false;
        }

        public static int GetPenalty(TagObject tag1, TagObject tag2)
        {
            var confs = instance.conflicts;
            foreach (var conflict in confs)
            {
                if (conflict.TagConflicts(tag1) || conflict.TagConflicts(tag2)) return conflict.GetPenalty();
            }

            return 0;
        }
        
    }

    
}
