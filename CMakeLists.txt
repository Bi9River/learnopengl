cmake_minimum_required(VERSION 3.22)
project(LearnOpenGL01)

set(CMAKE_CXX_STANDARD 17)

if (NOT DEFINED ENV{GLFW_HOME})
    message(FATAL_ERROR "found no env named GLFW_HOME")
endif()

set(GLFW_HOME $ENV{GLFW_HOME})

# 设置头文件目录
include_directories("${GLFW_HOME}/include")
include_directories("include")

# 添加 GLFW3 预编译库
add_library(glfw SHARED IMPORTED)
SET_TARGET_PROPERTIES(glfw PROPERTIES IMPORTED_LOCATION "${GLFW_HOME}/lib/libglfw.3.dylib")


add_executable(LearnOpenGL01 Chapters/Lighting_Chap_12_to_18/lighting_main.cpp "src/glad.c" include/LearnOpenGL/camera.h)
# test
# add_executable(LearnOpenGL01 test/test_phong.cpp "src/glad.c" include/LearnOpenGL/camera.h)

target_link_libraries(LearnOpenGL01 glfw "-framework OpenGL")