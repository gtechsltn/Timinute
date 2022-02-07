﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using Timinute.Client.Helpers;
using Timinute.Client.Models;
using Timinute.Shared.Dtos.TrackedTask;

namespace Timinute.Client.Pages.TrackedTasks
{
    public partial class TrackedTasksManager
    {
        private List<TrackedTask> trackedTasksList { get; set; } = new();

        private string ExceptionMessage { get; set; } = "";

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        protected NavigationManager Navigation { get; set; } = null!;

        [Inject]
        private IHttpClientFactory ClientFactory { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;
            var user = authState.User;

            if (user.Identity != null && !user.Identity.IsAuthenticated)
                Navigation.NavigateTo($"{Navigation.BaseUri}auth/login", true);

            await RefreshTable();
        }

        private async Task RefreshTable()
        {
            ExceptionMessage = "";
            var client = ClientFactory.CreateClient(Constants.API.ClientName);

            try
            {
                var response = await client.GetFromJsonAsync<TrackedTaskDto[]>(Constants.API.TrackedTask.GetAll);

                if (response != null)
                {
                    trackedTasksList.Clear();

                    foreach (var item in response)
                        trackedTasksList.Add(new TrackedTask(item));
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
        }

        private async Task RemoveTrackedTask(string trackedTaskId)
        {
            ExceptionMessage = "";
            var client = ClientFactory.CreateClient(Constants.API.ClientName);

            try
            {
                var response = await client.DeleteAsync($"{Constants.API.TrackedTask.Delete}/{trackedTaskId}");

                if (response != null && response.IsSuccessStatusCode)
                {
                    await RefreshTable();
                }
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
        }
    }
}
