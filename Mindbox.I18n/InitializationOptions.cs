// Copyright 2022 Mindbox Ltd
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Mindbox.I18n;

public class InitializationOptions
{
	public IReadOnlyList<string> SupportedLanguages { get; set; } = new List<string>();
	public ILogger Logger { get; set; } = null!;
	public string LocalizationDirectoryPath { get; set; } = null!;
	public ITranslationSource TranslationSource { get; set; } = null!;
}