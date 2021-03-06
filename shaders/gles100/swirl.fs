#version 100

precision mediump float;

varying vec2 fragTexCoord;

uniform sampler2D texture0;
uniform vec4 fragTintColor;

// NOTE: Add here your custom variables

const float renderWidth = 1280; 
const float renderHeight = 720; 

float radius = 250.0;
float angle = 0.8;

uniform vec2 center = vec2(200, 200);

void main (void)
{
    vec2 texSize = vec2(renderWidth, renderHeight);
    vec2 tc = fragTexCoord*texSize;
    tc -= center;
    float dist = length(tc);
    
    if (dist < radius) 
    {
        float percent = (radius - dist)/radius;
        float theta = percent*percent*angle*8.0;
        float s = sin(theta);
        float c = cos(theta);
        
        tc = vec2(dot(tc, vec2(c, -s)), dot(tc, vec2(s, c)));
    }
    
    tc += center;
    vec3 color = texture2D(texture0, tc/texSize).rgb;

    gl_FragColor = vec4(color, 1.0);;
}