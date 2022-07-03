# Dashboard Management

```csharp
DashboardManagementController dashboardManagementController = client.DashboardManagementController;
```

## Class Name

`DashboardManagementController`


# Inplace API Import Via File

Import an API Version by specifying file path address of an API Spec to replace an existing version.

```csharp
InplaceAPIImportViaFileAsync(
    FileStreamInfo file,
    string apiEntityId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `file` | `FileStreamInfo` | Form, Required | API Spec file to be inmported |
| `apiEntityId` | `string` | Template, Required | Unique API Entity Identifier |

## Response Type

`Task`

## Example Usage

```csharp
FileStreamInfo file = new FileStreamInfo(new FileStream("dummy_file",FileMode.Open));
string apiEntityId = "apiEntityId2";

try
{
    await dashboardManagementController.InplaceAPIImportViaFileAsync(file, apiEntityId);
}
catch (ApiException e){};
```

