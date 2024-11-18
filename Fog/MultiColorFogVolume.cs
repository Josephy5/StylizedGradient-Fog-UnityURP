using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable, VolumeComponentMenu("MultiColor Fog")]
public class MultiColorFogVolume : VolumeComponent, IPostProcessComponent
{
    public ColorParameter _CloseFogColor = new ColorParameter(Color.green, true);
    public FloatParameter _CloseFogDistance = new FloatParameter(15f, true);
    public ColorParameter _CloseMidFogColor = new ColorParameter(Color.blue, true);
    public FloatParameter _CloseMidFogDistance = new FloatParameter(25f, true);
    public ColorParameter _MidFogColor = new ColorParameter(Color.magenta, true);
    public FloatParameter _MidFogDistance = new FloatParameter(50f, true);
    public ColorParameter _MidFarFogColor = new ColorParameter(Color.red, true);
    public FloatParameter _MidFarFogDistance = new FloatParameter(100f, true);
    public ColorParameter _FarFogColor = new ColorParameter(Color.yellow, true);
    public FloatParameter _FarFogDistance = new FloatParameter(150f, true);
    public Texture2DParameter _GradientTexture = new Texture2DParameter(null, true);
    public BoolParameter _UseGradientTexture = new BoolParameter(false, true);
    public ClampedFloatParameter _FogIntensity = new ClampedFloatParameter(1f, 0f, 3f, true);
    public ClampedFloatParameter _ExtraCloseFogIntensity = new ClampedFloatParameter(0f, 0f, 10f, true);
    public ClampedFloatParameter _ExtraCloseMidFogIntensity = new ClampedFloatParameter(0f, 0f, 10f, true);
    public ClampedFloatParameter _ExtraMidFogIntensity = new ClampedFloatParameter(0f, 0f, 10f, true);
    public ClampedFloatParameter _ExtraMidFarFogIntensity = new ClampedFloatParameter(0.5f, 0f, 10f, true);
    public ClampedFloatParameter _ExtraFarFogIntensity = new ClampedFloatParameter(2f, 0f, 10f, true);
    public FloatParameter _HueShift = new FloatParameter(0f, true);
    public FloatParameter _WorldPositionShift = new FloatParameter(1.3f, true);
    public FloatParameter _WorldHeight = new FloatParameter(1f, true);

    public void load(Material material, ref RenderingData renderingData)
    {
        material.SetColor("_CloseFogColor", _CloseFogColor.value);
        material.SetColor("_CloseMidFogColor", _CloseMidFogColor.value);
        material.SetColor("_MidFogColor", _MidFogColor.value);
        material.SetColor("_MidFarFogColor", _MidFarFogColor.value);
        material.SetColor("_FarFogColor", _FarFogColor.value);
        material.SetFloat("_CloseFogDistance", _CloseFogDistance.value);
        material.SetFloat("_CloseMidFogDistance", _CloseMidFogDistance.value);
        material.SetFloat("_MidFogDistance", _MidFogDistance.value);
        material.SetFloat("_MidFarFogDistance", _MidFarFogDistance.value);
        material.SetFloat("_FarFogDistance", _FarFogDistance.value);
        material.SetFloat("_FogIntensity", _FogIntensity.value);
        material.SetFloat("_ExtraCloseFogIntensity", _ExtraCloseFogIntensity.value);
        material.SetFloat("_ExtraCloseMidFogIntensity", _ExtraCloseMidFogIntensity.value);
        material.SetFloat("_ExtraMidFogIntensity", _ExtraMidFogIntensity.value);
        material.SetFloat("_ExtraMidFarFogIntensity", _ExtraMidFarFogIntensity.value);
        material.SetFloat("_ExtraFarFogIntensity", _ExtraFarFogIntensity.value);
        material.SetFloat("_HueShift", _HueShift.value);
        material.SetFloat("_WorldPositionShift", _WorldPositionShift.value);
        material.SetFloat("_WorldHeight", _WorldHeight.value);
        material.SetTexture("_GradientTexture", _GradientTexture.value);
        material.SetInt("_UseGradientTexture", _UseGradientTexture.value ? 1 : 0);
    }

    public bool IsActive() => true;
    public bool IsTileCompatible() => false;
}