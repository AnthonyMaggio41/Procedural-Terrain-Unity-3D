# Procedural Terrain Generator

This code generates terrain in Unity 3D using simplex noise. The generated terrain can be used in a variety of applications, including games, simulations, and visualizations.

## Features

![Player Walking in Terrain](readme_resources/FINAL_WALK_GIF.gif)
-    Easy to use: Simply drop the script onto a game object and specify the parameters in the inspector.
![Different Types of Terrain](readme_resources/FINAL_JUMP_GIF.gif)
-   Customizable: Modify the terrain size, height, and appearance by adjusting the script parameters.
![Customization Sliders](readme_resources/FINAL_SLIDER_GIF.gif)
-   Flexible: Use the generated terrain as a standalone object, or incorporate it into larger projects.

## Getting Started

To use the terrain generator, follow these steps:

1.  Drag the `TerrainGenerator` script onto a game object in your Unity scene.
2.  In the inspector, modify the script parameters to customize the terrain.
3.  Press the "Generate" button to create the terrain.

## Script Parameters

The following parameters can be adjusted to customize the generated terrain:

-   **Terrain Size:** The size of the terrain in the X and Z dimensions.
-   **Height Range:** The minimum and maximum height of the terrain.
-   **Noise Scale:** The scale of the simplex noise used to generate the terrain.
-   **Seed:** The seed for the random number generator used to create the noise.
-   **Material:** The material applied to the terrain.

## Tips

-   Larger terrain sizes may take longer to generate.
-   A smaller noise scale will result in smoother terrain, while a larger scale will create more rugged terrain.
-   Changing the seed will create different terrain each time the script is run.

## Examples

Here are a few examples of how terrain is generated using the script:

(Console output pictures)

## Credits
This code was created in part by using the following resources:
