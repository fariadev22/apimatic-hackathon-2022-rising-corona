
# API Entity Code Generation

The Code Generation structure encapsulates all the  the details of an SDK generation performed against an API Entity

## Structure

`APIEntityCodeGeneration`

## Inherits From

[`CodeGeneration`](../../doc/models/code-generation.md)

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApiEntityId` | `string` | Required | Unique API Entity Identifier |

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
  "success": true,
  "apiEntityId": "5be012963270e339f88005d0"
}
```

