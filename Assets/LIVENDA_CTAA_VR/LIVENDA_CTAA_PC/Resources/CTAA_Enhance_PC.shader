//LIVENDA CTAA - CINEMATIC TEMPORAL ANTI ALIASING
//Copyright Livenda Labs 2019 V1.9

Shader "Hidden/CTAA_Enhance_PC"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AEXCTAA ("Pixel Width", Float) = 1
		_AEYCTAA ("Pixel Height", Float) = 1 
		_AESCTAA ("Strength", Range(0, 5.0)) = 0.60
		_AEMAXCTAA ("Clamp", Range(0, 1.0)) = 0.05
	}

	SubShader
	{
		Pass
		{
			ZTest Always Cull Off ZWrite Off
			Fog { Mode off }
			
			CGPROGRAM

				#pragma vertex vert_img
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest 
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				half _AEXCTAA;
				half _AEYCTAA;
				half _AESCTAA;
				half _StrengthMAX;
				half _AEMAXCTAA;
			
				
				uniform sampler2D _Motion0;
				uniform float _motionDelta;
				sampler2D_half _CameraMotionVectorsTexture;

				uniform sampler2D _Motion0Dynamic;
				uniform float _motionDeltaDynamic;
				uniform float _AdaptiveEnhanceStrength;

				fixed4 frag(v2f_img i):COLOR
				{
					half2 fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G = i.uv;
					half4 fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G = tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G);
					half4 original = fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G;
					
					/*
					float4 mo1 = tex2D(_Motion0, i.uv  );
 					float2 ssVel = ( mo1.xy * 2 -1 ) * mo1.z;
 					ssVel *=  _motionDelta;

 					float4 mo2 = tex2D(_Motion0Dynamic, i.uv  );
 					float2 ssVel2 = ( mo2.xy * 2 -1 ) * mo2.z;
 					ssVel2 *=  _motionDeltaDynamic;
					

 					ssVel += ssVel2;
					*/

					half2 fFGRg464fdfdgf78564g7r78gT4rgR6G = tex2D(_CameraMotionVectorsTexture, i.uv).rg;
					
					half4 fFGRg464fdfdgf78564fdffg7r78gT4rgR6G  = tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(0.5 *  _AEXCTAA,       -_AEYCTAA));
						  fFGRg464fdfdgf78564fdffg7r78gT4rgR6G += tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(      -_AEXCTAA, 0.5 * -_AEYCTAA));
						  fFGRg464fdfdgf78564fdffg7r78gT4rgR6G += tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(       _AEXCTAA, 0.5 *  _AEYCTAA));
						  fFGRg464fdfdgf78564fdffg7r78gT4rgR6G += tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(0.5 * -_AEXCTAA,        _AEYCTAA));
					fFGRg464fdfdgf78564fdffg7r78gT4rgR6G /= 4;
					
					float fFGRg464fdfdgf7856gfg4fdffg7r78gT4rgR6G = lerp(_AESCTAA, _StrengthMAX, saturate(length(fFGRg464fdfdgf78564g7r78gT4rgR6G)*_AdaptiveEnhanceStrength) );
					
					half4 fFGRg464fdfdgf785ggf6gfg4fdffg7r78gT4rgR6G = half4(0.2126, 0.7152, 0.0722, 0) * (fFGRg464fdfdgf7856gfg4fdffg7r78gT4rgR6G) * 0.666;

					half4 fFGRg464fdfdgf785ggffgfg6gfg4fdffg7r78gT4rgR6G = fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G - fFGRg464fdfdgf78564fdffg7r78gT4rgR6G;
					fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G += clamp(dot(fFGRg464fdfdgf785ggffgfg6gfg4fdffg7r78gT4rgR6G, fFGRg464fdfdgf785ggf6gfg4fdffg7r78gT4rgR6G), -_AEMAXCTAA, _AEMAXCTAA);

					return fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G; 
				}

			ENDCG
		}

		//=====================================================================

		Pass
		{
			ZTest Always Cull Off ZWrite Off
			Fog { Mode off }
			
			CGPROGRAM

				#pragma vertex vert_img
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest 
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				sampler2D_half _CameraMotionVectorsTexture;
				half _AEXCTAA;
				half _AEYCTAA;
				half _AESCTAA;
				half _AEMAXCTAA;

				fixed4 frag(v2f_img i):COLOR
				{
					
					half2 fFGRg464fdfdgf78564g7r78gT4rgR6G = tex2D(_CameraMotionVectorsTexture, i.uv).rg;
					half2 fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G = i.uv;
					half4 fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G = tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G);

					half4 fFGRg464fdfdgf78564fdffg7r78gT4rgR6G  = tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(0.5 *  _AEXCTAA,       -_AEYCTAA));
						  fFGRg464fdfdgf78564fdffg7r78gT4rgR6G += tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(      -_AEXCTAA, 0.5 * -_AEYCTAA));
						  fFGRg464fdfdgf78564fdffg7r78gT4rgR6G += tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(       _AEXCTAA, 0.5 *  _AEYCTAA));
						  fFGRg464fdfdgf78564fdffg7r78gT4rgR6G += tex2D(_MainTex, fFGRg464fdfdgf785ggffgfg6gfdfg4fdffg7r78gT4rgR6G + half2(0.5 * -_AEXCTAA,        _AEYCTAA));
					fFGRg464fdfdgf78564fdffg7r78gT4rgR6G /= 4;

					float fFGRg464fdfdgf7856gfg4fdffg7r78gT4rgR6G = lerp(0.2, 1.2, saturate(length(fFGRg464fdfdgf78564g7r78gT4rgR6G)*500));

					half4 fFGRg464fdfdgf785ggf6gfg4fdffg7r78gT4rgR6G = half4(0.2126, 0.7152, 0.0722, 0)*(_AESCTAA*fFGRg464fdfdgf7856gfg4fdffg7r78gT4rgR6G+fFGRg464fdfdgf7856gfg4fdffg7r78gT4rgR6G);
					half4 fFGRg464fdfdgf785ggffgfg6gfg4fdffg7r78gT4rgR6G = fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G - fFGRg464fdfdgf78564fdffg7r78gT4rgR6G;
					_AEMAXCTAA = 0.009;//// + fFGRg464fdfdgf7856gfg4fdffg7r78gT4rgR6G;
					fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G += clamp(dot(fFGRg464fdfdgf785ggffgfg6gfg4fdffg7r78gT4rgR6G, fFGRg464fdfdgf785ggf6gfg4fdffg7r78gT4rgR6G), -_AEMAXCTAA, _AEMAXCTAA);

					return fFGRg464fdfdgf785ggffgfg6gfdfg4fdffdffg7r78gT4rgR6G;
				}

			ENDCG
		}

		//=====================================================================
	}

	FallBack off
}
