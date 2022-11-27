# Framebuffer

## when to use Renderbuffer:

The general rule is that if you never need to sample data from a specific buffer, it is wise to use a renderbuffer
object for that specific buffer. If you need to sample data from a specific buffer like colors or depth values, you
should use a texture attachment instead.

The advantage of using additional framebuffer: the entire scene is rendered to a single texture, so we can create cool
post-procesing effects