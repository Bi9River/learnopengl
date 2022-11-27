# Cubemap

## something related to glBindTexture():

the following operations are all based on the most recently called(modified) texture by glBindTexture().

the newer glBindTexture() will override the last glBindTexture().

## Dynamic Environment Maps - Important! the website didn't discuss too much about this.

Dynamic environment maps
Right now we've been using a static combination of images as the skybox, which looks great, but it doesn't include the
actual 3D scene with possibly moving objects. We didn't really notice this so far, because we only used a single object.
If we had a mirror-like objects with multiple surrounding objects, only the skybox would be visible in the mirror as if
it was the only object in the scene.

Using framebuffers it is possible to create a texture of the scene for all 6 different angles from the object in
question and store those in a cubemap each frame. We can then use this (dynamically generated) cubemap to create
realistic reflection and refractive surfaces that include all other objects. This is called dynamic environment mapping,
because we dynamically create a cubemap of an object's surroundings and use that as its environment map.

While it looks great, it has one enormous disadvantage: we have to render the scene 6 times per object using an
environment map, which is an enormous performance penalty on your application. Modern applications try to use the skybox
as much as possible and where possible pre-render cubemaps wherever they can to still sort-of create dynamic environment
maps. While dynamic environment mapping is a great technique, it requires a lot of clever tricks and hacks to get it
working in an actual rendering application without too many performance drops.
