# instancing

## instancing的几种方法

- 普通：通过uniform来instancing（每个shader根据自己的gl_InstanceID去寻找自己的offset）
- instanced arrays: 通过layout(location=2) in vec2 aOffset 进行instancing（规避uniform数目有限的限制）
- 