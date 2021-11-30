# Maxle5.ProseMirror

![Nuget](https://img.shields.io/nuget/v/Maxle5.ProseMirror?style=flat-square)
[![Build](https://github.com/maxle5/ProseMirror/actions/workflows/ci.yml/badge.svg)](https://github.com/maxle5/ProseMirror/actions/workflows/ci.yml)

Maxle5.ProseMirror is a library used for converting [ProseMirror](https://github.com/ProseMirror/prosemirror) content to/from JSON and HTML

## Examples
**1. Convert HTML to ProseMirror object:**
```
  const string html = "<h1>Heading</h1><p>Some more <b>TEXT</b></p>";
  var obj = ProseMirrorConvert.DeserializeObjectFromHtml(html);
```

**2. Convert JSON to ProseMirror object:**
```
  const string json = "{\"type\":\"doc\",\"content\":[{\"type\":\"heading\",\"attrs\":{\"level\":1,\"textAlign\":\"left\"},\"content\":[{\"text\":\"Heading\",\"type\":\"text\"}]},{\"type\":\"paragraph\",\"attrs\":{\"textAlign\":\"left\"},\"content\":[{\"text\":\"Some more \",\"type\":\"text\"},{\"text\":\"TEXT\",\"type\":\"text\",\"marks\":[{\"type\":\"bold\"}]}]}]}";
  var obj = ProseMirrorConvert.DeserializeObjectFromHtml(html);
```

**3. Convert ProseMirror object to JSON:**
```
  var json = ProseMirrorConvert.SerializeToJson(obj);
```

**4. Convert ProseMirror object to HTML:**
```
Not yet supported. Coming soon.
```
