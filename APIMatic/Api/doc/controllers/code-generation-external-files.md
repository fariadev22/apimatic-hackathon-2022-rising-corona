# Code Generation-External Files

```csharp
CodeGenerationExternalFilesController codeGenerationExternalFilesController = client.CodeGenerationExternalFilesController;
```

## Class Name

`CodeGenerationExternalFilesController`


# Download SDK

Download a generated SDK by specifying CodeGen Id as input.

```csharp
DownloadSDKAsync(
    string codeGenId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `codeGenId` | `string` | Template, Required | Id associated with each generation |

## Response Type

`Task<Stream>`

## Example Usage

```csharp
string codeGenId = "codeGenId0";

try
{
    Stream result = await codeGenerationExternalFilesController.DownloadSDKAsync(codeGenId);
}
catch (ApiException e){};
```

