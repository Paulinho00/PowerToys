﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Peek.FilePreviewer.Previewers.Models
{
    public class Cell
    {
        public string Type { get; set; } 
        public List<string>? Source { get; set; }
    }
}