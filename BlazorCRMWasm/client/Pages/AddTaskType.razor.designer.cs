﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using BlazorCrmWasm.Models.Crm;
using Microsoft.AspNetCore.Identity;
using BlazorCrmWasm.Models;
using BlazorCrmWasm.Client.Pages;

namespace BlazorCrmWasm.Pages
{
    public partial class AddTaskTypeComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }


        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }


        [Inject]
        protected CrmService Crm { get; set; }

        BlazorCrmWasm.Models.Crm.TaskType _tasktype;
        protected BlazorCrmWasm.Models.Crm.TaskType tasktype
        {
            get
            {
                return _tasktype;
            }
            set
            {
                if(!object.Equals(_tasktype, value))
                {
                    _tasktype = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }
        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            if (!await Security.IsAuthenticatedAsync())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }

        }
        protected async System.Threading.Tasks.Task Load()
        {
            tasktype = new BlazorCrmWasm.Models.Crm.TaskType(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(BlazorCrmWasm.Models.Crm.TaskType args)
        {
            try
            {
                var crmCreateTaskTypeResult = await Crm.CreateTaskType(taskType:tasktype);
                DialogService.Close(tasktype);
            }
            catch (System.Exception crmCreateTaskTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TaskType!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
