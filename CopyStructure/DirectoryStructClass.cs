using System;
using System.Collections.Generic;

namespace CopyStructure
{

    // Data structure used to store the Name of the Folder and data structure of all its child Folder
    class DirectoryStructClass
    {
        // Name of Foldet
        private string directoryName;

        // Collection of all Child
        private ICollection<DirectoryStructClass> subDirectories;

        public DirectoryStructClass(string newFolderName)
        {
            this.DirectoryName = newFolderName;
            subDirectories = new List<DirectoryStructClass>(); 
        }

        // get and set DirectoryName
        public string DirectoryName
        {
            get
            {
                return this.directoryName;
            }

            set
            {
                this.directoryName = value;
            }
        }

        // get the FileStructClass
        public ICollection<DirectoryStructClass> SubDirectories
        {
            get
            {
                return this.subDirectories;
            }
        }

        // check whether this class have child FileStructClass
        public Boolean HasSubDirectories()
        {
            if (subDirectories.Count == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // store a child FileStructClass
        public void AddSubDirectory(DirectoryStructClass childFolder)
        {
            subDirectories.Add(childFolder);
        }
    }
}
