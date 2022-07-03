# Code Generation-Imported APIs

```csharp
CodeGenerationImportedApisController codeGenerationImportedApisController = client.CodeGenerationImportedApisController;
```

## Class Name

`CodeGenerationImportedApisController`

## Methods

* [Generate SDK](../../doc/controllers/code-generation-imported-apis.md#generate-sdk)
* [Download SDK](../../doc/controllers/code-generation-imported-apis.md#download-sdk)


# Generate SDK

Generate SDK against a specific API using the API Entity Identifier and specifying the platform template.

```csharp
GenerateSDKAsync(
    string apiEntityId,
    Models.Platforms template)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `apiEntityId` | `string` | Template, Required | Unique API version identifier |
| `template` | [`Models.Platforms`](../../doc/models/platforms.md) | Form, Required | Platform Template |

## Response Type

[`Task<Models.APIEntityCodeGeneration>`](../../doc/models/api-entity-code-generation.md)

## Example Usage

```csharp
string apiEntityId = "apiEntityId2";
Platforms template = Platforms.RUBYGENERICLIB;

try
{
    APIEntityCodeGeneration result = await codeGenerationImportedApisController.GenerateSDKAsync(apiEntityId, template);
}
catch (ApiException e){};
```


# Download SDK

Download SDK generated against a specific API using API Entity Id and the CodeGen Id.

```csharp
DownloadSDKAsync(
    string apiEntityId,
    string codeGenId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `apiEntityId` | `string` | Template, Required | Unique API Entity  identifier |
| `codeGenId` | `string` | Template, Required | Unique Code Generation identifier |

## Response Type

`Task<Stream>`

## Example Usage

```csharp
string apiEntityId = "apiEntityId2";
string codeGenId = "codeGenId0";

try
{
    Stream result = await codeGenerationImportedApisController.DownloadSDKAsync(apiEntityId, codeGenId);
}
catch (ApiException e){};
```

