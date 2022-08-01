/// Comments beginning with three slashes are specific to the injection file.
/// They won't be included in the resulting .shader file.
/// I have indented these comments below for readability, they will help you understand each available special comment.

///         Define a code block using the '//# BLOCK: ' prefix followed by the block name.
///         The block name can be anything you want, it is only used for the user interface.
//# BLOCK: Define Custom Properties
///         The '//# Inject @ ' prefix will tell the Shader Generator 2 to automatically inject this block at the specified injection point, if found in the template.
///         The easiest way to find the available injection points for your shader is to enable the 'Mark injection points' setting
///         in the CODE INJECTION tab, and then look for '// Injection Point : [name]' comments in the resulting .shader file.
//# Inject @ Properties/Start
///         All the following lines will be inserted in the .shader file at the injection point location, including comments with two slashes '//'
[TCP2HeaderToggle(_EMISSION)] _UseEmission ("Emission", Float) = 0
//# IF_KEYWORD _EMISSION
_EmissionMap ("Texture (A)", 2D) = "white" {}
[TCP2ColorNoAlpha] [HDR] _EmissionColor ("Emission Color", Color) = (1,1,0,1)
//# END_IF
///         Some material decorator drawers are included with Toony Colors Pro 2, you can freely use them like this separator
[TCP2Separator]

///         The current BLOCK will end when a new command starts, or the end of the file is reached.
///         Any additional line breaks between the two will be trimmed, so you can freely add more for readability.

//# BLOCK: Declare Custom Properties
//# Inject @ Variables/Inside CBuffer
float4 _EmissionMap_ST;
half4 _EmissionColor;
sampler2D _EmissionMap;

//# BLOCK: Custom Shader Features
//# Inject @ Main Pass/Pragma
#pragma shader_feature_local _EMISSION


//# BLOCK: Define Raw Texcoord
//# Inject @ Main Pass/Surface Input
float2 rawTexcoord;

//# BLOCK: Get Raw Texcoord
//# Inject @ Main Pass/Vertex Shader/Start
output.rawTexcoord.xy = v.texcoord0.xy;


//# BLOCK: Add Emission Color
//# Inject @ Main Pass/Surface Function/End
///         We can define custom Shader Properties here, similar to the ones in the SHADER PROPERTIES tab of the Shader Generator 2.
///         Simply add one line per property with:
///           float(N) propertyName defaultValue(optional)
///         You can then simply use them in your code with their name, and they will be replaced automatically in the final .shader file.

half3 emission = half3(0,0,0);

// Emission
#if defined(_EMISSION)
	float2 rawTexcoord = input.rawTexcoord.xy;
	emission = _EmissionColor.rgb;
	half4 emissionMap = tex2D(_EmissionMap, rawTexcoord * _EmissionMap_ST.xy + _EmissionMap_ST.zw);
	emission *= emissionMap.rgb;
	output.Emission += emission.rgb;
#endif
