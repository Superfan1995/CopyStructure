using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace CopyStructure
{
    public partial class CopyStructForm : Form
    {
        // current path of selected directory
        string currentParentPath;

        // file stucture of selected directory
        DirectoryStructClass directoryStruct;

        public CopyStructForm()
        {
            InitializeComponent();

            // disable save function
            DisableSave();

            // set fullFileStruct to null
            directoryStruct = null;
        }

        // Select a Directory that user want to copy its structure to else where
        private void copyStructureButton_Click(object sender, EventArgs e)
        {
            // user use FolderBrowserDialog to select a forlder
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (IsDirectory(fbd.SelectedPath))
                {

                    try
                    {
                        // Get path of the selected Directory's parents directory
                        DirectoryInfo directory = new DirectoryInfo(fbd.SelectedPath).Parent;
                        currentParentPath = directory.FullName;

                        // get the selected directory's file structure
                        directoryStruct = GetDirectoriesStruct(fbd.SelectedPath);

                        // Enable saving function, set the default new project name
                        if (SelectedDirectoryValid())
                        {
                            MessageBox.Show("File Structure Recored Successfully");

                            newNameTextBox.Text = directoryStruct.DirectoryName + " Struct Copy";
                            directoryStruct.DirectoryName = newNameTextBox.Text;

                            EnableSave();
                        }

                        else
                        {
                            MessageBox.Show("Error: Target Is Not a Directory");
                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Cannot copy the file structure");
                    }

                }

                else
                {
                    MessageBox.Show("Error: Target Is Not A Directory");
                }

            }
        }

        // Save new project data structure at original target's Directory
        private void saveSameButton_Click(object sender, EventArgs e)
        {
            CopyDirectoriesStruct(currentParentPath);
        }

        // Save new project data structure at a user selected Directory
        private void saveNewButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (IsDirectory(fbd.SelectedPath))
                {
                    CopyDirectoriesStruct(fbd.SelectedPath);
                }

                else
                {
                    MessageBox.Show("Error: Target Is Not A Directory");
                }

            }
        }

        private void newNameTextBox_TextChanged(object sender, EventArgs e)
        {
            directoryStruct.DirectoryName = newNameTextBox.Text;
        }

        // record the file structure of input directory and its subdirectory
        private DirectoryStructClass GetDirectoriesStruct(string selectedPath)
        {
            // create and store the file structure of this directory
            DirectoryStructClass fileStruct = new DirectoryStructClass(GetDirectoryName(selectedPath));

            DirectoryInfo currentDirectory = new DirectoryInfo(selectedPath);
            DirectoryInfo[] directories = currentDirectory.GetDirectories();

            // find and store the file structure of subdirectory
            foreach (DirectoryInfo subDirectory in directories)
            {
                DirectoryStructClass subFileStruct = GetDirectoriesStruct(subDirectory.FullName);

                fileStruct.AddSubDirectory(subFileStruct);
            }

            return fileStruct;
        }

        // Get the name of folder with the input Path
        private string GetDirectoryName(string selectedPath)
        {
            string FolderName = new DirectoryInfo(selectedPath).Name;

            return FolderName;
        }

        // create new file structure Struct
        private void CopyDirectoriesStruct(string selectedPath)
        {
            if (NotDuplicatedDirectory(selectedPath, newNameTextBox.Text))
            {
                try
                {
                    CreateDirectories(selectedPath, directoryStruct);

                    DisableSave();
                    directoryStruct = null;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Cannot Save the File Structure At Target Directory");
                }
            }

            else
            {
                MessageBox.Show("Error: The Directory already exist");
            }

        }

        // create Directory and its subDirectory
        private void CreateDirectories(string selectedPath, DirectoryStructClass currentDirectoryStruct)
        {
            string newDictory = CreateDirectory(selectedPath, currentDirectoryStruct.DirectoryName);

            ICollection<DirectoryStructClass> subDirectoryStructs = currentDirectoryStruct.SubDirectories;

            foreach (DirectoryStructClass subDirectoryStruct in subDirectoryStructs)
            {
                CreateDirectories(newDictory, subDirectoryStruct);
            }
        }

        // create new Directory at selected path with given folder name, return path to the new directory
        private string CreateDirectory(string selectedPath, string directoryName)
        {
            string newDirectory = selectedPath + "/" + directoryName;
            Directory.CreateDirectory(newDirectory);

            return newDirectory;
        }

        // check whether the name of the folder not exist in the selected path
        private Boolean NotDuplicatedDirectory(string selectedPath, string directoryName)
        {
            if (Directory.Exists(selectedPath + "/" + directoryName))
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // check whether the selected path is a folder
        private Boolean IsDirectory(string selectPath)
        {
            if (Directory.Exists(selectPath))
            {
                return true;
            }

            else if (File.Exists(selectPath))
            {
                return false;
            }

            else
            {
                return false;
            }
        }

        // check whether a valid file struct already saved
        private Boolean SelectedDirectoryValid()
        {
            if (directoryStruct == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // disable save function
        private void DisableSave()
        {
            newNameLabel.Enabled = false;
            newNameTextBox.Enabled = false;
            saveSameButton.Enabled = false;
            SaveNewButton.Enabled = false;
        }

        // enable save function
        private void EnableSave()
        {
            newNameLabel.Enabled = true;
            newNameTextBox.Enabled = true;
            saveSameButton.Enabled = true;
            SaveNewButton.Enabled = true;
        }
    }

}