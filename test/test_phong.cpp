#include"glm/glm.hpp"
#include"glm/gtc/matrix_transform.hpp"
#include"glm/gtc/type_ptr.hpp"
#include<iostream>
#include"LearnOpenGL/camera.h"
#include "LearnOpenGL/stb_image.h"
#include "glad/glad.h"
#include <GLFW/glfw3.h>
#include"LearnOpenGL/shader_m.h"
#include <cmath>

int main() {
    glm::vec3 lightPos(1.2f, 1.0f, 2.0f);
    glm::vec3 cameraPos = glm::vec3(-3.0f, 0.0f, -1.0f);
    glm::vec3 lightColor = glm::vec3(1.0f, 1.0f, 1.0f);
    glm::vec3 fragPos = glm::vec3(1.0f, 1.0f, -1.0f);

    float ambientStrength = 0.1f;
    float specularStrength = 0.5f;
    float shininess = 32.0f;

    glm::vec3 ambient = ambientStrength * lightColor;
    std::cout << "ambient: " << ambient.x << " " << ambient.y << " " << ambient.z << std::endl;

    glm::vec3 norm = glm::vec3(0.0f, 0.0f, -1.0f);
    glm::vec3 lightDir = glm::normalize(lightPos - fragPos);
    std::cout << "lightDir: " << lightDir.x << " " << lightDir.y << " " << lightDir.z << std::endl;
    float diff = std::max(glm::dot(norm, lightDir), 0.0f);
    glm::vec3 diffuse = diff * lightColor;
    std::cout << "diffuse: " << diffuse.x << " " << diffuse.y << " " << diffuse.z << std::endl;

    glm::vec3 viewDir = glm::normalize(cameraPos - fragPos);
    std::cout << "viewDir: " << viewDir.x << " " << viewDir.y << " " << viewDir.z << std::endl;
    glm::vec3 reflectDir = glm::reflect(-lightDir, norm);
    std::cout << "reflectDir: " << reflectDir.x << " " << reflectDir.y << " " << reflectDir.z << std::endl;
    std::cout << glm::dot(viewDir, reflectDir) << std::endl;
    float spec = pow(std::max(glm::dot(viewDir, reflectDir), 0.0f), shininess);
    std::cout << "spec: " << spec << std::endl;
    glm::vec3 specular = specularStrength * spec * lightColor;
    std::cout << "specular: " << specular.x << " " << specular.y << " " << specular.z << std::endl;

    glm::vec3 result = (ambient + diffuse + specular) * glm::vec3(1.0f, 0.5f, 0.31f);
    std::cout << "result: " << result.x << ", " << result.y << ", " << result.z << std::endl;

    glm::vec3 incomingRay = glm::vec3(0.0f, 1.0f, 1.0f);
    glm::vec3 normal = glm::vec3(0.0f, 1.0f, 0.0f);
    glm::vec3 reflect = glm::reflect(incomingRay, normal);
    std::cout << "reflect: " << reflect.x << ", " << reflect.y << ", " << reflect.z << std::endl;

}