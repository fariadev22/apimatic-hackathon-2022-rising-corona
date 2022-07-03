
# Code Generation

The Code Generation structure encapsulates all the  the details of an SDK generation performed against an API Entity

## Structure

`CodeGeneration`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | Unique Code Generation Identifier |
| `Template` | [`Models.Platforms`](../../doc/models/platforms.md) | Required | Desired Language Platform |
| `GeneratedFile` | `string` | Required | The generated SDK |
| `GeneratedOn` | `DateTime` | Required | Generation Date and Time |
| `HashCode` | `string` | Required | The md5 hash of the API Description |
| `CodeGenerationSource` | `string` | Required | Generation Source |
| `CodeGenVersion` | `string` | Required | Generation Version |
| `Success` | `bool` | Required | Generation Status |

## Example (as JSON)

```json
{
  "id": "5be08b2d83b41d0d8cdb3289",
  "template": null,
  "generatedFile": "https://apimatic.io/api/code-generations/5be08b2d83b41d0d8cdb3289/generated-sdk",
  "generatedOn": "11/05/2018 18:25:46",
  "hashCode": "77BDA4F625EF512B336D0A77CE2BB2B6",
  "codeGenerationSource": "Api",
  "codeGenVersion": "1",
  "success": true
}
```

