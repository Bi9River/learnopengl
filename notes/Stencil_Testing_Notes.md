# stencil test notes

## Some Functions

- `glStencilFunc(GLenum func, GLint ref, GLuint mask)` - sets the function, reference value and mask used for the
  stencil test
- `glStencilOp(GLenum sfail, GLenum dpfail, GLenum dppass)` - sets the stencil test actions for when the stencil test
  fails, the depth test fails and when both the stencil and depth tests pass
- `glStencilMask(GLuint mask)` - sets the mask used for writing to the stencil buffer
- `glClearStencil(GLint s)` - sets the value used when the stencil buffer is cleared
- `glClear(GLbitfield mask)` - clears the buffers specified by the mask
- `glEnable(GLenum cap)` - enables the specified capability
- `glDisable(GLenum cap)` - disables the specified capability

## Object Outlining

### steps

1. Enable stencil writing
2. Set tue stencil op to GL_ALWAYS before drawing the (to be outlined) objects, updating the stencil buffer with 1s(
   which means all 1) wherever the object's fragments are rendered.
3. Render the objects.
4. Disable stencil writing and depth testing
5. Scale each of the objects by a small amount.
6. Use a different fragment shader that outputs a single (border) color.
7. Draw the objects again, but only if their fragments' stencil values are not equal to 1.
8. Enable depth testing again and restore stencil func to GL_KEEP.

