﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;
using Timinute.Client.Helpers;
using Timinute.Client.Models;
using Timinute.Shared.Dtos.Project;

namespace Timinute.Client.Components
{
    public partial class AddProject
    {
        private Project project { get; set; } = new();

        private string exceptionMessage;

        bool displayValidationErrorMessages = false;

        [Inject]
        private IHttpClientFactory clientFactory { get; set; }

        private async Task HandleValidSubmit()
        {
            var client = clientFactory.CreateClient(Constants.API.ClientName);

            ProjectDto createProjectDto = new()
            {
                Name = project.Name
            };

            try
            {
                var responseMessage = await client.PostAsJsonAsync(Constants.API.Project.Create, createProjectDto);
                responseMessage.EnsureSuccessStatusCode();

                displayValidationErrorMessages = false;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
                displayValidationErrorMessages = true;
            }
        }

        private void HandleInvalidSubmit(EditContext context)
        {
            displayValidationErrorMessages = true;
        }
    }
}
