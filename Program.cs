using Newtonsoft.Json;

namespace VitalFileOrganizer {
    class Program {
        static void Main(string[] args) {
            // Use the folder where the executable is run as the source directory
            string sourceDirectory = AppDomain.CurrentDomain.BaseDirectory;  // Root folder (where the exe is running)
            string destinationBaseDirectory = Path.Combine(sourceDirectory, "SortedPresets");  // Subfolder for sorted presets

            // Get all .vital files in the source directory and its subdirectories
            string[] vitalFiles = Directory.GetFiles(sourceDirectory, "*.vital", SearchOption.AllDirectories);


            // Cache directory existence checks
            var createdDirectories = new HashSet<string>();

            foreach (var file in vitalFiles) {
                try {
                    // Read the file contents (assuming it's a text-based format like JSON or XML)
                    string fileContent = File.ReadAllText(file);

                    // Extract the preset style (assuming JSON format here for demonstration)
                    string presetStyle = ExtractPresetStyle(fileContent);

                    // Create destination folder based on preset style
                    string destinationFolder = Path.Combine(destinationBaseDirectory, presetStyle);

                    if (!createdDirectories.Contains(destinationFolder)) {
                        Directory.CreateDirectory(destinationFolder);
                        createdDirectories.Add(destinationFolder);
                    }

                    // Move the file to the respective folder
                    string destinationFile = Path.Combine(destinationFolder, Path.GetFileName(file));
                    File.Move(file, destinationFile);

                    Console.WriteLine($"Moved '{file}' to '{destinationFolder}'");
                } catch (Exception ex) {
                    Console.WriteLine($"Error processing file '{file}': {ex.Message}");
                }
            }
            Console.WriteLine("Sorting complete!");
            // Wait for the user to press Enter
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        // Function to extract the preset style from the file content (assuming JSON for this example)
        static string ExtractPresetStyle(string fileContent) {
            // Example JSON structure for .vital file
            // {
            //   "preset_name": "Cool Sound",
            //   "preset_style": "Ambient",
            //   ...
            // }
            dynamic vitalPreset = JsonConvert.DeserializeObject(fileContent);
            return vitalPreset.preset_style ?? "Unknown";  // Return "Unknown" if style is not found
        }
    }
}