#version 330 core
out vec4 FragColor;
in vec3 vertexColor;
in vec2 TexCoord;
uniform vec3 ourColor;
uniform float greenColor;
uniform sampler2D texture1;
uniform sampler2D texture2;
void main()
{
    FragColor = mix(texture(texture1,TexCoord),
                    texture(texture2,TexCoord),0.2);
}