using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using ApimaticAPI.Standard;
using ApimaticAPI.Standard.Controllers;
using ApimaticAPI.Standard.Http.Client;
using ApimaticAPI.Standard.Models;

namespace Apimatic.Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args != null && args.Length == 4)
            {
                ApimaticAPIClient client =
                    new ApimaticAPIClient.Builder()
                        .BasicAuthCredentials(args[0], args[1]).Build();

                string executionDirectory =
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
                string apiEntityId = args[2];
                string apiIntegrationKey = args[3];

                PushLatestSpecToApimaticDashboard(apiEntityId, client, executionDirectory);
                DownloadAndReplaceOldSdk(client, apiEntityId, executionDirectory);
                PublishPortalWithNewSpec(client, apiIntegrationKey);
            }
            else
            {
                Console.WriteLine("Insufficient arguments. " +
                                  "Expected <APIMatic Username> <APIMatic Password> " +
                                  "<API Entity Id> <API Integration Key>");
            }

        }

        private static void PushLatestSpecToApimaticDashboard(
            string apiEntityId,
            ApimaticAPIClient client,
            string executionDirectory)
        {
            //push latest spec to Dashboard
            DashboardManagementController dashboardManagementController =
                client.DashboardManagementController;


            string filePath = Path.GetFullPath(
                Path.Combine(
                    executionDirectory,
                    @"../../../../../") + "/RisingCorona.json");
            FileStreamInfo file = new FileStreamInfo(
                new FileStream(filePath, FileMode.Open));

            try
            {
                dashboardManagementController.InplaceAPIImportViaFile(
                    file, apiEntityId);
                Console.WriteLine("Successfully pushed the new spec to APIMatic Dashboard.");
            }
            catch
            {
                Console.WriteLine(
                    "Could not update the spec in APIMatic Dashboard successfully.");
            }
        }

        private static void DownloadAndReplaceOldSdk(
            ApimaticAPIClient client, 
            string apiEntityId, 
            string executionDirectory)
        {
            try
            {
                //generate SDK for it
                CodeGenerationImportedApisController codeGenerationImportedApisController =
                    client.CodeGenerationImportedApisController;

                Platforms template = Platforms.CSNETSTANDARDLIB;

                APIEntityCodeGeneration codeGenerationResponse =
                    codeGenerationImportedApisController.GenerateSDK(apiEntityId, template);

                string codeGenId = codeGenerationResponse.Id;

                Stream sdkStream = codeGenerationImportedApisController.DownloadSDK(
                    apiEntityId,
                    codeGenId);

                string sdkPath = Path.GetFullPath(
                    Path.Combine(
                        executionDirectory,
                        @"../../../../../") + "/Api");

                //delete existing contents of directory
                DirectoryInfo di = new DirectoryInfo(sdkPath);

                foreach (FileInfo fileToDelete in di.GetFiles())
                {
                    fileToDelete.Delete();
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                //extract new contents
                ZipArchive archive = new ZipArchive(sdkStream);
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string entryFilePath =
                        Path.Combine(sdkPath, entry.FullName);
                    string directory = Path.GetDirectoryName(entryFilePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    entry.ExtractToFile(entryFilePath, true);
                }

                Console.WriteLine("Successfully downloaded and replaced the SDK.");
            }
            catch
            {
                Console.WriteLine(
                    "Could not update the SDK successfully.");
            }
        }

        private static void PublishPortalWithNewSpec(
            ApimaticAPIClient client,
            string apiIntegrationKey)
        {
            try
            {
                DocumentationGenerationController documentationGenerationController =
                    client.DocumentationGenerationController;

                documentationGenerationController.PublishPortalArtifacts(apiIntegrationKey);

                Console.WriteLine("Portal published successfully.");
            }
            catch
            {
                Console.WriteLine("Unable to publish portal as the " +
                                  "APIMatic API's publishing endpoint is broken.");
            }
        }
    }
}
