﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// ORIGINAL GLSL SHADER: 'Metablob' by Adrian Boeing (2011)
Shader "mShaders/mblob1"
{
Properties
{
}
SubShader
{
Tags {Queue = Geometry}
Pass
{
CGPROGRAM
#pragma target 3.0
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
 
struct v2f {
float4 pos : POSITION;
float4 color : COLOR0;
float4 fragPos : COLOR1;
};
 
v2f vert (appdata_base v)
{
v2f o;
o.pos = UnityObjectToClipPos (v.vertex);
o.fragPos = o.pos;
o.color = float4 (1.0, 1.0, 1.0, 1);
return o;
}
 
half4 frag (v2f i) : COLOR
{
float animtime = _Time*10.0;
//the centre point for each blob
float2 move1;
move1.x = cos(animtime)*0.4;
move1.y = sin(animtime*1.5)*0.4;
float2 move2;
move2.x = cos(animtime*2.0)*0.4;
move2.y = sin(animtime*3.0)*0.4;
//screen coordinates
float2 p = -1.0 + 2.0 * i.fragPos.xy / float2 (7,7);
//radius for each blob
float r1 =(dot(p-move1,p-move1))*8.0;
float r2 =(dot(p+move2,p+move2))*16.0;
//sum the meatballs // uh..typo maybe Oo?
float metaball =(1.0/r1+1.0/r2);
//alter the cut-off power
float col = pow(metaball,8.0);
//set the output color
return float4(col,col,col,1.0);
}
ENDCG
}
}
FallBack "VertexLit"
}