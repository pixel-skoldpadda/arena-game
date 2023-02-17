using System.Linq;
using Items;
using Spawner;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Spawners))]
    public class SpawnersEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Spawners spawners = (Spawners) target;
            if (GUILayout.Button("Init"))
            {
                spawners.SpawnersData = FindObjectsOfType<SpawnerMarker>().
                    Select(x => new SpawnerData(x.EnemyType, x.Amount, x.Cooldown, x.gameObject.transform.position)).
                    ToList();
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}