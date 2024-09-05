# Vital Preset Organizer

Vital Preset Organizer is a simple console application that reads `.vital` preset files from a specified folder, extracts the `preset_style` from each file, and organizes them into corresponding subfolders based on their style. This is particularly useful for managing large collections of presets for the Vital Audio Synthesizer.

## Features
- Automatically reads all `.vital` preset files from the specified folder.
- Extracts the `preset_style` from each preset file.
- Sorts the files into subfolders based on their preset style.
- Can be run from the command line, and organizes files in the parent folder of the executable.

## Prerequisites
- **.NET 8.0 (LTS)** or higher is required to build and run the project.
- The application assumes the `.vital` files are in a text-based format (like JSON or XML) and that the `preset_style` field is accessible.

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/mrbormeth/VitalFileSorting.git
   ```

2. **Open the project in Visual Studio**:
   - Open Visual Studio, and select **File -> Open -> Project/Solution**.
   - Navigate to the cloned repository folder and open the solution file (`VitalFileSorting.sln`).
     
3. **Install Dependencies**:
   - The project uses the `Newtonsoft.Json` library for JSON parsing. Install the package using NuGet:
     
     ```bash
     Install-Package Newtonsoft.Json
     ```
     
4. **Build the Project**:
   - Press **Ctrl + Shift + B** or go to **Build -> Build Solution** to build the project.
   - The `.exe` will be created in the `bin/Debug/net8.0/` folder (or `bin/Release/net8.0/` depending on your build configuration).

## Usage

1. **Run the Executable**:
   - Open the **Command Prompt** and navigate to the folder where the `.exe` is located:
     
     ```bash
     cd C:\Path\To\VitalFileSorting\bin\Debug\net8.0\
     ```
   - Run the `.exe`:
     
     ```bash
     VitalFileSorting.exe
     ```

2. **How the Application Works**:
   - The application scans the parent folder of the `.exe` for `.vital` files.
   - It extracts the `preset_style` from each file and creates a new subfolder in the parent directory based on that style.
   - All `.vital` files are moved to their respective folders based on their preset style.

### Example
Suppose the folder containing your `.vital` files looks like this:
```
/Presets/
  |- preset1.vital
  |- preset2.vital
  |- preset3.vital
```

After running the application, the folder will be organized like this:
```
/Presets/
  /SortedPresets/
    /Ambient/
      |- preset1.vital
    /Bass/
      |- preset2.vital
    /Leads/
      |- preset3.vital
```

## Customization

### Changing the Preset Style Parsing
- By default, the application assumes `.vital` files are JSON-based and extracts the `preset_style` using a JSON field.
- If the `.vital` files are in XML or another format, you'll need to modify the `ExtractPresetStyle` method in the `Program.cs` file to parse the relevant structure.

### Changing the Source Folder
- The application is set to read `.vital` files from the parent folder of where the `.exe` is running. You can modify the path logic in the `sourceDirectory` variable if you want to customize this behavior.

## Contributing

If you'd like to contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

## License

This project is licensed under the Creative Commons Attribution-NonCommercial 4.0 International (CC BY-NC 4.0) license.

You are free to:
- Share: Copy and redistribute the material in any medium or format.
- Adapt: Remix, transform, and build upon the material.
  
Under the following terms:
- Attribution: You must give appropriate credit, provide a link to the license, and indicate if changes were made. You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.
- NonCommercial: You may not use the material for commercial purposes.


## Contact

Feel free to contact me for any questions or suggestions:
- Instagram: https://www.instagram.com/brokenholiday/
