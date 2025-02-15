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

using System;
using System.Text.RegularExpressions;

namespace Mindbox.I18n;

public class LocalizationKey : IEquatable<LocalizationKey>
{
	private static readonly Regex _localizationKeyRegex =
		new(@"^([a-zA-Z0-9_]+):([a-zA-Z0-9_]+)$", RegexOptions.Compiled);

	public string ShortKey { get; }
	public string Namespace { get; }
	public string FullKey { get; }

	public static LocalizationKey? TryParse(string keyWithNamespace)
	{
		var match = _localizationKeyRegex.Match(keyWithNamespace);
		if (!match.Success)
			return null;

		var @namespace = match.Groups[1].Value;
		var key = match.Groups[2].Value;

		return new LocalizationKey(@namespace, key, keyWithNamespace);
	}

	public override string ToString() => FullKey;

	private LocalizationKey(string @namespace, string shortKey, string fullKey)
	{
		Namespace = @namespace;
		ShortKey = shortKey;
		FullKey = fullKey;
	}

	public bool Equals(LocalizationKey other)
	{
		if (other is null)
			return false;
		if (ReferenceEquals(this, other))
			return true;

		return StringComparer.InvariantCultureIgnoreCase.Equals(FullKey, other.FullKey);
	}

	public override bool Equals(object obj)
	{
		if (obj is null)
			return false;
		if (ReferenceEquals(this, obj))
			return true;
		if (obj.GetType() != GetType())
			return false;
		return Equals((LocalizationKey)obj);
	}

	public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(FullKey);
}