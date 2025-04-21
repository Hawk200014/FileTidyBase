using FileTidyBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTidyBase.Controller
{
    class SortFolderController
    {
        private List<SortFolderModel> _sortFolders { get; set; } = new List<SortFolderModel>();

        public SortFolderController()
        {

        }

        public void AddSortFolder(string folderPath, string name)
        {
            var sortFolder = new SortFolderModel()
            {
                FolderPath = folderPath,
                Name = name,
                ID = _sortFolders.Count + 1
            };
            _sortFolders.Add(sortFolder);
        }

        public void RemoveSortFolder(int id)
        {
            var sortFolder = _sortFolders.FirstOrDefault(f => f.ID == id);
            if (sortFolder != null)
            {
                _sortFolders.Remove(sortFolder);
            }
        }

        public void RemoveSortFolder(string folderPath)
        {
            var sortFolder = _sortFolders.FirstOrDefault(f => f.FolderPath == folderPath);
            if (sortFolder != null)
            {
                _sortFolders.Remove(sortFolder);
            }
        }

        public void RemoveSortFolder(SortFolderModel sortFolder)
        {
            if (sortFolder != null)
            {
                _sortFolders.Remove(sortFolder);
            }
        }
    }
}
