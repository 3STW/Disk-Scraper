using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disk_Scraper
{
    public partial class CleanerForm : Form
    {
        // Import the necessary Windows API functions
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        // Import the AllocConsole function from kernel32.dll
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        public CleanerForm()
        {
            InitializeComponent();
        }

        private void StartCleanBtn_Click(object sender, EventArgs e)
        {
            AllocConsole();
            CleanTempFiles();
        }

        public void CleanTempFiles()
        {
            try
            {
                // Get the path to the system temporary folder
                string systemTempFolder = Path.GetTempPath();
                string userTempFolder = Environment.GetEnvironmentVariable("TEMP");
                string prefetchFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string CustomDirFolder = CustomDirectory.Text;
                string CustomDirFolder2 = CustomDirectory2.Text;
                string CustomDirFolder3 = CustomDirectory3.Text;

                /* yesterday i add Vs Files,
                Temp Files,
                Prefetch Files,
                Download Files ,
                and CustomDir Files
                Deletion
                 */


                // Add Log File deleter today



                CleanerProgressBar.Value = 10;

                // Clean System Temp Folder
                if (TempFilesCheckbox.Checked)
                {
                    // Cleans System Temp Folder
                    CleanFolder(systemTempFolder);
                    CleanerProgressBar.Value = 20;

                    // Clean User Temp Folder
                    CleanFolder(userTempFolder);
                    CleanerProgressBar.Value = 30;
                }


                if (PrefetchCheckBox.Checked)
                {
                    // Clean Prefetch Folder
                    CleanFolder(prefetchFolder);
                    CleanerProgressBar.Value = 50;
                }

                if (DownloadsCheckBox.Checked)
                {

                    CleanFolder(downloadsPath);

                    CleanerProgressBar.Value = 60;
                }


                if (CustomPathCheckBox.Checked)
                {
                    if (Directory.Exists(CustomDirFolder))
                    {
                        CleanFolder(CustomDirFolder);
                    }
                    else
                    {
                        MessageBox.Show("Directory does not exist !");
                    }

                    CleanerProgressBar.Value = 65;
                }

                if (CustomPathCheckBox2.Checked)
                {

                    if (Directory.Exists(CustomDirFolder2))
                    {
                        CleanFolder(CustomDirFolder2);
                    }
                    else
                    {
                        MessageBox.Show("Directory does not exist !");
                    }

                    CleanerProgressBar.Value = 70;
                }

                if (CustomPathCheckBox3.Checked)
                {

                    if (Directory.Exists(CustomDirFolder3))
                    {
                        CleanFolder(CustomDirFolder3);
                    }
                    else
                    {
                        MessageBox.Show("Directory does not exist !");
                    }

                    CleanerProgressBar.Value = 75;
                }



                if (VsFilesCheckBox.Checked)
                {
                    DeleteVsFiles();
                    CleanerProgressBar.Value = 80;
                }


                if(LogFilesCheckBox.Checked)
                {
                    DeleteLogAndTraceFilesFromAllDrives();
                }


                CleanerProgressBar.Value = 100;
                Console.WriteLine("Temporary files cleanup completed.");


                // Open Folders

                if(OpenDirsCheckBox.Checked)
                {
                    if (TempFilesCheckbox.Checked)
                    {
                        OpenDirectory(systemTempFolder);
                        OpenDirectory(userTempFolder);
                    }
                    if (PrefetchCheckBox.Checked)
                    {
                        OpenDirectory(prefetchFolder);
                    }

                    if (CustomPathCheckBox.Checked)
                    {
                        OpenDirectory(CustomDirFolder);
                    }

                    if (CustomPathCheckBox2.Checked)
                    {
                        OpenDirectory(CustomDirFolder2);
                    }

                    if (CustomPathCheckBox3.Checked)
                    {
                        OpenDirectory(CustomDirFolder3);
                    }

                    if (DownloadsCheckBox.Checked)
                    {
                        OpenDirectory(downloadsPath);
                    }
                }

                Console.WriteLine("30s till console Disable");
                Thread.Sleep(30000);
                FreeConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during cleanup: {ex.Message}");
            }
        }



        // Helper method to clean the contents of a folder
        private static void CleanFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (string file in files)
                    {
                        try
                        {
                            File.Delete(file);
                            Console.WriteLine($"Deleted: {file}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to delete {file}: {ex.Message}");
                        }
                    }

                    // Optionally delete subdirectories
                    string[] directories = Directory.GetDirectories(folderPath);
                    foreach (string dir in directories)
                    {
                        try
                        {
                            Directory.Delete(dir, true); // Delete directory and its contents
                            Console.WriteLine($"Deleted directory: {dir}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to delete directory {dir}: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"The folder {folderPath} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cleaning folder {folderPath}: {ex.Message}");
            }
        }

        public static void OpenDirectory(string directoryPath)
        {
            try
            {
                // Check if the directory exists
                if (Directory.Exists(directoryPath))
                {
                    // Open the directory using the default file explorer
                    Process.Start("explorer.exe", directoryPath);
                    Console.WriteLine($"Opened directory: {directoryPath}");
                }
                else
                {
                    Console.WriteLine($"The directory {directoryPath} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while opening the directory: {ex.Message}");
            }
        }

        public static void DeleteVsFiles()
        {
            try
            {
                // Get all drives (e.g., C:, D:, E:)
                string[] drives = Environment.GetLogicalDrives();

                foreach (string drive in drives)
                {
                    Console.WriteLine($"Searching drive: {drive}");
                    // Start the recursive search in each drive
                    SearchAndDeleteVsFiles(drive);
                }

                Console.WriteLine("Search and cleanup completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Recursively search for .vs files and delete them
        private static void SearchAndDeleteVsFiles(string directory)
        {
            try
            {
                // Skip system directories and files that can't be accessed
                if (directory.Contains("$RECYCLE.BIN") || directory.Contains("System Volume Information"))
                    return;

                // Search for .vs files in the current directory
                string[] vsFiles = Directory.GetFiles(directory, "*.vs", SearchOption.TopDirectoryOnly);

                foreach (string file in vsFiles)
                {
                    try
                    {
                        Console.WriteLine($"Deleting file: {file}");
                        File.Delete(file); // Delete the .vs file
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete {file}: {ex.Message}");
                    }
                }

                // Recursively search in subdirectories
                string[] directories = Directory.GetDirectories(directory);
                foreach (string dir in directories)
                {
                    SearchAndDeleteVsFiles(dir); // Recurse into subdirectories
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle permissions issues (e.g., access denied on some folders)
                Console.WriteLine($"Access denied to: {directory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {directory}: {ex.Message}");
            }
        }


        public static void DeleteLogAndTraceFilesFromAllDrives()
        {
            try
            {
                // Get all drives on the system
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    // Skip the drive if it's not ready (e.g., CD/DVD drives or network drives)
                    if (!drive.IsReady) continue;

                    Console.WriteLine($"Searching drive: {drive.Name}");

                    // Delete .log files and .trc files from the root of the drive and its subdirectories
                    DeleteFilesByExtension(drive.Name, "*.log");
                    DeleteFilesByExtension(drive.Name, "*.trc");
                }

                Console.WriteLine("Log and trace files deletion complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Helper method to delete files by extension in all directories under a given directory
        private static void DeleteFilesByExtension(string directoryPath, string filePattern)
        {
            try
            {
                // Get all files matching the pattern (recursively)
                string[] files = Directory.GetFiles(directoryPath, filePattern, SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    try
                    {
                        Console.WriteLine($"Deleting file: {file}");
                        File.Delete(file);  // Delete the file
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not delete {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory {directoryPath}: {ex.Message}");
            }
        }





        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
