using UnityEngine;
using UnityEditor;

public class ResetLightingEditor : EditorWindow
{
    [MenuItem("Tools/Reset Scene Lighting")]
    public static void ResetLighting()
    {
        // Reset Skybox
        RenderSettings.skybox = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Skybox.mat");
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;

        // Add Directional Light if none exists
        if (FindObjectOfType<Light>() == null)
        {
            GameObject lightGO = new GameObject("Directional Light");
            Light light = lightGO.AddComponent<Light>();
            light.type = LightType.Directional;
            light.intensity = 1f;
            light.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        }

        Debug.Log("✅ Lighting and Skybox reset!");
    }
}
