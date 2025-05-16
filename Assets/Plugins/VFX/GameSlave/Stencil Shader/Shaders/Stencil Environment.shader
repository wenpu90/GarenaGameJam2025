Shader "stencil/Environment_stencil"
{

    Properties
    {

        _MainTex("Texture", 2D) = "White" {}
        _BaseColor("Color", Color) = (1,1,1,1)
        _StencilRef("Stencil Ref", Float) = 1


    }

    SubShader{
        Tags { "RenderPipeline"="UniversalRenderPipeline" "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 100
        cull off

        Stencil{
            ref 1
            comp equal
        }

        pass 
        {
            HLSLPROGRAM
         #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma vertex vert
            #pragma fragment frag
          
            //include fog
            #pragma multi_compile_fog           

            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _SHADOWS_SOFT
            #pragma shader_feature _ALPHATEST_ON
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            CBUFFER_START(UnityPerMaterial)

            float4 _BaseColor;
             TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_END

           

            struct VertexInput
            {
                float4 vertex :POSITION;
                float2 uv :TEXCOORD0;
                float3 normal :NORMAL;

                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct vertexOutput
            {
                float4 vertex :SV_POSITION;
                float2 uv :TEXCOORD0;
                 float4 shadowCoord : TEXCOORD2;
                 float3 normal :NORMAL;

                      UNITY_VERTEX_INPUT_INSTANCE_ID
               UNITY_VERTEX_OUTPUT_STEREO
            };

                vertexOutput  vert(VertexInput v)
                {
                    vertexOutput o;
                    o.vertex = TransformObjectToHClip(v.vertex.xyz);
                     VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);
                     o.normal = normalize(mul(v.normal, (float3x3)UNITY_MATRIX_I_M));
              o.shadowCoord = GetShadowCoord(vertexInput);
                    o.uv = v.uv;
                    
                    return o;
                }

                float4 frag(vertexOutput i) : SV_TARGET
                {
                     UNITY_SETUP_INSTANCE_ID(i);
              UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

                Light mainLight = GetMainLight(i.shadowCoord);

                mainLight.shadowAttenuation += 0.7;

                  //Lighting Calculate(Lambert)              
              float NdotL = saturate(dot(normalize(_MainLightPosition.xyz), i.normal));            
              float3 ambient = SampleSH(i.normal);    
                    
                    float4 baseTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);

                    baseTex.rgb *= NdotL * _MainLightColor.rgb * mainLight.shadowAttenuation + ambient;
                    return baseTex * _BaseColor;
                }

            ENDHLSL
        }

        
    }
}