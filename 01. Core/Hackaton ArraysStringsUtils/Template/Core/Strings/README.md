# string methods

### Table of Contents

- [`Abbreviate(string, int)`](#abbreviatestring-int)
- [`Capitalize(string)`](#capitalizestring)
- [`Concat(string, string)`](#concatstring-string)
- [`Contains(string, char)`](#containsstring-char)
- [`EndsWith(string, char)`](#endswithstring-char)
- [`FirstIndexOf(string, char)`](#firstindexofstring-char)
- [`LastIndexOf(string, char)`](#lastindexofstring-char)
- [`Pad(string, int, char)`](#padstring-int-char)
- [`PadEnd(string, int, char)`](#padendstring-int-char)
- [`PadStart(string, int, char)`](#padstartstring-int-char)
- [`Repeat(string, int)`](#repeatstring-int)
- [`Reverse(string)`](#reversestring)
- [`Section(string, int, int)`](#sectionstring-int-int)
- [`StartsWith(string, char)`](#startswithstring-char)

***

## `Abbreviate(string, int)`

```cs
Abbreviate(string source, int maxLength);
```

### Description

*Abbreviates a string using ellipses.*

### Parameters

**`source`** string - *The string to modify*

**`maxLength`** int - *Maximum length of the resulting string*

### Returns

`string` - *The abbreviated string*

#### Example

```cs
Abbreviate("Telerik Academy", 13)

//returns: Telerik Acade...
```

***

## `Capitalize(string)`

```cs
Capitalize(string source);
```

### Description

*Capitalizes a string changing the first character to title case. No other characters are changed. If source is empty returns empty string.*

### Parameters

**`source`** string - *The string to modify*

### Returns

`string` - *The capitalized string or empty string if `source` is empty*

#### Example

```cs
Capitalize("academy")

//returns: Academy
```
***

## `Concat(string, string)`

```cs
Concat(string string1, string string2);
```

### Description

*Concatenates `string1` to the end of `string2`.*

### Parameters

**`string1`** string - *The left part of the new string*

**`string2`** string - *The right part of the new string*

### Returns

`string` - *A string that represents the concatenation of string1 followed by string2's characters*

#### Example

```cs
Concat("Visual", "Studio")

//returns: VisualStudio
```

***

## `Contains(string, char)`

```cs
Contains(string source, char symbol);
```

### Description

*Checks if `source` contains a `symbol`.*

### Parameters

**`source`** string - *The string to check*

**`symbol`** char - *The character to check for*

### Returns

`bool` - *`true` if `symbol` is within `source` or `false` if not*

#### Example

```cs
Contains("Academy", 'd')

//returns: true
```

***

## `StartsWith(string, char)`

```cs
StartsWith(string source, char target);
```

### Description

*Checks if the string `source` starts with the given character.*

### Parameters

**`source`** string - *The string to inspect*

**`target`** char - *The character to search for*

### Returns

`bool` - *`true` if string starts with target, otherwise `false`*

#### Example

```cs
StartsWith("Academy", 'A');
//returns: true

StartsWith("Academy", 'a');
//returns: false
```

***

## `EndsWith(string, char)`

```cs
EndsWith(string source, char target);
```

### Description

*Checks if the string `source` ends with the given character.*

### Parameters

**`source`** string - *The string to check*

**`target`** char - *The character to check for*

### Returns

`bool` - *`true` if the string ends with `target`, else `false`*

#### Example

```cs
EndsWith("Telerik", 'k')

//returns: true
```

***

## `FirstIndexOf(string, char)`

```cs
FirstIndexOf(string source, char target);
```

### Description

*Finds the first index of `target` within `source`.*

### Parameters

**`source`** string - *The string to check*

**`target`** char - *The character to check for*

### Returns

`int` - *The first index of `target` within `source`, otherwise, -1*

#### Example

```cs
FirstIndexOf("Telerik Academy", 'e')

//returns: 1
```

***

## `LastIndexOf(string, char)`

```cs
LastIndexOf(string source, char target);
```

### Description

*Finds the last index of `target` within `source`.*

### Parameters

**`source`** string - *The string to check*

**`target`** char - *The character to check for*

### Returns

`int` - *The last index `symbol` within `source` or -1 if no match*

#### Example

```cs
LastIndexOf("Telerik Academy", 'e')

//returns: 12
```

***

## `Pad(string, int, char)`

```cs
Pad(string source, int length, char paddingSymbol);
```

### Description

*Pads string on the left and right sides if it's shorter than length.*

### Parameters

**`source`** string - *The string to pad*

**`length`** int - *The length of the string to achieve*

**`target`** char - *The character used as padding*

### Returns

`string`
*The padded string*

#### Example

```cs
Pad("C#", 8, '*');

//returns: ***C#***
```

***

## `PadEnd(string, int, char)`

```cs
PadEnd(string source, int length, char paddingSymbol);
```

### Description

*Pads `source` on the right side with `PaddingSymbol` enough times to reach length `length`.*

### Parameters

**`source`** string - *The string to pad*

**`length`** int - *The length of the string to achieve*

**`target`** char - *The character used as padding*

### Returns

`string` - *The padded string*

#### Example

```cs
PadEnd("C#", 6, '*');

//returns: C#****
```

***

## `PadStart(string, int, char)`

```cs
PadStart(string source, int length, char paddingSymbol);
```

### Description

*Pads `source` on the left side with `PaddingSymbol` enough times to reach length `length`.*

### Parameters

**`source`** string - *The string to pad*

**`length`** int - *The length of the string to achieve*

**`target`** char - *The character used as padding*

### Returns

`string` - *The padded string*

#### Example

```cs
PadStart("C#", 6, '*');

//returns: ****C#
```

***

## `Repeat(string, int)`

```cs
Repeat(string source, int times);
```

### Description

*Repeats the given string `times` times.*

### Parameters

**`source`** string - *The string to repeat*

**`times`** int - *The number of times to repeat the string*

### Returns

`string` - *The repeated string*

#### Example

```cs
Repeat("C#", 3);

//returns: C#C#C#
```

***

## `Reverse(string)`

```cs
Reverse(string source);
```

### Description

*Reverses `source` so that the first element becomes the last, the second element becomes the second to last, and so on.*

### Parameters

**`source`** string - *The string to reverse*

### Returns

`string` - *The reversed string*

#### Example

```cs
Reverse("C#");

//returns: #C
```

***

## `Section(string, int, int)`

```cs
Section(string source, int start, int end);
```

### Description

*Returns a new string, starting from `start` and ending at `end`.*

### Parameters

**`source`** string - *The string to reverse*

**`start`** int - *The starting position in `source` (inclusive)*

**`end`** int - *The end position in `source` (inclusive)*

### Returns

`string` - *A new string, formed by the characters in `source`, starting from `start` to `end`*

#### Example

```cs
Section("**Telerik Academy**", 2, 16);

//returns: Telerik Academy
```

***
