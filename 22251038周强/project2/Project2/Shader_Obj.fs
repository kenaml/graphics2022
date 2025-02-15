#version 330 core
out vec4 color;

in vec3 FragPos;  
in vec3 Normal; 
in vec2 TexCoord;
  
uniform vec3 lightPos; 
uniform vec3 viewPos;
uniform vec3 lightColor;
// uniform vec3 objectColor;

uniform sampler2D earthTexture;

void main()
{
    vec3 objectColor = vec3(texture(earthTexture, TexCoord));
    
    // Ambient
    float ambientStrength = 0.1f;
    vec3 ambient = ambientStrength * lightColor;
  	
    // Diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;
    
    // Specular
    float specularStrength = 1.0f;  // ����ǿ��
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 16);
    vec3 specular = specularStrength * spec * lightColor;  
        
    // vec3 result = (ambient + diffuse + specular) * objectColor;
    vec3 result = (ambient + diffuse)  * objectColor;
    color = vec4(result, 1.0f);
} 