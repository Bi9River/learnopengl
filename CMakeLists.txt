cmake_minimum_required(VERSION 3.22)
project(LearnOpenGL01)

set(CMAKE_CXX_STANDARD 17)

if (NOT DEFINED ENV{GLFW_HOME})
    message(FATAL_ERROR "found no env named GLFW_HOME")
endif()

if (NOT DEFINED ENV{ASSIMP_HOME})
    message(FATAL_ERROR "found no env named ASSIMP_HOME")
endif ()

set(GLFW_HOME $ENV{GLFW_HOME})
set(ASSIMP_HOME $ENV{ASSIMP_HOME})

# 设置头文件目录
include_directories("${GLFW_HOME}/include")
include_directories("${ASSIMP_HOME}/include")
include_directories("include")

# 添加 GLFW3 预编译库
add_library(glfw SHARED IMPORTED)
SET_TARGET_PROPERTIES(glfw PROPERTIES IMPORTED_LOCATION "${GLFW_HOME}/lib/libglfw.3.dylib")

add_library(assimp SHARED IMPORTED)
SET_TARGET_PROPERTIES(assimp PROPERTIES IMPORTED_LOCATION "${ASSIMP_HOME}/lib/libassimp.dylib")

configure_file(configuration/root_directory.h.in configuration/root_directory.h)
include_directories(${CMAKE_BINARY_DIR}/configuration)

add_executable(LearnOpenGL01 chapters/advanced_opengl/advanced_anti_aliasing_offscreen.cpp "src/glad.c" include/LearnOpenGL/camera.h)
# test
# add_executable(LearnOpenGL01 test/test_phong.cpp "src/glad.c" include/LearnOpenGL/camera.h)

target_link_libraries(LearnOpenGL01 glfw "-framework OpenGL")
target_link_libraries(LearnOpenGL01 assimp)