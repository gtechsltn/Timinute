﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using System.Net.Http.Json;
using Timinute.Client.Helpers;
using Timinute.Client.Models;
using Timinute.Shared.Dtos.TrackedTask;

namespace Timinute.Client.Pages.TrackedTasks
{
    public partial class TrackedTasksManager
    {
        private List<TrackedTask> trackedTasksList { get; set; } = new();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        #region Dependency Injection

        [Inject]
        protected NavigationManager Navigation { get; set; } = null!;

        [Inject]
        private IHttpClientFactory ClientFactory { get; set; } = null!;

        [Inject]
        private NotificationService notificationService { get; set; } = null!;

        #endregion

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
                notificationService.Notify(NotificationSeverity.Error, "Validation error", ex.Message, 5000);
            }
        }

        private async Task RemoveTrackedTask(string trackedTaskId)
        {
            var client = ClientFactory.CreateClient(Constants.API.ClientName);

            try
            {
                var response = await client.DeleteAsync($"{Constants.API.TrackedTask.Delete}/{trackedTaskId}");

                if (response != null && response.IsSuccessStatusCode)
                {
                    await RefreshTable();
                    notificationService.Notify(NotificationSeverity.Success, "Success", "Tracked task was removed", 3000);
                }
            }
            catch (Exception ex)
            {
                notificationService.Notify(NotificationSeverity.Error, "Validation error", ex.Message, 5000);
            }
        }
    }
}
