// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33060,y:32741,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32594,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-4610-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32821,y:32834,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT,E-3060-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32275,y:32765,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Time,id:2303,x:31474,y:32899,varname:node_2303,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:9060,x:31484,y:33052,ptovrint:False,ptlb:U Speed (main),ptin:_USpeedmain,varname:node_9060,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:5950,x:31484,y:33130,ptovrint:False,ptlb:V Speed (main),ptin:_VSpeedmain,varname:node_5950,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:3353,x:31728,y:33311,varname:node_3353,prsc:2|A-9060-OUT,B-5950-OUT;n:type:ShaderForge.SFN_Multiply,id:6816,x:31822,y:33013,varname:node_6816,prsc:2|A-2303-T,B-3353-OUT;n:type:ShaderForge.SFN_TexCoord,id:36,x:31716,y:32721,varname:node_36,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:4610,x:32068,y:32843,varname:node_4610,prsc:2|A-36-UVOUT,B-6816-OUT;n:type:ShaderForge.SFN_Tex2d,id:8678,x:32235,y:33189,ptovrint:False,ptlb:node_8678,ptin:_node_8678,varname:node_8678,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:898fbf6304a6cb9499770145b9a31b78,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3060,x:32564,y:33074,varname:node_3060,prsc:2|A-6074-A,B-8678-R;n:type:ShaderForge.SFN_Time,id:4395,x:31055,y:32790,varname:node_4395,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7056,x:31055,y:32976,ptovrint:False,ptlb:U speed (noise),ptin:_Uspeednoise,varname:node_7056,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:7903,x:31055,y:33075,ptovrint:False,ptlb:V speed (noise),ptin:_Vspeednoise,varname:node_7903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:2607,x:31338,y:33006,varname:node_2607,prsc:2|A-7056-OUT,B-7903-OUT;n:type:ShaderForge.SFN_Multiply,id:2748,x:31385,y:32738,varname:node_2748,prsc:2|A-4395-T,B-2607-OUT;n:type:ShaderForge.SFN_TexCoord,id:4128,x:31370,y:32431,varname:node_4128,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:2951,x:31746,y:32434,varname:node_2951,prsc:2|A-4128-UVOUT,B-2748-OUT;n:type:ShaderForge.SFN_Tex2d,id:7825,x:31951,y:32378,ptovrint:False,ptlb:node_7825,ptin:_node_7825,varname:node_7825,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;proporder:6074-797-9060-5950-8678;pass:END;sub:END;*/

Shader "Shader Forge/AdditiveParticle" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _USpeedmain ("U Speed (main)", Float ) = 0.1
        _VSpeedmain ("V Speed (main)", Float ) = 0.1
        _node_8678 ("node_8678", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _USpeedmain;
            uniform float _VSpeedmain;
            uniform sampler2D _node_8678; uniform float4 _node_8678_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_2303 = _Time;
                float2 node_4610 = (i.uv0+(node_2303.g*float2(_USpeedmain,_VSpeedmain)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4610, _MainTex));
                float4 _node_8678_var = tex2D(_node_8678,TRANSFORM_TEX(i.uv0, _node_8678));
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*_TintColor.rgb*2.0*(_MainTex_var.a*_node_8678_var.r));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
