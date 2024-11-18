![Fog](https://github.com/user-attachments/assets/47c901e4-3478-4e8d-96be-228a8f614934)

# Gradient-Based Stylized Fog Post Processing
![Unity Version](https://img.shields.io/badge/Unity-6000.0.27%27LTS%2B-blueviolet?logo=unity)
![Unity Pipeline Support (Built-In)](https://img.shields.io/badge/BiRP_❌-darkgreen?logo=unity)
![Unity Pipeline Support (URP)](https://img.shields.io/badge/URP_✔️-blue?logo=unity)
![Unity Pipeline Support (HDRP)](https://img.shields.io/badge/HDRP_❌-darkred?logo=unity)
 
A simple gradient based/multicolor fog effect, inspired by Firewatch's gradient based fog effect. It was created for Unity URP (6000.0.27f1) and for Serious Point Games as part of my studies in shader development.
It could theoretically run on Unity 2022 since its using the same code I used for the effects's render feature and pass within Unity 2022, but it is untested.

You can refer to the effect's documentation for more info (should be in the repo and its release as a PDF file).

## Features
- Can use 5 seperate color inputs or a gradient texture for the fog colors
- Can adjust overall fog intensity and additional fog intensity for different distance related parts of the fog
- Support for Unity 6
- Includes some optional scripts by LKHGames to create Gradient Textures for the effect (the repo inlcudes a gradient texture as a demostration example)

## Example[s]
![Fog](https://github.com/user-attachments/assets/48e341d1-7dde-493d-87c2-0081d917a79a)
Multi Fog Effect (using 5 Seperate Color Inputs)
<br>
<br>
![image](https://github.com/user-attachments/assets/c0ad7aac-7531-4571-aa63-e40ef5504900)
<br>
Multi Fog Effect (using a gradient texture)

## Installation
1. Clone repo or download the folder and load it into an unity project.
2. Create a material with the effect's shader graph, or use the provided one.
3. Ensure that under the project settings > graphics > Render Graph, you enable Compatibility Mode on (meaning you have Render Graph Disabled).
4. Add the render feature of the multicolor fog effect to the Universal Renderer Data you are using.
5. Input the effect material (from 2.) into the material field in the effect's renderer feature.
6. If needed, you can change the effect's render pass event in its render feature under settings.
7. Adjust the fog's parameter within the material itself or use the volume component of the Multicolor Fog Effect in your volume profile to adjust the parameters.

## Known Issue
To enhance immersion, our fog effect can blend with background objects, particularly those that are farther away. However, because the skybox is considered extremely distant
due to camera depth, the fog can sometimes overpower it, causing the skybox's color to shift to match that of the fog. To mitigate this effect, the alpha value of the far 
fog color is set to 0 by default.

Users have the option to adjust the alpha value of the far fog color to a setting greater than 0 to reintroduce the far fog feature. Fine-tuning the fog parameters to make 
the fog less apparent can help avoid these issues. Additionally, the fog can interfere with certain effects, such as fake volumetric spotlights. However, as mentioned, users 
can minimize these conflicts by fine-tuning the fog settings.

## Credits/Assets used
Some of the shadergraph code is based from Paulo Vilela’s take on stylized multi-coloured fog in ShaderGraph Youtube Video [YouTube Video Link](https://www.youtube.com/watch?v=YDT9s3nNVj0).
<br>
<br>
"Mossy/Grassy Landscape" (https://skfb.ly/6RYvL) by Šimon Ustal is licensed under Creative
Commons Attribution (http://creativecommons.org/licenses/by/4.0/). No changes made.
(The mountain landscape that you see in the screenshots for demonstration/screenshot purposes only, not included in the repo files)
