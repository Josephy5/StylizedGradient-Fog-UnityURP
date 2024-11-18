using UnityEngine;
using UnityEditor;

namespace LKHGames
{
    [CustomEditor(typeof(GradientGenerator))]
    public class GradientGenerator_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GradientGenerator gradientGenerator = (GradientGenerator)target;

            if (GUILayout.Button("Generate Gradient Texture"))
            {
                gradientGenerator.BakeGradientTexture();
                AssetDatabase.Refresh();
            }
        }
    }
}