using UnityEngine;

public class LightingReset : MonoBehaviour
{
    void Start()
    {
        // 1. Reset Skybox to default
        RenderSettings.skybox = Resources.Load<Material>("Skybox/Default");

        // 2. Set ambient light to a light gray
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        RenderSettings.ambientLight = Color.gray;

        // 3. Add a Directional Light if none exists
        if (FindObjectOfType<Light>() == null)
        {
            GameObject lightObj = new GameObject("Directional Light");
            Light lightComp = lightObj.AddComponent<Light>();
            lightComp.type = LightType.Directional;
            lightComp.color = Color.white;
            lightComp.intensity = 1f;
            lightObj.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        }

        Debug.Log("Lighting has been reset!");
    }
}
