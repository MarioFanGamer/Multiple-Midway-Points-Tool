Multiple Midway Point Tool
by Manuel B. aka MarioFanGamer
Managing multiple midway points in SMW has never been easier

General readme:
Let's be honest: As awesome as Multiple Midway Points is, it has got one flaw: The midway point table requires that each level uses the same amount of midway points and there is no level pointer table. When I added support for 0x2000 secondary exits for Multiple Midway Points, I also added a python script for an easier generation of the midway point tables.
The problem: It doesn't actually resize it but rather creates a new table. With a better understanding in programming, my tool fixes it by being able to read a single line and store the result into a 96 by 256 matrix (96 levels and 256 midway points per level). It then creates a multi_midway_table.asm depending on which level has got the most midway points. That way you have less problems in managing midway points. You can even store the midway points into a binary file separate from the ASM table (extension is by default .mmp, naturally, but .bin files also are valid).
It also is an interface to the midway point values so you don't have to calculate the final values manually (in fact, you can't) so you only need to enter the destination and the checkboxes secondary exit and water level.
Another ability is that it can use it to patch a SMW ROM. In order to do so, have the patch files in the same folder as the tool. Other then that, the same rules as Multiple Midway Points apply.

Developer readme:
The kernel and GUI are separate in order to follow the guideline to separate interface from code (granted, it can be separated even further with WPF but I haven't learned to use it). This is especially important if you want to port this software to Linux and MacOS as the GUI uses .NET Framework and Windows Forms which are Windows exclusive. The kernel, however, uses .NET Standard (not to be confused with .NET Framework) which can be used on other OS and even if that doesn't work, you still can take the source and put it in a Mono or .NET Core project or compile them there.
Here are the contents which is handled by each component: The GUI only handles the midway point settings, file import and export (but not creation) Asar interaction whereas the DLL contains the Midway Point struct (yes, I used a struct, not a class, fight me), functions to get a midway point from values, transform it into a string, create an array of bytes or a multi_midway_table.asm from an array of midway points and vice versa (size is fixed), etc. As you can see, the majority of the work is handled by Midway.dll, not MMP.exe.

In addition, I released Midway.dll under the LGPL which means you don't necessarily need to release your software as LGPL or GPL if you you have Midway.dll separate from your program.

Some standards to keep in mind:
Each .mmp file starts with a six byte header. That header is "MMP" + major version + minor version + bugfix version (the version number is a single byte each).
Let's say, you have Midway.dll in Version 1.1.0. In that case, the header is (starts with) 4D 4D 50 01 01 01 ("MMP" + 1.1.0).
Next, each midway point is stored as two bytes of the destination number (little endian), secondary exit flag and water level flag (four bytes in total). There is no midway point counter but the size of that file is so minimal compared to a single HDD (it shouldn't even surpass your ROM size), not to mention the size of each midway point array is fixed (96 levels by 256 midway points).
Finally, the array is a 96 by 256 matrix.
