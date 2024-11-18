using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MultiColorFogRenderFeature : ScriptableRendererFeature
{
    //initialzing the render feature settings
    [System.Serializable]
    public class Settings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingSkybox;
        //the material that contains the hatching effect's shader, user must put in manually for now
        public Material material;
        //having the fog on can be annoying, so by default its off, you can turn it on if you want it on
        public bool showInSceneView = false;
    }
    public Settings settings = new Settings();

    MultiColorFogPass m_MultiColorFogPass;

    //get zoom shader
    private void OnEnable()
    {
        //settings.material = Resources.Load<Material>("/Mat_MultiColorFog");
    }

    //sets the zoom's render pass up
    public override void Create()
    {
        this.name = "MultiColor Fog Pass";
        if (settings.material == null)
        {
            Debug.LogWarning("No Multicolor Fog Material, Please input a material that has the Multicolor Fog shader into the Multicolor Fog's render feature setting");
            return;
        }
        m_MultiColorFogPass = new MultiColorFogPass(settings.renderPassEvent, settings.material, settings.showInSceneView);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_MultiColorFogPass);
    }
    //setups the pass with the correct camera target at that period in the render pipline
    //this is only exclusive for this effect, due to how its code/logic works
    public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
    {
        m_MultiColorFogPass.Setup(renderer);
    }
}