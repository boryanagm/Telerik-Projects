using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TelerikAcademy.DSA
{
	public class FileUtils
	{
		public const string Path = @"..\..\..\Images";

		public static string GetFileExtension(string filePath)
		{
			int lastIndex = filePath.LastIndexOf('.');

			return filePath[lastIndex..];
		}

        public static string GetFileName(string path)
        {
            int lastIndex = path.LastIndexOf('\\') + 1;
            string lastPart = path[lastIndex..];
            return lastPart;
        }

        public static string TraverseDirectories(string path)
        {
            var result = TraverseDirectoriesRecursively(path, 0, new StringBuilder());

            return result;
        }

        public static string TraverseDirectoriesRecursively(string path, int indentDepth, StringBuilder sb)
        {
            string indentation = new string(' ', indentDepth * 2);

            sb.AppendLine($"{indentation}{FileUtils.GetFileName(path)}");

            foreach (string filePath in Directory.GetFiles(path))
            {
                sb.AppendLine($"{indentation} {FileUtils.GetFileName(filePath)}");
            }
            foreach (string subDirPath in Directory.GetDirectories(path))
            {
                TraverseDirectoriesRecursively(subDirPath, indentDepth + 1, sb);
            }

            return sb.ToString().Trim();
        }

        public static List<string> FindFiles(string path, string extension)
		{
            var files = FindFilesRecursively(path, extension, new List<string>());

            return files;
		}

        public static List<string> FindFilesRecursively(string path, string extension, List<string> fileList)
        {
            var matchingFiles = Directory.GetFiles(path)
                               .Where(f => FileUtils.GetFileExtension(f) == extension)
                               .Select(f => FileUtils.GetFileName(f));

            foreach (string fileName in matchingFiles)
            {
                fileList.Add(fileName);
            }

            foreach (string subDir in Directory.GetDirectories(path))
            {
                fileList = FindFilesRecursively(subDir, extension, fileList);
            }

            return fileList;
        }

        public static bool FileExists(string path, string fileName)
        {
            bool exists = Directory.GetFiles(path).Any(fullPath => FileUtils.GetFileName(fullPath) == fileName);

            return Directory.GetDirectories(path)
                            .Aggregate(exists, (result, subDir) => result || FileExists(subDir, fileName));
        }

        public static Dictionary<string, int> GetDirectoryStats(string path)
        {
            var stats = GetDirectoryStatsRecursively(path, new Dictionary<string, int>());

            return stats;
        }

        public static Dictionary<string, int> GetDirectoryStatsRecursively(string path, Dictionary<string, int> dict)
        {
            var filesExtensions = Directory.GetFiles(path).Select(f => FileUtils.GetFileExtension(f));

            foreach (var fileExtension in filesExtensions)
            {
                if (!dict.ContainsKey(fileExtension))
                {
                    dict[fileExtension] = 0;
                }
                dict[fileExtension]++;
            }

            foreach (var subDir in Directory.GetDirectories(path))
            {
                dict = GetDirectoryStatsRecursively(subDir, dict);
            }

            return dict;
        }
    }
}
