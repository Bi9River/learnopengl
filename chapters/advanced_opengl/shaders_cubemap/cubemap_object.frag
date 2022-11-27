#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

in vec2 TexCoords;

uniform sampler2D texture_diffuse1;
uniform vec3 cameraPos;
uniform samplerCube skybox;

void main()
{
    float ratio = 1.00 / 1.52;
    vec3 I = normalize(Position - cameraPos);
    // vec3 R = reflect(I, normalize(Normal)); // reflection
    vec3 R = refract(I, normalize(Normal), ratio); // refraction
    // FragColor = texture(texture_diffuse1, TexCoords); // without reflection
    FragColor = vec4(texture(skybox, R).rgb, 1.0);
}