cmake_minimum_required(VERSION 3.22)
project(LearnOpenGL01)

set(CMAKE_CXX_STANDARD 17)

find_package(ZLIB REQUIRED)

if (NOT DEFINED ENV{GLFW_HOME})
    message(FATAL_ERROR "found no env named GLFW_HOME")
endif()

if (NOT DEFINED ENV{ASSIMP_HOME})
    message(FATAL_ERROR "found no env named ASSIMP_HOME")
endif ()

set(GLFW_HOME $ENV{GLFW_HOME})
set(ASSIMP_HOME $ENV{ASSIMP_HOME})

# 设置头文件目录
if(APPLE)
include_directories("${GLFW_HOME}/include")
include_directories("${ASSIMP_HOME}/include")
include_directories("include")
endif()

if(WIN32)
include_directories("${GLFW_HOME}/include")
include_directories("${ASSIMP_HOME}/include")
include_directories("include")
endif()

# 添加 GLFW3 预编译库

if(APPLE)
add_library(glfw SHARED IMPORTED)
SET_TARGET_PROPERTIES(glfw PROPERTIES IMPORTED_LOCATION "${GLFW_HOME}/lib/libglfw.3.dylib")

add_library(assimp SHARED IMPORTED)
SET_TARGET_PROPERTIES(assimp PROPERTIES IMPORTED_LOCATION "${ASSIMP_HOME}/lib/libassimp.dylib")
endif()

if(WIN32)
add_library(glfw SHARED IMPORTED)
SET_TARGET_PROPERTIES(glfw PROPERTIES IMPORTED_LOCATION "${GLFW_HOME}/lib/glfw3.lib")
set_target_properties(glfw PROPERTIES
    IMPORTED_IMPLIB_DEBUG "${GLFW_HOME}/lib/glfw3.lib"
    IMPORTED_IMPLIB_RELEASE "${GLFW_HOME}/lib/glfw3.lib"
)

add_library(assimp SHARED IMPORTED)
SET_TARGET_PROPERTIES(assimp PROPERTIES IMPORTED_LOCATION "${ASSIMP_HOME}/lib/assimp-vc143-mtd.lib")
set_target_properties(assimp PROPERTIES 
    IMPORTED_IMPLIB_DEBUG "${ASSIMP_HOME}/lib/assimp-vc143-mtd.lib"
    IMPORTED_IMPLIB_RELEASE "${ASSIMP_HOME}/lib/assimp-vc143-mtd.lib"
)

endif()

configure_file(configuration/root_directory.h.in configuration/root_directory.h)
include_directories(${CMAKE_BINARY_DIR}/configuration)

# add_executable(LearnOpenGL01 chapters/advanced_opengl/advanced_anti_aliasing_offscreen.cpp "src/glad.c" include/LearnOpenGL/camera.h)
add_executable(LearnOpenGL01 chapters/advanced_opengl/advanced_framebuffer.cpp "src/glad.c" include/LearnOpenGL/camera.h)

# test
# add_executable(LearnOpenGL01 test/test_phong.cpp "src/glad.c" include/LearnOpenGL/camera.h)

if(APPLE)
target_link_libraries(LearnOpenGL01 glfw "-framework OpenGL")
target_link_libraries(LearnOpenGL01 assimp)
endif()

if(WIN32)
target_link_libraries(LearnOpenGL01 glfw)
target_link_libraries(LearnOpenGL01 assimp)
target_link_libraries(LearnOpenGL01 ZLIB::ZLIB)

endif()