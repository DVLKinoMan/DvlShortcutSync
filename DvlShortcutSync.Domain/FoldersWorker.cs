using IWshRuntimeLibrary;
using System.IO;
using System.Linq;

namespace DvlShortcutSync.Domain
{
    public static class FoldersWorker
    {
        public static void Sync2Folders(string path1, string path2)
        {
            var firstFiles = Directory.GetFiles(path1);
            var secondFiles = Directory.GetFiles(path2);

            foreach (var flForShortcut in firstFiles
                .Where(fl => secondFiles.All(scFl => !AreEqual(scFl, fl))))
                CreateShortcut(path2, flForShortcut);

            foreach (var flForShortcut in secondFiles
                .Where(fl => firstFiles.All(scFl => !AreEqual(scFl,fl))))
                CreateShortcut(path1, flForShortcut);

            var firstDirectories = Directory.GetDirectories(path1);
            var secondDirectories = Directory.GetDirectories(path2);

            foreach (var dir in firstDirectories
                .Where(fl => secondDirectories.All(scFl => !AreEqual(scFl, fl))))
            {
                var newDir = Path.Combine(path2, Path.GetFileName(dir));
                Directory.CreateDirectory(newDir);
                TrySync(dir, newDir);
            }

            foreach (var dir in secondDirectories
                .Where(fl => firstDirectories.All(scFl => !AreEqual(scFl, fl))))
            {
                var newDir = Path.Combine(path1, Path.GetFileName(dir));
                Directory.CreateDirectory(newDir);
                TrySync(dir, newDir);
            }

            foreach (var comDir in firstDirectories.Where(fl =>
                secondDirectories.Any(scFl => AreEqual(scFl, fl))))
                TrySync(comDir, Path.Combine(path2, Path.GetFileName(comDir)));

            void TrySync(string sync1, string sync2)
            {
                try
                {
                    Sync2Folders(sync1, sync2);
                }
                catch
                {
                }
            }

            bool AreEqual(string filePath1, string filePath2) =>
                Path.GetFileNameWithoutExtension(filePath1) == Path.GetFileNameWithoutExtension(filePath2);
        }

        public static void CreateShortcut(string shortcutFolderPath, string targetFileLocation)
        {
            string shortcutLocation = Path.Combine(shortcutFolderPath,
                Path.GetFileNameWithoutExtension(targetFileLocation)) + ".lnk";
            var shell = new WshShell();
            var shortcut = (IWshShortcut) shell.CreateShortcut(shortcutLocation);

            //shortcut.Description = "My shortcut description";
            //shortcut.IconLocation = @"c:\myicon.ico"; 
            shortcut.TargetPath = targetFileLocation; 
            shortcut.Save(); 
        }
    }
}