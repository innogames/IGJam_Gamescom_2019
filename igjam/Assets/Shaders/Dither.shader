// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33298,y:32709,varname:node_9361,prsc:2|emission-7229-OUT,olwid-7321-OUT,olcol-8836-RGB;n:type:ShaderForge.SFN_LightVector,id:6869,x:31858,y:32654,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31858,y:32782,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:32070,y:32697,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32070,y:32349,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5927,x:32070,y:32534,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:544,x:32268,y:32448,cmnt:Diffuse Color,varname:node_544,prsc:2|A-851-RGB,B-5927-RGB;n:type:ShaderForge.SFN_Tex2d,id:5771,x:32066,y:32041,ptovrint:False,ptlb:Dither,ptin:_Dither,varname:node_5771,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a2cc5b093f441dc419073fee78640a3b,ntxv:0,isnm:False|UVIN-4307-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:7690,x:31703,y:32021,varname:node_7690,prsc:2;n:type:ShaderForge.SFN_Append,id:4307,x:31896,y:32041,varname:node_4307,prsc:2|A-7690-X,B-7690-Y;n:type:ShaderForge.SFN_Lerp,id:1269,x:33064,y:32563,varname:node_1269,prsc:2|A-2393-OUT,B-544-OUT,T-6611-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5422,x:32066,y:32228,ptovrint:False,ptlb:DitherSize,ptin:_DitherSize,varname:node_5422,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_Add,id:5934,x:32282,y:32169,varname:node_5934,prsc:2|A-5771-RGB,B-5422-OUT;n:type:ShaderForge.SFN_Add,id:4547,x:32887,y:32416,varname:node_4547,prsc:2|A-544-OUT,B-9377-OUT;n:type:ShaderForge.SFN_Round,id:1372,x:32474,y:32272,varname:node_1372,prsc:2|IN-5934-OUT;n:type:ShaderForge.SFN_Multiply,id:9377,x:32521,y:32071,varname:node_9377,prsc:2|A-1310-RGB,B-3126-OUT;n:type:ShaderForge.SFN_Color,id:1310,x:32282,y:31988,ptovrint:False,ptlb:DitherColor,ptin:_DitherColor,varname:node_1310,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Clamp01,id:3126,x:32625,y:32217,varname:node_3126,prsc:2|IN-1372-OUT;n:type:ShaderForge.SFN_Subtract,id:2393,x:32875,y:32283,varname:node_2393,prsc:2|A-544-OUT,B-9377-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7321,x:32890,y:33168,ptovrint:False,ptlb:Outline,ptin:_Outline,varname:node_7321,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:8836,x:32890,y:32986,ptovrint:False,ptlb:OutlineColor,ptin:_OutlineColor,varname:node_8836,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_TexCoord,id:56,x:31309,y:32333,varname:node_56,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:9862,x:31489,y:32333,varname:node_9862,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4949-XYZ;n:type:ShaderForge.SFN_Length,id:853,x:31664,y:32333,varname:node_853,prsc:2|IN-9862-OUT;n:type:ShaderForge.SFN_OneMinus,id:9924,x:31830,y:32333,varname:node_9924,prsc:2|IN-853-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:4949,x:31004,y:32169,varname:node_4949,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:486,x:32456,y:32793,varname:node_486,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:114,x:32686,y:32786,ptovrint:False,ptlb:Outlines,ptin:_Outlines,varname:node_114,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-486-UVOUT;n:type:ShaderForge.SFN_Subtract,id:7229,x:33097,y:32733,varname:node_7229,prsc:2|A-1269-OUT,B-114-A;n:type:ShaderForge.SFN_Smoothstep,id:6611,x:32473,y:32629,varname:node_6611,prsc:2|A-656-OUT,B-256-OUT,V-7782-OUT;n:type:ShaderForge.SFN_Vector1,id:656,x:32189,y:32907,varname:node_656,prsc:2,v1:0.35;n:type:ShaderForge.SFN_Vector1,id:256,x:32189,y:32976,varname:node_256,prsc:2,v1:0.5;proporder:851-5927-5771-5422-1310-7321-8836-114;pass:END;sub:END;*/

Shader "Shader Forge/Dither" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Dither ("Dither", 2D) = "white" {}
        _DitherSize ("DitherSize", Float ) = 0.4
        _DitherColor ("DitherColor", Color) = (0.5,0.5,0.5,1)
        _Outline ("Outline", Float ) = 0
        _OutlineColor ("OutlineColor", Color) = (0.5,0.5,0.5,1)
        _Outlines ("Outlines", 2D) = "black" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Outline;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_Outline,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Color;
            uniform sampler2D _Dither; uniform float4 _Dither_ST;
            uniform float _DitherSize;
            uniform float4 _DitherColor;
            uniform sampler2D _Outlines; uniform float4 _Outlines_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 node_544 = (_Diffuse_var.rgb*_Color.rgb); // Diffuse Color
                float2 node_4307 = float2(i.posWorld.r,i.posWorld.g);
                float4 _Dither_var = tex2D(_Dither,TRANSFORM_TEX(node_4307, _Dither));
                float3 node_9377 = (_DitherColor.rgb*saturate(round((_Dither_var.rgb+_DitherSize))));
                float4 _Outlines_var = tex2D(_Outlines,TRANSFORM_TEX(i.uv1, _Outlines));
                float3 emissive = (lerp((node_544-node_9377),node_544,smoothstep( 0.35, 0.5, max(0,dot(lightDirection,normalDirection)) ))-_Outlines_var.a);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Color;
            uniform sampler2D _Dither; uniform float4 _Dither_ST;
            uniform float _DitherSize;
            uniform float4 _DitherColor;
            uniform sampler2D _Outlines; uniform float4 _Outlines_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
