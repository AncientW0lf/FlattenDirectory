using System.Collections.Generic;
using System.IO;

namespace FlattenDirectory
{
	public static class Flattener
	{
		public static void Flatten(string dir)
		{
			string[] subfolders = Directory.GetDirectories(dir);
			for(int i = 0; i < subfolders.Length; i++)
			{
				IEnumerable<string> files = Directory.EnumerateFiles(subfolders[i], "*.*", SearchOption.AllDirectories);

				foreach(string file in files)
				{
					string filepath = file;

					while(Path.GetDirectoryName(filepath) != Path.GetFullPath(dir))
					{
						string newPath = Path.GetDirectoryName(Path.GetDirectoryName(filepath));

						if(newPath == null)
							throw new DirectoryNotFoundException($"Could not find parent directory of file \"{filepath}\"");

						newPath = Path.Combine(newPath, Path.GetFileName(filepath));

						File.Move(filepath, newPath);
						filepath = newPath;
					}
				}
			}
		}
	}
}
