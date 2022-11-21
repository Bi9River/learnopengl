#version 330 core

struct Material{
    sampler2D diffuse;
    sampler2D specular;
    float shininess;
};

struct DirectionalLight{
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct PointLight{
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
};

struct SpotLight{
    vec3 position;
    vec3 direction;
    float cutOff;
    float outerCutOff;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
};

out vec4 FragColor;

in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoords;

uniform vec3 viewPos;
uniform Material material;
uniform SpotLight light;

void main()
{


    vec3 lightDir = normalize(light.position - FragPos);
    float theta = dot(lightDir, normalize(-light.direction));
    float epsilon = light.cutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff)/epsilon,0.0,1.0);
    float distance = length(light.position - FragPos);
            float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

            vec3 norm = normalize(Normal);
            vec3 viewDir = normalize(viewPos - FragPos);
            vec3 reflectDir = reflect(-lightDir, normalize(Normal));

            // ambient
            vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));

            // diffuse
            float diff = max(dot(norm, lightDir), 0.0);
            vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoords));

            // specular
            float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
            vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoords));

            // vec3 result = (ambient + (diffuse + specular) * attenuation) * intensity;
            diffuse *= intensity;
            specular *= intensity;

            ambient *= attenuation;
            diffuse *= attenuation;
            specular *= attenuation;
            vec3 result = ambient + diffuse + specular;
            FragColor = vec4(result, 1.0);
}

// basic lighting
// #version 330 core
// out vec4 FragColor;
//
//
// in vec3 Normal;
// in vec3 FragPos;
//
// uniform vec3 lightPos;
// uniform vec3 viewPos;
// uniform vec3 lightColor;
// uniform vec3 objectColor;
//
// void main()
// {
//     // ambient
//     float ambientStrength = 0.1;
//     vec3 ambient = ambientStrength * lightColor;
//
//     // diffuse
//     vec3 norm = normalize(Normal);
//     vec3 lightDir = normalize(lightPos - FragPos);
//     float diff = max(dot(norm, lightDir), 0.0);
//     vec3 diffuse = diff * lightColor;
//
//     // specular
//     float specularStrength = 0.5;
//     vec3 viewDir = normalize(viewPos - FragPos);
//     float NdotL = dot(norm, lightDir);
//     vec3 specular = vec3(0.0);
//     if(NdotL > 0.0)
//     {
//         vec3 reflectDir = reflect(-lightDir, norm);
//         float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
//         specular = specularStrength * spec * lightColor;
//     }
//
//     // vec3 specular = specularStrength * spec * lightColor;
//
//     vec3 result = (ambient + diffuse + specular) * objectColor;
//     // vec3 result = specular * objectColor;
//     FragColor = vec4(result, 1.0);
// }

// official fragment shader bak
// #version 330 core
// out vec4 FragColor;
//
// in vec3 Normal;
// in vec3 FragPos;
//
// uniform vec3 lightPos;
// uniform vec3 viewPos;
// uniform vec3 lightColor;
// uniform vec3 objectColor;
//
// void main()
// {
//     // ambient
//     float ambientStrength = 0.1;
//     vec3 ambient = ambientStrength * lightColor;
//
//     // diffuse
//     vec3 norm = normalize(Normal);
//     vec3 lightDir = normalize(lightPos - FragPos);
//     float diff = max(dot(norm, lightDir), 0.0);
//     vec3 diffuse = diff * lightColor;
//
//     // specular
//     float specularStrength = 0.5;
//     vec3 viewDir = normalize(viewPos - FragPos);
//     vec3 reflectDir = reflect(-lightDir, norm);
//     float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
//     vec3 specular = specularStrength * spec * lightColor;
//
//     vec3 result = (ambient + diffuse + specular) * objectColor;
//     FragColor = vec4(result, 1.0);
// }