using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ReplaceDumbCharacters
    {
        [MenuItem("EnigmaDragon/Replace Dumb Character In Cutscenes And Conversations")]
        public static void DoTheReplacement()
        {
            foreach (var cutscene in GetAllInstances<Cutscene>())
            {
                foreach (var segment in cutscene.Segments ?? new CutsceneSegment[0])
                {
                    var newStoryText = Replace(segment.storyText);
                    if (newStoryText != segment.storyText)
                    {
                        segment.storyText = newStoryText;
                        EditorUtility.SetDirty(cutscene);
                    }
                }
            }

            foreach (var conversation in GetAllInstances<Conversation>())
            {
                foreach (var data in conversation.Sequence ?? new DialogueData[0])
                {
                    var newStatementText = Replace(data.statement);
                    if (newStatementText != data.statement)
                    {
                        data.statement = newStatementText;
                        EditorUtility.SetDirty(conversation);
                    }
                    foreach (var option in data?.options ?? new DialogueOption[0])
                    {
                        var newOptionText = Replace(option.text);
                        if (newOptionText != option.text)
                        {
                            option.text = newOptionText;
                            EditorUtility.SetDirty(conversation);
                        }
                        foreach (var followup in option?.Followups ?? new FollowupDialogueData[0])
                        {
                            var newFollowup = Replace(followup.statement);
                            if (newFollowup != followup.statement)
                            {
                                followup.statement = newFollowup;
                                EditorUtility.SetDirty(conversation);
                            }
                        }
                    }
                }
            }
        }
        
        private static string Replace(string value) => value.Replace('‘', '\'').Replace('”', '"').Replace('ō', 'o');
        
        public static List<T> GetAllInstances<T>() where T : ScriptableObject 
            => AssetDatabase.FindAssets("t:" + typeof(T).Name)
                .Select(x => AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(x))).ToList();
    }
}