cmake_minimum_required(VERSION 3.22)
project(LearnOpenGL01)

set(CMAKE_CXX_STANDARD 14)

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


add_executable(LearnOpenGL01 glm_main_chap8.cpp "src/glad.c")

target_link_libraries(LearnOpenGL01 glfw "-framework OpenGL")