#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture_diffuse1;

float near = 0.1;
float far = 100.0;

float LinearizeDepth(float depth)
{
    float ndc = depth * 2.0 - 1.0; // Back to NDC
    return (2.0 * near * far) / (far + near - ndc * (far - near));
}

void main()
{
    float depth = LinearizeDepth(gl_FragCoord.z);
    FragColor = vec4(vec3(depth), 1.0);
}