using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MultiColorFogPass : ScriptableRenderPass
{
    static readonly string renderPassTag = "MultiColor Fog";

    //volume for the fog effect
    private MultiColorFogVolume FogVolume;
    //material containing the shader
    private Material FogMaterial;

    //RTHandles
    RTHandle source;

    //If user wants the fog to be viewable in scene view
    bool showInSceneView = false;

    //initializes our variables
    public MultiColorFogPass(RenderPassEvent evt, Material mat, bool val)
    {
        renderPassEvent = evt;
        if (mat == null)
        {
            Debug.LogError("No Shader");
            return;
        }
        //to make profiling easier
        profilingSampler = new ProfilingSampler(renderPassTag);
        FogMaterial = mat;
        showInSceneView = val;
    }
    //where our rendering of the effect starts
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (FogMaterial == null)
        {
            Debug.LogError("No MultiColor Fog Material/Shader");
            return;
        }

        //in case if the camera doesn't have the post process option enabled, if the camera is not the game's camera, and if we don't want it to be rendered in sceneview at the moment
        if (!renderingData.cameraData.postProcessEnabled)
        {
            return;
        }

        if (renderingData.cameraData.cameraType != CameraType.Game && (showInSceneView == false && renderingData.cameraData.cameraType == CameraType.SceneView))
        {
            return;
        }

        VolumeStack stack = VolumeManager.instance.stack;
        FogVolume = stack.GetComponent<MultiColorFogVolume>();

        var cmd = CommandBufferPool.Get(renderPassTag);
        Render(cmd, ref renderingData);

        context.ExecuteCommandBuffer(cmd);
        cmd.Clear();

        CommandBufferPool.Release(cmd);
    }
    //helper method to contain all of our rendering code for the Execute() method
    void Render(CommandBuffer cmd, ref RenderingData renderingData)
    {
        if (FogVolume.IsActive() == false) return;
        FogVolume.load(FogMaterial, ref renderingData);

        //for profiling
        using (new ProfilingScope(cmd, profilingSampler))
        {
            //actual rendering code
            int width = renderingData.cameraData.cameraTargetDescriptor.width;
            int height = renderingData.cameraData.cameraTargetDescriptor.height;

            var tempColorTexture = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32);

            cmd.Blit(source, tempColorTexture, FogMaterial, 0);
            cmd.Blit(tempColorTexture, source);

            RenderTexture.ReleaseTemporary(tempColorTexture);
        }
    }

    //sets up the camera color targets to our scripts's private variables of the camera targets
    public void Setup(ScriptableRenderer renderer)
    {
        source = renderer.cameraColorTargetHandle; //source
    }
}