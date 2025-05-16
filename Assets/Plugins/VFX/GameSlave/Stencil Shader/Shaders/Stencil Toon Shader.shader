Shader "stencil/Stencil_toon_shader"
{
    Properties
    {
        _Color("Tinte", Color) = (1,1,1,1)
        _MainText("Texture", 2D) = "white" {}
        _Range("Light Diffuse", Range(0, 1)) = 0.3
        _Brightness("Brightness", Range(0, 1)) = 0
        _Strenght("Strenght", Range(0, 1)) = 0
        _StencilRef("Stencil Ref", Float) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }

            Cull Off

            Stencil
            {
                Ref[_StencilRef]
                Comp Equal
            }

            Pass
            {
                Name "ToonPass"

                HLSLPROGRAM

                #pragma vertex vertexShader
                #pragma fragment fragmentShader

                #include "UnityCG.cginc"
                #include "AutoLight.cginc"
                #include "Lighting.cginc"

                float4 _Color;
                sampler2D _MainText;
                float4 _MainText_ST;
                float _Range;
                float _Brightness;
                float _Strenght;

                float toon(float3 normal, float3 lightdir)
                {
                    float NdotL = max(0, dot(normalize(normal), normalize(lightdir)));
                    return floor(NdotL / _Range);
                }

                struct vertexInput
                {
                    float4 vertex : POSITION;
                    float2 uvs : TEXCOORD0;
                    float3 normals : NORMAL;
                };

                struct vertexOutput
                {
                    float4 vertex : SV_POSITION;
                    float2 uvs : TEXCOORD0;
                    float3 worldNormal : NORMAL;
                };

                vertexOutput vertexShader(vertexInput i)
                {
                    vertexOutput o;
                    o.vertex = UnityObjectToClipPos(i.vertex);
                    o.uvs = TRANSFORM_TEX(i.uvs, _MainText);
                    o.worldNormal = UnityObjectToWorldNormal(i.normals);
                    return o;
                }

                float4 fragmentShader(vertexOutput o) : SV_Target
                {
                    float4 col = tex2D(_MainText, o.uvs);
                    float4 diffuse = col * _Color;
                    diffuse *= toon(o.worldNormal, _WorldSpaceLightPos0.xyz) * _Strenght + _Brightness;
                    return diffuse;
                }

                ENDHLSL
            }

            // SHADOW CASTER PASS
            Pass
            {
                Name "ShadowCaster"
                Tags { "LightMode" = "ShadowCaster" }

                ZWrite On
                Cull Off

                HLSLPROGRAM

                #pragma vertex vert
                #pragma fragment frag
                #pragma target 3.0

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    UNITY_SETUP_INSTANCE_ID(v);
                    float4 pos = UnityObjectToClipPos(v.vertex);
                    o.pos = pos;
                    return o;
                }

                float4 frag(v2f i) : SV_Target
                {
                    return 0;
                }

                ENDHLSL
            }
        }
}
