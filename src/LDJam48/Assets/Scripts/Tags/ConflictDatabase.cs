using System;
using System.Collections.Generic;
using System.Linq;
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
            [SerializeField] private TagObject[] tags;
            [SerializeField] private int penalty;

            private HashSet<TagObject> _hashed = new HashSet<TagObject>();

            public bool TagConflicts(TagObject tg1, TagObject tg2)
            {
                if (_hashed.None())
                    _hashed = new HashSet<TagObject>(tags);
                return _hashed.Contains(tg1) && _hashed.Contains(tg2);
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
                if (conflict.TagConflicts(tag1, tag2)) return true;
            }

            return false;
        }

        public static int GetPenalty(TagObject tag1, TagObject tag2)
        {
            var confs = instance.conflicts;
            foreach (var conflict in confs)
            {
                if (conflict.TagConflicts(tag1,tag2)) return conflict.GetPenalty();
            }

            return 0;
        }
    }
}
