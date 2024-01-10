Shader "Custom/SolidColor" 
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex VertexFunction
            #pragma fragment FragmentFunction

            // Structs
            struct VertexData
            {
                fixed4 vertex   : POSITION;
            }; 

            // Properties
            fixed4 _Color;

            // Functions           
            VertexData VertexFunction(VertexData data)
            {
                data.vertex = UnityObjectToClipPos(data.vertex);
                return data;
            }
            fixed4 FragmentFunction(VertexData data) : SV_Target
            {        
                return _Color;
            }
            ENDCG
        }
    }
}