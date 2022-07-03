# Documentation Generation

```csharp
DocumentationGenerationController documentationGenerationController = client.DocumentationGenerationController;
```

## Class Name

`DocumentationGenerationController`


# Publish Portal Artifacts

Generate and publish SDKs, Documentations and API Spec exports for your Portal.

```csharp
PublishPortalArtifactsAsync(
    string apiKey)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `apiKey` | `string` | Template, Required | Unique encrypted API Identifier |

## Response Type

`Task`

## Example Usage

```csharp
string apiKey = "apiKey0";

try
{
    await documentationGenerationController.PublishPortalArtifactsAsync(apiKey);
}
catch (ApiException e){};
```

