# Face Culling

This chapter is quite simple and the only things to know are below:

glEnable(GL_CULL_FACE); // enable.
glCullFace(GL_BACK); // specify what kinds of face(s) do you want to cull. (GL_BACK vs GL_FRONT vs GL_FRONT_AND_BACK)
glFrontFace(GL_CW); // specify the order of vertices of the front face. (CW vs CCW)

That's all...