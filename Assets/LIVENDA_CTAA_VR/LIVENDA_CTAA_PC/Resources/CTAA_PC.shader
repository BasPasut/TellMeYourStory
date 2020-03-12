//LIVENDA CTAA CINEMATIC TEMPORAL ANTI ALIASING
//Copyright Livenda Labs 2019
// Unity ASSET STORE V1.9


Shader "Hidden/CTAA_PC" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	
}

SubShader {
	ZTest Always Cull Off ZWrite Off Fog { Mode Off }
	Pass {

CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#pragma glsl
#pragma exclude_renderers d3d11_9x
#include "UnityCG.cginc"

            
float4 _MainTex_TexelSize;

uniform sampler2D _MainTex;
uniform sampler2D _Accum;
uniform sampler2D _Motion0;
float _CamMotion;

uniform sampler2D _CameraDepthTexture;
uniform float _motionDelta;
uniform float _motionDeltaDynamic;
uniform float _AdaptiveResolve;

float4 _ControlParams;
sampler2D_half _CameraMotionVectorsTexture;

float _AntiShimmer;
float4 _delValues;


float POFDJSdsfsggfD(float3 DFEfddfefsdDFFFSdFFFFG)
{
	return (DFEfddfefsdDFFFSdFFFFG.g * 2.0) + (DFEfddfefsdDFFFSdFFFFG.r + DFEfddfefsdDFFFSdFFFFG.b);
}

float DNBFJSdsfsggfD(float DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return 4.0 * rcp(DFEfddfefsdDFFFSdFFFFG * (-yuuyrDFFddDFFFSdFFFFG) + 1.0);
}

float DNBFJSdFFSDDggfD(float dsDFSFSDsdfdsfrersFety, float yuuyrDFFddDFFFSdFFFFG) 
{
	return dsDFSFSDsdfdsfrersFety * DNBFJSdsfsggfD(dsDFSFSDsdfdsfrersFety, yuuyrDFFddDFFFSdFFFFG);
}

float UYUYDHfdFFSDDggfD(float3 DFEfddfefsdDFFFSdFFFFG) 
{
	
		// return dot(DFEfddfefsdDFFFSdFFFFG, float3(0.299, 0.587, 0.114));
	
		return dot(DFEfddfefsdDFFFSdFFFFG, float3(0.2126, 0.7152, 0.0722));
	
}

inline float IIUJDHJJDFDNBDFFSDDggfD(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	
	
	return rcp(POFDJSdsfsggfD(DFEfddfefsdDFFFSdFFFFG) * yuuyrDFFddDFFFSdFFFFG + 4.0);
}

float trirDNBDFFSDDggfD(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return rcp(DFEfddfefsdDFFFSdFFFFG.g * yuuyrDFFddDFFFSdFFFFG + 1.0);
}

float gfJKHDNbehGG(float DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return rcp(DFEfddfefsdDFFFSdFFFFG * yuuyrDFFddDFFFSdFFFFG + 1.0);
}



float gfJKHDNdsdFFFFG(float DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return rcp(DFEfddfefsdDFFFSdFFFFG * yuuyrDFFddDFFFSdFFFFG + 4.0);
}


inline float gfJKHDNDFFFSdFFFFG(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return 4.0 * rcp(POFDJSdsfsggfD(DFEfddfefsdDFFFSdFFFFG) * (-yuuyrDFFddDFFFSdFFFFG) + 1.0);
}

float DFEfdsHDNDFFFSdFFFFG(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return rcp(DFEfddfefsdDFFFSdFFFFG.g * (-yuuyrDFFddDFFFSdFFFFG) + 1.0);
}



float dsDFSFSDFety(float DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return rcp(DFEfddfefsdDFFFSdFFFFG * (-yuuyrDFFddDFFFSdFFFFG) + 1.0);
}





float fFGERdsdfdsrsfdsdsfdDffdgffSDF(float dsDFSFSDsdfdsfrersFety, float yuuyrDFFddDFFFSdFFFFG) 
{
	return dsDFSFSDsdfdsfrersFety * dsDFSFSDFety(dsDFSFSDsdfdsfrersFety, yuuyrDFFddDFFFSdFFFFG);
}


float fFGERdsdfdfdsfdsddfsfTGdssfdsdsfdDffdgffSDF(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	float L = POFDJSdsfsggfD(DFEfddfefsdDFFFSdFFFFG);
	return L * gfJKHDNdsdFFFFG(L, yuuyrDFFddDFFFSdFFFFG);
}

float fFGERdsdfdfdsfdsdfsfTGdssfdsdsfdDffdgffSDF(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return DFEfddfefsdDFFFSdFFFFG.g * gfJKHDNbehGG(DFEfddfefsdDFFFSdFFFFG.g, yuuyrDFFddDFFFSdFFFFG);
}



float fFGERdsdfdfdsfdsdfsfTGdsdsfdDffdgffSDF(float dsDFSFSDsdfdsfrersFety) 
{
	return dsDFSFSDsdfdsfrersFety * rcp(1.0 + dsDFSFSDsdfdsfrersFety);
}
	
float fFGERdsdfdfdsfsfTGdsdsfdDffdgffSDF(float dsDFSFSDsdfdsfrersFety) 
{
	return dsDFSFSDsdfdsfrersFety * rcp(1.0 - dsDFSFSDsdfdsfrersFety);
}

float fFGERdsfsfTGdsdsfdDffdgffSDF(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return sqrt(fFGERdsdfdfdsfdsdfsfTGdsdsfdDffdgffSDF(UYUYDHfdFFSDDggfD(DFEfddfefsdDFFFSdFFFFG) * yuuyrDFFddDFFFSdFFFFG));
}

float fFGERTGdsdsfdDffdgffSDF(float dsDFSFSDsdfdsfrersFety) 
{
	
	return fFGERdsdfdfdsfsfTGdsdsfdDffdgffSDF(dsDFSFSDsdfdsfrersFety * dsDFSFSDsdfdsfrersFety);
}


inline float tttteFFGsdfdssfdFsdfg(float3 tttteFFGsdfdssfddsdsdeFsdfg, float3 Org, float3 Box)
{
	if(min(min(abs(tttteFFGsdfdssfddsdsdeFsdfg.x), abs(tttteFFGsdfdssfddsdsdeFsdfg.y)), abs(tttteFFGsdfdssfddsdsdeFsdfg.z)) < (1.0/65536.0)) return 1.0;
	float3 fFGERTGDffdgffSDF = rcp(tttteFFGsdfdssfddsdsdeFsdfg);
	float3 TNeg = (  Box  - Org) * fFGERTGDffdgffSDF;
	float3 TPos = ((-Box) - Org) * fFGERTGDffdgffSDF;
	return max(max(min(TNeg.x, TPos.x), min(TNeg.y, TPos.y)), min(TNeg.z, TPos.z));
}



inline float fFGRg4754gr7g543wg74GT4rgR6G(float3 fgDDgsddsdfsDFFFdsdfSdFFFFGsdfsdfg, float3 dsFFDFFdsdfSdFFFFGsdfsdfg, float3 ddfytyudfSdFFFFGsdfsdfg, float3 ddfytyusdfFFFGsdfsdfg, float tttteFFGsdfsdedssfddsdsdeFsdfg)
{
	float3 fFGERTGDffSDF = min(dsFFDFFdsdfSdFFFFGsdfsdfg, min(ddfytyudfSdFFFFGsdfsdfg, ddfytyusdfFFFGsdfsdfg));
	float3 tttteFFGsdedfsdedssfddsdsdeFsdfg = max(dsFFDFFdsdfSdFFFFGsdfsdfg, max(ddfytyudfSdFFFFGsdfsdfg, ddfytyusdfFFFGsdfsdfg));	

	float3 tttteFFGsdfsdfg = tttteFFGsdedfsdedssfddsdsdeFsdfg + fFGERTGDffSDF;
	
	float3 tttteFFGsdfdssfddsdsdeFsdfg = dsFFDFFdsdfSdFFFFGsdfsdfg - fgDDgsddsdfsDFFFdsdfSdFFFFGsdfsdfg;
	float3 Org = fgDDgsddsdfsDFFFdsdfSdFFFFGsdfsdfg - tttteFFGsdfsdfg * 0.5;
	float3 Scale = tttteFFGsdedfsdedssfddsdsdeFsdfg - tttteFFGsdfsdfg * tttteFFGsdfsdedssfddsdsdeFsdfg;
	return saturate(tttteFFGsdfdssfdFsdfg(tttteFFGsdfdssfddsdsdeFsdfg, Org, Scale));	
}

float HdrWeight(float3 DFEfddfefsdDFFFSdFFFFG, float yuuyrDFFddDFFFSdFFFFG) 
{
	return rcp(max(UYUYDHfdFFSDDggfD(DFEfddfefsdDFFFSdFFFFG) * yuuyrDFFddDFFFSdFFFFG, 1.0));
}

float4 HdrLerp(float4 yuuyffdgsDFFFSdFFFFG, float4 fgDDgsDFFFSdFFFFG, float fgDDgsDFFFSdFFFFGsdfsdfg, float yuuyrDFFddDFFFSdFFFFG) 
{
	float fgDDgsdsDFFFSdFFFFGsdfsdfg = (1.0 - fgDDgsDFFFSdFFFFGsdfsdfg) * HdrWeight(yuuyffdgsDFFFSdFFFFG.rgb, yuuyrDFFddDFFFSdFFFFG);
	float fgDDgsdsDFFFdsdfSdFFFFGsdfsdfg =        fgDDgsDFFFSdFFFFGsdfsdfg  * HdrWeight(fgDDgsDFFFSdFFFFG.rgb, yuuyrDFFddDFFFSdFFFFG);
	float RcpBlend = rcp(fgDDgsdsDFFFSdFFFFGsdfsdfg + fgDDgsdsDFFFdsdfSdFFFFGsdfsdfg);
	fgDDgsdsDFFFSdFFFFGsdfsdfg *= RcpBlend;
	fgDDgsdsDFFFdsdfSdFFFFGsdfsdfg *= RcpBlend;
	return yuuyffdgsDFFFSdFFFFG * fgDDgsdsDFFFSdFFFFGsdfsdfg + fgDDgsDFFFSdFFFFG * fgDDgsdsDFFFdsdfSdFFFFGsdfsdfg;
}




struct v2f {
	float4 pos : POSITION;
	float2 uv : TEXCOORD0;
};

v2f vert( appdata_img v )
{
	v2f o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.uv = v.texcoord.xy;

	/*
	#if UNITY_UV_STARTS_AT_TOP
		o.uv = v.texcoord.xy;
		if (_MainTex_TexelSize.y < 0)
			o.uv.y = 1-o.uv.y;
		#endif		
		*/

	return o;
}

float4 frag (v2f i) : COLOR
{


 // GET MOTION DATA
 // ------------------------------------------------

 float2 dsDFSFSDsdsfdfsdfdsfrersFety;
 float2 dsDFSFSDsdfddffdsfdfsdfdsfrersFety;
		
 float  dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety = 1;
  
 float2  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety = _MainTex_TexelSize.xy;

 

 //###################################################
 
 
 float hjuhdffdsfdfsdfdsfrersFety = 1-Linear01Depth(tex2D (_CameraDepthTexture, i.uv).x);
 
 float hjuhdffdsfdfdgefdfsdfdsfrersFety = 1;
 float2 hjuhdffdsfdRREfdgefdfsdfdsfrersFety[4];
 
 hjuhdffdsfdRREfdgefdfsdfdsfrersFety[0] = float2( -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x, -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y )*hjuhdffdsfdfdgefdfsdfdsfrersFety;
 hjuhdffdsfdRREfdgefdfsdfdsfrersFety[1] = float2(  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x, -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y )*hjuhdffdsfdfdgefdfsdfdsfrersFety;
 hjuhdffdsfdRREfdgefdfsdfdsfrersFety[2] = float2( -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x,  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y )*hjuhdffdsfdfdgefdfsdfdsfrersFety;
 hjuhdffdsfdRREfdgefdfsdfdsfrersFety[3] = float2(  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x,  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y )*hjuhdffdsfdfdgefdfsdfdsfrersFety;
 
 float hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[4];
 hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[0] = 1-Linear01Depth(tex2D (_CameraDepthTexture, i.uv + hjuhdffdsfdRREfdgefdfsdfdsfrersFety[0] ).x);
 hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[1] = 1-Linear01Depth(tex2D (_CameraDepthTexture, i.uv + hjuhdffdsfdRREfdgefdfsdfdsfrersFety[1] ).x);
 hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[2] = 1-Linear01Depth(tex2D (_CameraDepthTexture, i.uv + hjuhdffdsfdRREfdgefdfsdfdsfrersFety[2] ).x);
 hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[3] = 1-Linear01Depth(tex2D (_CameraDepthTexture, i.uv + hjuhdffdsfdRREfdgefdfsdfdsfrersFety[3] ).x);
 
 int dIndx0;
 if(hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[0] > hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[1]) dIndx0 = 0;
 else dIndx0 = 1;
 
 int dIndx1;
 if(hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[2] > hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[3]) dIndx1 = 2;
 else dIndx1 = 3;
 
 int dIndx2;
 if(hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[dIndx0] > hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[dIndx1]) dIndx2 = dIndx0;
 else dIndx2 = dIndx1;
 
 //-----------------------------------
 int dIndx0C;
 if(hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[0] < hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[1]) dIndx0C = 0;
 else dIndx0C = 1;
 
 int dIndx1C;
 if(hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[2] < hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[3]) dIndx1C = 2;
 else dIndx1C = 3;
 
 int dIndx2C;
 if(hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[dIndx0C] < hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[dIndx1C]) dIndx2C = dIndx0C;
 else dIndx2C = dIndx1C;
 
 //-----------------------------------

 float2 hjuhdfffdsufdRREfrdetdgefdfsdfdsfrersFety = float2(0,0);
 
 if( hjuhdfffdsfdRREfdgefdfsdfdsfrersFety[dIndx2] > hjuhdffdsfdfsdfdsfrersFety)
 {
 	hjuhdfffdsufdRREfrdetdgefdfsdfdsfrersFety = hjuhdffdsfdRREfdgefdfsdfdsfrersFety[dIndx2];
 }

 

 //###################################################

 //Use Motion Vectors Unity
 float2 hjuhdfffdsufdRREfrdetdgefdfsdfdsfrergsFety = tex2D(_CameraMotionVectorsTexture, i.uv+hjuhdfffdsufdRREfrdetdgefdfsdfdsfrersFety).rg;

 dsDFSFSDsdsfdfsdfdsfrersFety =   hjuhdfffdsufdRREfrdetdgefdfsdfdsfrergsFety;

 //###################################################


 float hjuhdfffdsufdRREfrdetdgeffdfsdfdsfrergsFety = 1;
 float hjuhdfffdsufdRf5REfrdetdgeffdfsdfdsfrergsFety = saturate(abs(dsDFSFSDsdsfdfsdfdsfrersFety.x) * hjuhdfffdsufdRREfrdetdgeffdfsdfdsfrergsFety + abs(dsDFSFSDsdsfdfsdfdsfrersFety.y) * hjuhdfffdsufdRREfrdetdgeffdfsdfdsfrergsFety);
	half2  uv = i.uv ;
	half4 hjuhdfffdsufdRf5REfrde6tdgeffdfsdfdsfrergsFety = tex2D(_MainTex, uv.xy - hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsdfdsfrergsFety = tex2D(_MainTex, uv.xy + float2(  0, -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y ) );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrergsFety = tex2D(_MainTex, uv.xy + float2(  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x, -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y ) );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrerg8sFety = tex2D(_MainTex, uv.xy + float2(  -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x, 0 ) );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety = tex2D(_MainTex, uv.xy);
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdsftrerg8sFety = tex2D(_MainTex, uv.xy + float2(   hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x, 0 ) );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfds4ftrerg8sFety = tex2D(_MainTex, uv.xy + float2( -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x,  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y ) );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdrs4ftrerg8sFety = tex2D(_MainTex, uv.xy + float2(  0,  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y ) );
	half4 hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfders4ftrerg8sFety = tex2D(_MainTex, uv.xy + hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety );
	    half fFGRgfgrRGTRgRG = (UYUYDHfdFFSDDggfD(tex2D(_MainTex, uv.xy +  float2(  0, -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y  ) )) );
        half fFGRgf4grRGTRgRG = (UYUYDHfdFFSDDggfD( tex2D(_MainTex, uv.xy + float2(  0,  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.y  ) )) );
        half fFGRgf4grRGTRrgRG = (UYUYDHfdFFSDDggfD(tex2D(_MainTex, uv.xy  + float2(  hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x , 0  ) )) );
        half fFGRg44grRGTRrgRG = (UYUYDHfdFFSDDggfD(tex2D(_MainTex, uv.xy  + float2( -hjuhdfffdsufdRREfrdgefdfsdfdsfrersFety.x , 0  ) )) );
		half fFGRg44grtrwRGTRrgRG = (UYUYDHfdFFSDDggfD(tex2D(_MainTex, uv.xy))) - (fFGRgfgrRGTRgRG + fFGRgf4grRGTRgRG + fFGRgf4grRGTRrgRG + fFGRg44grRGTRrgRG)*0.25;
		half fFGRg44grtrwRrewGTRrgRG       = saturate(abs(fFGRg44grtrwRGTRrgRG));
        fFGRg44grtrwRrewGTRrgRG = saturate(pow(fFGRg44grtrwRrewGTRrgRG, 4.0)*0.5);
        dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety = _ControlParams.z;	
		hjuhdfffdsufdRf5REfrde6tdgeffdfsdfdsfrergsFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6tdgeffdfsdfdsfrergsFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsdfdsfrergsFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsdfdsfrergsFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrergsFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrergsFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrerg8sFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrerg8sFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdsftrerg8sFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdsftrerg8sFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfds4ftrerg8sFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfds4ftrerg8sFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdrs4ftrerg8sFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdrs4ftrerg8sFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfders4ftrerg8sFety.rgb *= IIUJDHJJDFDNBDFFSDDggfD(hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfders4ftrerg8sFety.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		half4 dsFFDFFdsdfSdFFFFGsdfsdfg= 
			hjuhdfffdsufdRf5REfrde6tdgeffdfsdfdsfrergsFety * 0.0625 + 
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsdfdsfrergsFety * 0.125 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrergsFety * 0.0625 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrerg8sFety * 0.125 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety * 0.25 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdsftrerg8sFety * 0.125 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfds4ftrerg8sFety * 0.0625 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdrs4ftrerg8sFety * 0.125 +
			hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfders4ftrerg8sFety * 0.0625;
			
		float4	 fFGRg4754grtrwRrewGTRrgRG = dsFFDFFdsdfSdFFFFGsdfsdfg;
		half4 fFGRg4754grtrwRwGTRrgRG = min(min(hjuhdfffdsufdRf5REfrde6tdgeffdfsdfdsfrergsFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrergsFety), min(hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfds4ftrerg8sFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfders4ftrerg8sFety));		
		half4 fFGRg4754grtrwGTRrgRG = max(max(hjuhdfffdsufdRf5REfrde6tdgeffdfsdfdsfrergsFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrergsFety), max(hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfds4ftrerg8sFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfders4ftrerg8sFety));		
		half4 ddfytyudfSdFFFFGsdfsdfg = min(min(min(hjuhdfffdsufdRf5REfrde6t8dgeffdfsdfdsfrergsFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrerg8sFety), min(hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdsftrerg8sFety)), hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdrs4ftrerg8sFety);		
		half4 ddfytyusdfFFFGsdfsdfg = max(max(max(hjuhdfffdsufdRf5REfrde6t8dgeffdfsdfdsfrergsFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsfrerg8sFety), max(hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety, hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdsftrerg8sFety)), hjuhdfffdsufdRf5REfrde6t8dgeffdfsf4tdfdrs4ftrerg8sFety);		
		fFGRg4754grtrwRwGTRrgRG = min(fFGRg4754grtrwRwGTRrgRG, ddfytyudfSdFFFFGsdfsdfg);
		fFGRg4754grtrwGTRrgRG = max(fFGRg4754grtrwGTRrgRG, ddfytyusdfFFFGsdfsdfg);
	    ddfytyudfSdFFFFGsdfsdfg = ddfytyudfSdFFFFGsdfsdfg * 0.5 + fFGRg4754grtrwRwGTRrgRG * 0.5;
		ddfytyusdfFFFGsdfsdfg = ddfytyusdfFFFGsdfsdfg * 0.5 + fFGRg4754grtrwGTRrgRG * 0.5;
		float4 fFGRg4754grtrw74GTRrgRG = tex2D(_Accum, i.uv-dsDFSFSDsdsfdfsdfdsfrersFety);
 	    fFGRg4754grtrw74GTRrgRG.rgb *= IIUJDHJJDFDNBDFFSDDggfD(fFGRg4754grtrw74GTRrgRG.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		float fFGRg4754grtrw74GTRrgR6G = POFDJSdsfsggfD(ddfytyudfSdFFFFGsdfsdfg.rgb);
		float fFGRg4754gr7w74GTRrgR6G = POFDJSdsfsggfD(ddfytyusdfFFFGsdfsdfg.rgb);
		float fFGRg4754gr7w74GT4rgR6G = POFDJSdsfsggfD(fFGRg4754grtrw74GTRrgRG.rgb);
		float fFGRg4754gr7wg74GT4rgR6G = fFGRg4754gr7w74GTRrgR6G - fFGRg4754grtrw74GTRrgR6G;
		float2	tttteFFGsdfsdedssfddsdsdeFsdfg = lerp( float2(_delValues.x, _delValues.y), float2(_delValues.z, _delValues.w), saturate(length(dsDFSFSDsdsfdfsdfdsfrersFety)*1000000) );

				if(_AntiShimmer < 0.5)
				{
				 tttteFFGsdfsdedssfddsdsdeFsdfg = float2(0.5, 1.0);
				}
	
		_ControlParams.y = _ControlParams.y * tttteFFGsdfsdedssfddsdsdeFsdfg.y ;
		float fFGRg4754gr7gwg74GT4rgR6G = fFGRg4754gr7g543wg74GT4rgR6G(fFGRg4754grtrw74GTRrgRG.rgb, fFGRg4754grtrwRrewGTRrgRG.rgb, ddfytyudfSdFFFFGsdfsdfg.rgb, ddfytyusdfFFFGsdfsdfg.rgb, tttteFFGsdfsdedssfddsdsdeFsdfg.x);
			  fFGRg4754gr7gwg74GT4rgR6G = saturate( fFGRg4754gr7gwg74GT4rgR6G );
		  	  fFGRg4754grtrw74GTRrgRG.rgb = lerp(fFGRg4754grtrw74GTRrgRG.rgb, fFGRg4754grtrwRrewGTRrgRG.rgb, fFGRg4754gr7gwg74GT4rgR6G );
		float fFGRg464754gr7g543wg74GT4rgR6G = saturate(hjuhdfffdsufdRf5REfrdetdgeffdfsdfdsfrergsFety) * 0.5;
		float fFGRg464f754gr7g543wg74GT4rgR6G =  _ControlParams.w;
		fFGRg464754gr7g543wg74GT4rgR6G = saturate(fFGRg464754gr7g543wg74GT4rgR6G + rcp(1.0 + fFGRg4754gr7wg74GT4rgR6G * fFGRg464f754gr7g543wg74GT4rgR6G));
		dsFFDFFdsdfSdFFFFGsdfsdfg.rgb = lerp(dsFFDFFdsdfSdFFFFGsdfsdfg.rgb, hjuhdfffdsufdRf5REfrde6t8dgeffdfsftdfdsftrerg8sFety.rgb, fFGRg464754gr7g543wg74GT4rgR6G);
		_ControlParams.y = _ControlParams.y* saturate(1-length(dsDFSFSDsdsfdfsdfdsfrersFety*dsDFSFSDsdsfdfsdfdsfrersFety)*90+1);
		float fFGRg464f7854gr7g543wg74GT4rgR6G = (1.0/_ControlParams.y) + hjuhdfffdsufdRf5REfrdetdgeffdfsdfdsfrergsFety * (1.0/_ControlParams.y);
		float fFGRg464f78564gr7g543wg74GT4rgR6G = fFGRg4754gr7w74GT4rgR6G * fFGRg464f7854gr7g543wg74GT4rgR6G * (1.0 + hjuhdfffdsufdRf5REfrdetdgeffdfsdfdsfrergsFety * fFGRg464f7854gr7g543wg74GT4rgR6G * 4.0);
		float fFGRg464f78564gr78g543wg74GT4rgR6G = saturate(fFGRg464f78564gr7g543wg74GT4rgR6G * rcp(fFGRg4754gr7w74GT4rgR6G + fFGRg4754gr7wg74GT4rgR6G));
		float fFGRg464f78564g7r78gT4rgR6G = lerp(fFGRg464f78564gr78g543wg74GT4rgR6G, (sqrt(fFGRg464f78564gr78g543wg74GT4rgR6G)), saturate(length(dsDFSFSDsdsfdfsdfdsfrersFety)*_AdaptiveResolve) );
		fFGRg4754grtrw74GTRrgRG = lerp(fFGRg4754grtrw74GTRrgRG, dsFFDFFdsdfSdFFFFGsdfsdfg, fFGRg464f78564g7r78gT4rgR6G);
		fFGRg4754grtrw74GTRrgRG.rgb *= gfJKHDNDFFFSdFFFFG(fFGRg4754grtrw74GTRrgRG.rgb, dsDFSFSDsddfddffddffdsfdfsdfdsfrersFety);
		fFGRg4754grtrw74GTRrgRG.rgb = -min(-fFGRg4754grtrw74GTRrgRG.rgb, 0.0);
	 	return fFGRg4754grtrw74GTRrgRG;
	 		
}
ENDCG
	}
}

Fallback off

}