﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using Timinute.Client.Helpers;
using Timinute.Client.Models;
using Timinute.Shared.Dtos.TrackedTask;

namespace Timinute.Client.Pages.TrackedTasks
{
    public partial class TrackedTasks
    {
        public readonly IList<TrackedTask> TrackedTasksList = new List<TrackedTask>();

        private string exceptionMessage;

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        private IHttpClientFactory clientFactory { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity != null && !user.Identity.IsAuthenticated)
                Navigation.NavigateTo($"{Navigation.BaseUri}auth/login", true);
           
           await RefreshTable();
        }

        private async Task RefreshTable()
        {
            exceptionMessage = "";
            var client = clientFactory.CreateClient(Constants.API.ClientName);

            try
            {
                var response = await client.GetFromJsonAsync<TrackedTaskDto[]>(Constants.API.TrackedTask.GetAll);

                if (response != null)
                {
                    TrackedTasksList.Clear();

                    foreach (var item in response)
                        TrackedTasksList.Add(new TrackedTask(item));
                }
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
        }
    }
}