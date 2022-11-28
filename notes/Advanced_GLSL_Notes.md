# Advanced_GLSL notes

## Built-in Variable in GLSL

https://www.khronos.org/opengl/wiki/Built-in_Variable_(GLSL)

### Vertex Shader Variables

- gl_PointSize
- gl_VertexID

### Fragment Shader Variables

- gl_FragCoord
- gl_FrontFacing
- gl_FragDepth
    - layout (depth_<condition>) out float gl_FragDepth; important! only use after opengl 4.2

## Inerface Blocks

useful when sending data from vertex shader to fragment shader.

## Uniform Buffer Objects

std140 layout rules

complete rules: https://registry.khronos.org/OpenGL/extensions/ARB/ARB_uniform_buffer_object.txt

common rules: (4 bytes as N)
| Type | Layout rule |
| Scalar | e.g. int or bool Each scalar has a base alignment of N. |
| Vector | Either 2N or 4N. This means that a vec3 has a base alignment of 4N. |
| Array of | scalars or vectors Each element has a base alignment equal to that of a vec4. |
| Matrices | Stored as a large array of column vectors, where each of those vectors has a base alignment of vec4. |
| Struct | Equal to the computed size of its elements according to the previous rules, but padded to a multiple of the
size of a vec4. |

With these calculated offset values, based on the rules of the std140 layout, we can fill the buffer with data at the
appropriate offsets using functions like glBufferSubData.

While not the most efficient, the std140 layout does guarantee us that the memory layout remains the same over each
program that declared this uniform block.

Uniform buffer objects have several advantages over single uniforms：

- First, setting a lot of uniforms at once is faster than setting multiple uniforms one at a time.
- Second, if you want to change the same uniform over several shaders, it is much easier to change a uniform once in a
  uniform buffer.
- One last advantage that is not immediately apparent is that you can use a lot more uniforms in shaders using uniform
  buffer objects.

OpenGL has a limit to how much uniform data it can handle which can be queried with GL_MAX_VERTEX_UNIFORM_COMPONENTS.
When using uniform buffer objects, this limit is much higher.
So whenever you reach a maximum number of uniforms (when doing skeletal animation for example) there's always uniform
buffer objects. [wait for further test and verify]