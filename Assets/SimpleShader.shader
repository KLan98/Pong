Shader "Unlit/SimpleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "red" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            // define vertex input as mesh data: position, uvs,...
            struct VertexInput
            {
                float4 vertex : POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normal : NORMAL;
            };

            // define vertex output as clip space position
            struct VertexOutput
            {               
                float4 clipSpacePosition : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normal : TEXCOORD1;
            };

            // sampler2D _MainTex;
            // float4 _MainTex_ST;

            // vertex shader 
            VertexOutput vert (VertexInput v)
            {
                // reference to vertex output is o 
                VertexOutput o;

                // assign the uv input into uv output
                o.uv0 = v.uv0;

                // 
                o.normal = v.normal;

                // convert a coordinate vector from object space to clip space.
                o.clipSpacePosition = UnityObjectToClipPos(v.vertex);
                return o;
            }

            // fragment shader
            float4 frag (VertexOutput o) : SV_Target
            {
                // send uv (output of vertex shader) to the fragment shader
                float2 uv = o.uv0;

                float lightDir = normalize(float3(1, 1, 1));

                float3 lightColor = float3(0.3, 0.3, 0.7);

                float3 normal = o.normal;

                float lightFallOff = max(0, dot(lightDir, normal));

                float3 diffuseLight = lightFallOff * lightColor;

                float3 ambientLight = float3(0.7, 0.45, 0.2);

                return float4 (diffuseLight + ambientLight, 0);

            }
            ENDCG
        }
    }
}
