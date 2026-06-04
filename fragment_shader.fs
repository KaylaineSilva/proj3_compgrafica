#version 330 core

uniform vec4 color;
in vec2 out_texture;
uniform sampler2D imagem;
uniform bool usa_textura;

void main(){
    if (usa_textura) {
        gl_FragColor = texture(imagem, out_texture);
    } else {
        gl_FragColor = color;
    }
}