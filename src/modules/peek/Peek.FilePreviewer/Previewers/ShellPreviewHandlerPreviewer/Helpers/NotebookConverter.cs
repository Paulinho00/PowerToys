// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Peek.FilePreviewer.Previewers.Models;

namespace Peek.FilePreviewer.Previewers.Helpers
{
    public static class NotebookConverter
    {
        public static Stream ConvertToPythonFile(Stream stream)
        {
            var pythonFile = string.Empty;
            var cells = JsonSerializer.Deserialize<List<Cell>>(stream);
            foreach (var (index, item) in cells!.Select((item, index) => (index, item)))
            {
                if (item.Type == "code")
                {
                    pythonFile += $"#Cell {index + 1}\n";
                    pythonFile += string.Join(string.Empty, item.Source!);
                }
                else if (item.Type == "markdown")
                {
                    pythonFile += $"#Cell {index + 1}\n#";
                    pythonFile += string.Join("#", item.Source!);
                }

                pythonFile += "\n\n";
            }

            return GetStreamFromString(pythonFile);
        }

        private static MemoryStream GetStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
