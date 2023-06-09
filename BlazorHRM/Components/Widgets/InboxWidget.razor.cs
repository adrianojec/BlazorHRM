﻿using System;
using BlazorHRM.State;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Components.Widgets
{
  public partial class InboxWidget
  {
    [Inject]
    public AppState? AppState { get; set; }

    public int MessageCount { get; set; }

    protected override void OnInitialized()
    {
      MessageCount = AppState.MessageCount;
    }
  }
}

