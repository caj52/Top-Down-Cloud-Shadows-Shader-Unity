# Top-Down-Cloud-Shadows-Shader-Unity

This is shader I wrote for the Tactical RPG Codename: Mystery Babylon

This shader utilizes a material equipped with a perlin noise image to create the effect of large clouds casting shadows overhead.
The custom script attached to the cloud plane syncs it up with the main camera when the Cam Scroll bool is set to true. What this does
is moves the offset of the material in the opposite direction according to the scroll speed value found on the script. This is done so the cloud plane can be a child of the 
main camera, but will still adjust the image in accordance to camera movement.

![CloudShadows](https://user-images.githubusercontent.com/80863542/149571504-c731552a-c870-41da-8b8c-53ae7381bbe0.png)
