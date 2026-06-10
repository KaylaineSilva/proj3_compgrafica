#version 330 core

in vec2 out_texture;
in vec3 FragPos;
in vec3 Normal;

out vec4 fragColor;
uniform bool desenhandoSombra;
uniform sampler2D samplerTexture;
uniform bool usa_textura;

uniform vec3 viewPos;

uniform bool recebeIluminacao;
uniform bool recebeSol;
uniform bool recebeFogo;

uniform bool luzSolLigada;
uniform bool luzFogoLigada;
uniform bool luzAmbienteLigada;

uniform vec3 solPos;
uniform vec3 fogoPos;

uniform vec3 solColor;

uniform float intensidadeAmbiente;
uniform float difusaGlobal;

uniform vec3 materialAmbient;
uniform float materialDiffuse;
uniform float materialSpecular;
uniform float materialShininess;

uniform bool recebeFilosofia;
uniform bool luzFilosofiaLigada;

uniform vec3 filosofiaPos;
uniform vec3 filosofiaDir;
uniform vec3 filosofiaColor;

uniform float intensidadeFilosofia;
uniform float especularGlobal;

vec3 calculaLuzPontual(
    vec3 lightPos,
    vec3 lightColor,
    vec3 normal,
    vec3 fragPos,
    vec3 viewDir,
    vec3 baseColor
)
{
    vec3 lightDir = normalize(lightPos - fragPos);

    float diff = max(dot(normal, lightDir), 0.0);

    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), materialShininess);

    float distance = length(lightPos - fragPos);
    float attenuation = 1.0 / (1.0 + 0.03 * distance + 0.004 * distance * distance);

    vec3 diffuse = lightColor * diff * materialDiffuse * difusaGlobal * baseColor;
    vec3 specular = lightColor * spec * materialSpecular * especularGlobal;
    
    return (diffuse + specular) * attenuation;
}

vec3 calculaLuzSpot(
    vec3 lightPos,
    vec3 lightDir,
    vec3 lightColor,
    vec3 normal,
    vec3 fragPos,
    vec3 viewDir,
    vec3 baseColor
)
{
    vec3 fragToLight = normalize(lightPos - fragPos);
    vec3 lightToFrag = normalize(fragPos - lightPos);

    float theta = dot(lightToFrag, normalize(lightDir));

    float innerCutOff = cos(radians(10.0));
    float outerCutOff = cos(radians(22.0));

    float epsilon = innerCutOff - outerCutOff;
    float spot = clamp((theta - outerCutOff) / epsilon, 0.0, 1.0);

    float diff = max(dot(normal, fragToLight), 0.0);

    vec3 reflectDir = reflect(-fragToLight, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), materialShininess);

    float distance = length(lightPos - fragPos);
    float attenuation = 1.0 / (1.0 + 0.04 * distance + 0.01 * distance * distance);

    vec3 diffuse = lightColor * diff * materialDiffuse * difusaGlobal * baseColor;
    vec3 specular = lightColor * spec * materialSpecular * especularGlobal;

    vec3 luzIndiretaDoFeixe = 0.08 * lightColor * baseColor;

    return (diffuse + specular + luzIndiretaDoFeixe) * attenuation * spot;
}

void main()
{
    if (desenhandoSombra)
    {
        fragColor = vec4(0.0, 0.0, 0.0, 0.65);
        return;
    }

    vec3 baseColor;

    if (usa_textura)
        baseColor = vec3(texture(samplerTexture, out_texture));
    else
        baseColor = vec3(1.0, 1.0, 1.0);

    if (!recebeIluminacao)
    {
        fragColor = vec4(baseColor, 1.0);
        return;
    }

    vec3 norm = normalize(Normal);
    vec3 viewDir = normalize(viewPos - FragPos);

    vec3 resultado = vec3(0.0);

    if (luzAmbienteLigada)
    {
        resultado += intensidadeAmbiente * materialAmbient * baseColor;
    }

    if (luzSolLigada && recebeSol)
    {
        resultado += 1.8 * calculaLuzPontual(
            solPos,
            solColor,
            norm,
            FragPos,
            viewDir,
            baseColor
        );
    }

    if (luzFogoLigada && recebeFogo)
    {
        resultado += calculaLuzPontual(
            fogoPos,
            vec3(1.0, 0.35, 0.05),
            norm,
            FragPos,
            viewDir,
            baseColor
        );
    }

    if (luzFilosofiaLigada && recebeFilosofia)
    {
        resultado += intensidadeFilosofia * calculaLuzSpot(
            filosofiaPos,
            filosofiaDir,
            filosofiaColor,
            norm,
            FragPos,
            viewDir,
            baseColor
        );
    }

    fragColor = vec4(resultado, 1.0);
}